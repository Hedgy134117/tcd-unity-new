using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreboardLabel : MonoBehaviour {

    public string playerOne;
    public string playerTwo;

    private void Start()
    {
        // Get the name of the cat for player One
        playerOne = GameObject.FindGameObjectWithTag("playerOne").GetComponent<CatSetter>().catData.catName;
        // Get the name of the cat for player Two
        playerTwo = GameObject.FindGameObjectWithTag("playerTwo").GetComponent<CatSetter>().catData.catName;

        this.gameObject.GetComponent<TMP_Text>().text = playerOne.ToUpper() + " vs " + playerTwo.ToUpper();
    }

}
