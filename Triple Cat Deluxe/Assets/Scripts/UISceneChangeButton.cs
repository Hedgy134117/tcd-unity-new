using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneChangeButton : MonoBehaviour {

    private ModeManager modeManager;

	public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void LoadGameScene()
    {
        if (GameObject.Find("ModeManager").GetComponent<ModeManager>() != null)
        {
            modeManager = GameObject.Find("ModeManager").GetComponent<ModeManager>();
        }
        else
        {
            SceneManager.LoadScene("_Game", LoadSceneMode.Single);
            return;
        }
        SceneManager.LoadScene(modeManager.getScene(), LoadSceneMode.Single);
    }
}
