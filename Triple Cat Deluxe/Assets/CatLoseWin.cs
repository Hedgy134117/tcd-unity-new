using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatLoseWin : MonoBehaviour {

    public float deathYAxis;

    public ScoreboardManager scoreboardManager;
    public CardManager cardManager;

    private void Start()
    {
        // If Game started in unity on the gameplay scene then go to the card scene
        // otherwise run as normal
        if (GameObject.Find("CardManager") != null)
        {
            cardManager = GameObject.Find("CardManager").GetComponent<CardManager>();
        }
        else
        {
            SceneManager.LoadScene(1);
        }
        
        scoreboardManager = GameObject.Find("ScoreboardManager").GetComponent<ScoreboardManager>();
    }

    private void Update()
    {
        // If anyone fell below the death line
        if (transform.position.y <= deathYAxis)
        {
            // If playerOne falls below the death line
            if (tag == "playerOne")
            {
                // playerTwo gets the points
                scoreboardManager.playerTwoPoints += cardManager.cardData.pointValue;
            }
            // If playerTwo falls below the death line
            else if (tag == "playerTwo")
            {
                // playerOne gets the points
                scoreboardManager.playerOnePoints += cardManager.cardData.pointValue;
            }

            // Go to card drawing
            SceneManager.LoadScene(1);
        }
    }
}
