using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerSelectingLabel : MonoBehaviour {

    public UICatSelect catManager;

    private void Start()
    {
        catManager = GameObject.Find("CatManager").GetComponent<UICatSelect>();
    }

    private void LateUpdate()
    {
        switch(catManager.playerSelecting)
        {
            case 0:
                this.GetComponent<TMP_Text>().text = "";
                break;

            case 1:
                this.GetComponent<TMP_Text>().text = "Player One";
                break;

            case 2:
                this.GetComponent<TMP_Text>().text = "Player Two";
                break;
        }
    }
}
