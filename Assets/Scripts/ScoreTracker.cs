using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTracker : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = "Score: ";
    }

    // Update is called once per frame
    void Update()
    {
        string score = Grid.visitedCounter.ToString();
        scoreText.text = "Score: " + score;
    }


}
