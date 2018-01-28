using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour {

    private void Awake()
    {
        Services.Initialise();
    }

    public void OpenScene(string scene)
    {
        SceneManager.LoadScene (scene);
    }

    public void CloseScene(string scene)
    {
        SceneManager.UnloadSceneAsync(scene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
