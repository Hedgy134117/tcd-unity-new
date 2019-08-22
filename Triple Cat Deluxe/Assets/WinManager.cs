using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour {

    public CatData winner;

    private Image winnerImage;

    // Put object in dont destroy on load
    private static WinManager winManagerInstance;

    void Start () {
        DontDestroyOnLoad(this.gameObject);

        if (winManagerInstance == null)
        {
            winManagerInstance = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "WinScreen")
        {
            winnerImage = GameObject.Find("WinnerImage").GetComponent<Image>();
            winnerImage.sprite = winner.winSprite;

            Destroy(GameObject.Find("CardManager"));
            Destroy(GameObject.Find("PlatformManager"));
            Destroy(GameObject.Find("ScoreboardManager"));
            Destroy(GameObject.Find("SettingsManager"));
            Destroy(GameObject.Find("WinManager"));
            Destroy(GameObject.Find("CatManager"));
        }
    }
}



    
