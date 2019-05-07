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
}
