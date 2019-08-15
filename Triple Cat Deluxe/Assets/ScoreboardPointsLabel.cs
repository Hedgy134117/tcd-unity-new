using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardPointsLabel : MonoBehaviour {

    public int playerOnePoints;
    public int playerTwoPoints;

    private void LateUpdate()
    {
        // Get the points of player One
        playerOnePoints = GameObject.Find("ScoreboardManager").GetComponent<ScoreboardManager>().playerOnePoints;
        // Get the points of player Two
        playerTwoPoints = GameObject.Find("ScoreboardManager").GetComponent<ScoreboardManager>().playerTwoPoints;

        // Display the points
        this.gameObject.GetComponent<TMP_Text>().text = playerOnePoints.ToString() + " : " + playerTwoPoints.ToString();
    }

}
