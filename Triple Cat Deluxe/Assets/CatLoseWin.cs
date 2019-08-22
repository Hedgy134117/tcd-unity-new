using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatLoseWin : MonoBehaviour {

    public float deathYAxis;

    public ScoreboardManager scoreboardManager;
    public CardManager cardManager;
    public SettingsManager settingsManager;
    public WinManager winManager;

    public int pointsToWin;

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
            SceneManager.LoadScene("CardDraw", LoadSceneMode.Single);
        }
        
        if (GameObject.Find("SettingsManager") != null)
        {
            settingsManager = GameObject.Find("SettingsManager").GetComponent<SettingsManager>();
            pointsToWin = settingsManager.pointsToWin;
        }

        scoreboardManager = GameObject.Find("ScoreboardManager").GetComponent<ScoreboardManager>();
        winManager = GameObject.Find("WinManager").GetComponent<WinManager>();
    }

    private void LateUpdate()
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

            // If either player has enough points to win
            if (scoreboardManager.playerOnePoints >= pointsToWin || scoreboardManager.playerTwoPoints >= pointsToWin)
            {
                // set the winner cat and load the win screen
                winManager.winner = gameObject.GetComponent<CatSetter>().catData;
                SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
            }
            else
            {
                // Go to card drawing
                SceneManager.LoadScene(1);
            }
        }
    }
}
