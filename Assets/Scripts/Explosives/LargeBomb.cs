using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeBomb : MonoBehaviour, Explosive
{
    public int time = 3;
    public int x, y;
    public Sprite primedSprite;
    public GameObject warningPrefab;
    public GameObject explosionPrefab;

    public bool primed { get; set; }

    Node[,] grid;
    List<GameObject> warnings;

    void Start()
    {
        grid = Grid.grid;
        warnings = new List<GameObject>();
        primed = false;
        Invoke("Warn", time - 0.5f);
        Invoke("Explode", time);
    }

    void Update()
    {

    }

    // Triggers explosions across horizontal/vertical
    public void Explode()
    {
        ClearWarnings();

        SetExplosion(x, y);

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            SetExplosion(i, y);
        }

        for (int j = 0; j < grid.GetLength(1); j++)
        {
            SetExplosion(x, j);
        }

        Destroy(gameObject);
    }

    // Sets an explosion on an individual node
    public void SetExplosion(int i, int j)
    {
        Node node = grid[i, j];
        node.harmful = true;
        if (node.IsOccupied() && (i != x || j != y))
        {
            if (node.currentObj.GetComponent<Explosive>() != null && !node.currentObj.GetComponent<Explosive>().primed)
            {
                node.currentObj.GetComponent<Explosive>().ChainExplode();
            }
        }

        GameObject explosion = Instantiate(explosionPrefab, new Vector3(j - 6, 3 - i, 0), transform.rotation);
        explosion.GetComponent<Explosion>().x = i;
        explosion.GetComponent<Explosion>().y = j;
        node.currentObj = explosion;
    }

    // Triggers warnings across horizontal/vertical
    public void Warn()
    {
        primed = true;

        gameObject.GetComponent<SpriteRenderer>().sprite = primedSprite;

        for (int i = 0; i < grid.GetLength(0); i++)
        {
                SetWarning(i, y);
        }

        for (int j = 0; j < grid.GetLength(1); j++)
        {
                SetWarning(x, j);
        }
    }

    // Sets a warning on an individual node
    public void SetWarning(int i, int j)
    {
        Node node = grid[i, j];
        GameObject warning = Instantiate(warningPrefab, new Vector3(j - 6, 3 - i, 0), transform.rotation);
        warnings.Add(warning);
    }

    public void ClearWarnings()
    {
        foreach (GameObject warning in warnings)
        {
            Destroy(warning);
        }

        warnings.Clear();
    }

    public void Kill()
    {
        CancelInvoke();
        ClearWarnings();
        Destroy(gameObject);
    }

    // Immediately sets explosive into primed mode
    public void ChainExplode()
    {
        CancelInvoke();
        Warn();
        Invoke("Explode", 0.5f);
    }
}
