using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities
{
    public static void ResetSettings()
    {
        ItemManager.strongChance = 99;
        ItemManager.completions = 0;
        Grid.ResetVisitedCounter();
    }

    public static void CleanupExplosives(bool willExplode)
    {
        {
            for (int i = 0; i < Grid.grid.GetLength(0); i++)
            {
                for (int j = 0; j < Grid.grid.GetLength(1); j++)
                {
                    Node node = Grid.grid[i, j];
                    if (willExplode)
                    {
                        if (node.IsOccupied() && node.currentObj.GetComponent<Explosive>() != null
                            && !node.currentObj.GetComponent<Explosive>().primed)
                        {
                            node.currentObj.GetComponent<Explosive>().ChainExplode();
                        }
                    }
                    else
                    {
                        if (node.IsOccupied() && node.currentObj.GetComponent<Explosive>() != null)
                        {
                            node.currentObj.GetComponent<Explosive>().Kill();
                        }
                    }
                }
            }
        }
    }
}
