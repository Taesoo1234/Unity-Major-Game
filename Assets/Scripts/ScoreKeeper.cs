using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    // the float that is the current score of the player
    public float score = 0;

    // the public text that is used to display the score
    public TextMeshPro CurrentScore;

    // Start is called before the first frame update
    void Start()
    {
        // sets the CurrentScore to nothing at the start
        CurrentScore.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //the text shown on the screen constantly updates to show 'Score:' and the score of the player
        CurrentScore.text = "Score:" + score;
    }

    // when recieveing the message IncreaseScore
    // increase the score by 1
    public void IncreaseScore()
    {
        score = score + 1;
    }
}