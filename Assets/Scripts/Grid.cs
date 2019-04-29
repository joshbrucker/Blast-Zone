using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * The Grid class represents the entire gameboard, with each node
 * holding data about the space's current state as well as if
 * there is an object residing in it.
 */

public static class Grid
{
    public static Node[,] grid;
    public static List<GameObject> visitedObjs;

    // Initializes the grid
    public static void Initialize()
    {
        grid = new Node[7, 13];
        visitedObjs = new List<GameObject>();
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = new Node(i, j, false, false, null);
            }
        }
    }

    // Checks if all nodes in grid are visited
    public static bool Completed()
    {
        if (visitedObjs.Count == grid.GetLength(0) * grid.GetLength(1))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Marks node in grid as visited
    public static void Visit(GameObject visitedObj)
    {
        visitedObjs.Add(visitedObj);
    }

    // Removes visited objects and reset all nodes to be unvisited
    public static void ClearVisited()
    {
        foreach (GameObject visited in visitedObjs)
        {
            Object.Destroy(visited);
        }

        visitedObjs.Clear();

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j].visited = false;
            }
        }
    }
}

public class Node
{
    int x, y;
    public bool visited { get; set; }
    public bool warned { get; set; }
    public bool harmful { get; set; }
    public GameObject currentObj { get; set; }

    public Node(int x, int y, bool warn, bool harmful, GameObject currentObj)
    {
        this.x = x;
        this.y = y;
        this.visited = false;
        this.warned = warned;
        this.harmful = harmful;
        this.currentObj = currentObj;
    }

    // Checks if node is occupied by an explosive or an item
    public bool IsOccupied()
    {
        if (currentObj != null)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
