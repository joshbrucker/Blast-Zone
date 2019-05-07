using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ItemManager itemManager;
    public GameObject visitedPrefab;
    public int invincTime = 3;

    public bool alive { get; set; }

    Node[,] grid;
    int x, y;

    void Start()
    {
        alive = true;
        grid = Grid.grid;
        x = 6;
        y = 0;
    }

    void Update()
    {
        if (alive && PauseMenu.IsPaused == false)
        {
            CheckMovement();
            CheckDamage();
            CheckVisited();
        }
    }

    // Checks if the player's space has been visited; if not, set to visited.
    public void CheckVisited()
    {
        Node node = grid[x, y];
        if (!node.visited)
        {
            node.visited = true;
            GameObject visitedObj = Instantiate(visitedPrefab, transform.position, transform.rotation);
            Grid.Visit(visitedObj);

            if (Grid.Completed())
            {
                Grid.ClearVisited();
            }
        }
    }

    // Checks if the player is in a space that causes damage
    public void CheckDamage()
    {
        if (grid[x, y].harmful)
        {
            alive = false;
        }
    }

    // Manages player movement
    public void CheckMovement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (y + 1 < grid.GetLength(1))
            {
                transform.position += new Vector3(1, 0, 0);
                y++;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (y - 1 >= 0)
            {
                transform.position += new Vector3(-1, 0, 0);
                y--;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (x - 1 >= 0)
            {
                transform.position += new Vector3(0, 1, 0);
                x--;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (x + 1 < grid.GetLength(0))
            {
                transform.position += new Vector3(0, -1, 0);
                x++;
            }
        }

        //implemented to help with difficulty testing
        if (Input.GetKeyDown(KeyCode.H))
        {
            Grid.ClearVisited();
        }
    }
}