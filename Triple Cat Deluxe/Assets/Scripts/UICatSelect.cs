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
    public Sprite questionMark;

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
                playerOneObject.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
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
                playerTwoObject.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                Destroy(playerTwoObject.GetComponent<PolygonCollider2D>());
                playerTwoObject.AddComponent<PolygonCollider2D>();
                playerTwoObject.transform.localPosition = new Vector3(6.595f, 3f, 0f);

                playerSelecting = 0;
                break;
        }
    }

    public void randomSelectCat()
    {
        switch (playerSelecting)
        {
            case 1:
                playerOne = catDatas[Random.Range(0, catDatas.Count)];
                // Create the cat preview
                playerOneObject = GameObject.FindGameObjectWithTag("playerOne");
                playerOneObject.GetComponent<SpriteRenderer>().sprite = questionMark;
                playerOneObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                playerOneObject.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                Destroy(playerOneObject.GetComponent<PolygonCollider2D>());
                playerOneObject.AddComponent<PolygonCollider2D>();
                playerOneObject.transform.localPosition = new Vector3(-6.595f, 3f, 0f);

                playerSelecting = 2;
                break;

            case 2:
                playerTwo = catDatas[Random.Range(0, catDatas.Count)];
                // Create the cat preview
                playerTwoObject = GameObject.FindGameObjectWithTag("playerTwo");
                playerTwoObject.GetComponent<SpriteRenderer>().sprite = questionMark;
                playerTwoObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                playerTwoObject.transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
                Destroy(playerTwoObject.GetComponent<PolygonCollider2D>());
                playerTwoObject.AddComponent<PolygonCollider2D>();
                playerTwoObject.transform.localPosition = new Vector3(6.595f, 3f, 0f);

                playerSelecting = 0;
                break;
        }
    }

    public void resetCatSelect()
    {
        playerSelecting = 1;
        playerOne = null;
        playerTwo = null;
        playerOneObject.GetComponent<SpriteRenderer>().sprite = null;
        playerTwoObject.GetComponent<SpriteRenderer>().sprite = null;
    }

}
