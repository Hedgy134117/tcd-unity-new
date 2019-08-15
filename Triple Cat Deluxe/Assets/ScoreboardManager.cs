using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardManager : MonoBehaviour {

    public int playerOnePoints;
    public int playerTwoPoints;

    // Put object in dont destroy on load
    private static ScoreboardManager scoreboardManagerInstane;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (scoreboardManagerInstane == null)
        {
            scoreboardManagerInstane = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }
}
