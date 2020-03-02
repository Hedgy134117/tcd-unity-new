using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public string sceneName;

    // Put object in dont destroy on load
    private static ModeManager modeManagerInstance;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (modeManagerInstance == null)
        {
            modeManagerInstance = this;
        }
        else
        {
            Object.Destroy(this.gameObject);
        }
    }

    public void changeScene(string scene)
    {
        sceneName = scene;
    }

    public string getScene()
    {
        return sceneName;
    }
}
