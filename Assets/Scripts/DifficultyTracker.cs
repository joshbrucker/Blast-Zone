using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DifficultyTracker
{
    public bool isComplete;
    public int completions;


    void Update()
    {
        if(Grid.Completed())
        {
            completions++;
            IncrementDifficulty(completions);
            Debug.Log("Difficulty increased by a factor of " + completions);
        }
    }



    public void IncrementDifficulty(int diff)
    {
       // ItemManager.setStrongChance(ItemManager.getStrongChance() - 5 * diff);
    }


}
