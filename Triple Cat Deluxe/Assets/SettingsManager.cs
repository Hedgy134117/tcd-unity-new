using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour {

    public int pointsToWin;
    public float catSize;
    public float catSpeed;
    public float catJumps;
    public bool thinPlatform;

    public bool settingsApplied;

    // Put object in dont destroy on load
    private static SettingsManager settingsManagerInstance;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (settingsManagerInstance == null)
        {
            settingsManagerInstance = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }

        pointsToWin = 20;
        catSize = 1;
        catSpeed = 1;
        catJumps = 1;
    }

    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "_Game" && !settingsApplied)
        {
            GameObject playerOne = GameObject.FindGameObjectWithTag("playerOne");
            GameObject playerTwo = GameObject.FindGameObjectWithTag("playerTwo");
            GameObject platform = GameObject.FindGameObjectWithTag("platform");

            playerOne.transform.localScale *= catSize;
            playerTwo.transform.localScale *= catSize;

            playerOne.GetComponent<CatMovement>().moveForce *= catSpeed;
            playerTwo.GetComponent<CatMovement>().moveForce *= catSpeed;

            playerOne.GetComponent<CatMovement>().jumpForce *= catJumps;
            playerTwo.GetComponent<CatMovement>().jumpForce *= catJumps;

            if (thinPlatform)
            {
                platform.transform.localScale = new Vector3(platform.transform.localScale.x, platform.transform.localScale.y / 2, platform.transform.localScale.z);
            }

            settingsApplied = true;
        }
        else if (SceneManager.GetActiveScene().name == "CardDraw")
        {
            settingsApplied = false;
        }
    }

    public void changeValueSlider(Slider slider)
    {
        switch(slider.gameObject.name)
        {
            case "Points To Win":
                pointsToWin = Mathf.RoundToInt(slider.value);
                break;

            case "Cat Size":
                slider.value = Mathf.Round(slider.value * 10f) / 10f;
                catSize = slider.value;
                break;

            case "Cat Speed":
                slider.value = Mathf.Round(slider.value * 10f) / 10f;
                catSpeed = slider.value;
                break;

            case "Cat Jumps":
                slider.value = Mathf.Round(slider.value * 10f) / 10f;
                catJumps = slider.value;
                break;
        }
    }

    public void changeValueToggle(Toggle toggle)
    {
        switch(toggle.gameObject.name)
        {
            case "Thin Platform":
                thinPlatform = toggle.isOn;
                break;
        }
    }

}
