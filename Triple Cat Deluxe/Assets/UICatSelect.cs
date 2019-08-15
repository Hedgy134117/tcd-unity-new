using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICatSelect : MonoBehaviour {

    public int playerSelecting = 1;
    public CatData playerOne;
    public CatData playerTwo;

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
                playerSelecting = 2;
                break;

            case 2:
                playerTwo = cat;
                playerSelecting = 0;
                break;
        }
    }

}
