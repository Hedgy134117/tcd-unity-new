using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlatformManager : MonoBehaviour {

	public PlatformData platform;

    public Image previewImage;
    public TMP_Text previewText;

    // Put object in dont destroy on load
    private static PlatformManager platformManagerInstance;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (platformManagerInstance == null)
        {
            platformManagerInstance = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    private void LateUpdate()
    {
        if (SceneManager.GetActiveScene().name == "_Game")
        {
            GameObject.FindGameObjectWithTag("platform").GetComponent<PlatformSetter>().platformData = platform;
        }
    }

    public void changePlatform(PlatformData newPlatform)
    {
        platform = newPlatform;
    }

    public void changePreview(Sprite image)
    {
        previewImage.sprite = image;
        previewText.text = platform.platformName;
    }

}
