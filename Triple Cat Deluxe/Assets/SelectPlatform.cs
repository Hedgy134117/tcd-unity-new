using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlatform : MonoBehaviour
{
    public PlatformManager platformManager;
    public PlatformData platform;
    public Sprite platformPreview;

    // Start is called before the first frame update
    void Start()
    {
        platformManager = GameObject.Find("PlatformManager").GetComponent<PlatformManager>();
    }

    public void changePlatform()
    {
        platformManager.changePlatform(platform);
    }

    public void changePreview()
    {
        platformManager.changePreview(platformPreview);
    }
}
