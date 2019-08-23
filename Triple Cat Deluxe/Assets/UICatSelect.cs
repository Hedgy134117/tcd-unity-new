using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICatSelect : MonoBehaviour {

    public int playerSelecting = 1;
    public CatData playerOne;
    public CatData playerTwo;
    private GameObject playerOneObject;
    private GameObject playerTwoObject;

    public List<CatData> catDatas;

    // Put object in dont destroy on load
    private static UICatSelect catManagerInstance;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (catManagerInstance == null)
        {
            catManagerInstance = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void selectCat(CatData cat)
    {
        switch (playerSelecting)
        {
            case 1:
                playerOne = cat;
                // Create the cat preview
                playerOneObject = GameObject.FindGameObjectWithTag("playerOne");
                playerOneObject.GetComponent<SpriteRenderer>().sprite = playerOne.sprite;
                playerOneObject.transform.localScale = playerOne.size;
                Destroy(playerOneObject.GetComponent<PolygonCollider2D>());
                playerOneObject.AddComponent<PolygonCollider2D>();
                playerOneObject.transform.localPosition = new Vector3(-6.595f, 3f, 0f);

                playerSelecting = 2;
                break;

            case 2:
                playerTwo = cat;
                // Create the cat preview
                playerTwoObject = GameObject.FindGameObjectWithTag("playerTwo");
                playerTwoObject.GetComponent<SpriteRenderer>().sprite = playerTwo.sprite;
                playerTwoObject.transform.localScale = playerTwo.size;
                Destroy(playerTwoObject.GetComponent<PolygonCollider2D>());
                playerTwoObject.AddComponent<PolygonCollider2D>();
                playerTwoObject.transform.localPosition = new Vector3(6.595f, 3f, 0f);

                playerSelecting = 0;
                break;
        }
    }

}
