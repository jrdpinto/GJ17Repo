using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    AiMessenger[] m_messengers;

	// Use this for initialization
	void Start () {
        m_messengers = GameObject.FindObjectsOfType<AiMessenger>();
    }
	
	// Update is called once per frame
	void Update () {
        // Quick restarting
		if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        bool gameOver = true;
        foreach (AiMessenger messenger in m_messengers)
        {
            if (messenger.gameObject.activeSelf)
            {
                gameOver = false;
                break;
            }
        }

        if (gameOver)
        {

        }
	}
}
