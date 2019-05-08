using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject player;

    public GameObject smallTNT;
    public GameObject largeTNT;
    public GameObject smallBomb;
    public GameObject largeBomb;

    public static int strongChance = 99;
    public static int completions = 0;

    float timeToNext = 2;
    bool onCooldown = false;
    bool cleanupFinished = false;
    System.Random rnd;
    Node[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        rnd = new System.Random();
        grid = Grid.grid;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerController>().alive)
        {
            if (!onCooldown)
            {
                DropExplosive();
            }
            else
            {
                timeToNext -= 1 * Time.deltaTime;
                if (timeToNext <= 0)
                {
                    onCooldown = false;
                    timeToNext = Random.Range(0.1f, 0.4f);
                }
            }
        }
        else
        {
            strongChance = 99;
            completions = 0;
            if (!cleanupFinished)
            {
                Utilities.CleanupExplosives(true);
                cleanupFinished = true;
            }
        }
    }

    public void DropExplosive()
    {
        int x = rnd.Next(grid.GetLength(0));
        int y = rnd.Next(grid.GetLength(1));

        Node node = grid[x, y];
        
        if (!node.IsOccupied())
        {
            onCooldown = true;

            GameObject explosive;
            double type = rnd.Next(2);
            double strength = rnd.Next(100) + 1;

            if (type == 0)
            {
                if (strength >= strongChance)
                {
                    explosive = Instantiate(largeTNT, new Vector3(y - 6, 3 - x, 0), transform.rotation);
                    explosive.GetComponent<LargeTNT>().x = x;
                    explosive.GetComponent<LargeTNT>().y = y;
                }
                else
                {
                    explosive = Instantiate(smallTNT, new Vector3(y - 6, 3 - x, 0), transform.rotation);
                    explosive.GetComponent<SmallTNT>().x = x;
                    explosive.GetComponent<SmallTNT>().y = y;
                }
            }
            else
            {
                if (strength >= strongChance)
                {
                    explosive = Instantiate(largeBomb, new Vector3(y - 6, 3 - x, 0), transform.rotation);
                    explosive.GetComponent<LargeBomb>().x = x;
                    explosive.GetComponent<LargeBomb>().y = y;
                }
                else
                {
                    explosive = Instantiate(smallBomb, new Vector3(y - 6, 3 - x, 0), transform.rotation);
                    explosive.GetComponent<SmallBomb>().x = x;
                    explosive.GetComponent<SmallBomb>().y = y;
                }
            }

            node.currentObj = explosive;
        }
    }

   
    public void IncreaseDifficulty()
    {
        if (Grid.Completed())
        {
            if (strongChance != 50)
            {
                if (strongChance - 3 * completions <= 50)
                {
                    strongChance = 50;
                }
                else
                {
                    strongChance -= 3 * completions;
                }
            }
        }
        
    }

}
