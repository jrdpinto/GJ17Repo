using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Services : MonoBehaviour {

    static Services instance;

    private void Awake()
    {
        if (instance)
        {
            Debug.LogError("Services already loaded", this);
            return;
        }
        instance = this;
    }

    public static void Initialise()
    {
        if (instance) return;
        SceneManager.LoadScene("Services", LoadSceneMode.Additive);
    }
}
