using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    AiMessenger[] m_messengers;
    [SerializeField]
    Text winText;
    [SerializeField]
    Text gameOverText;
    public bool m_playerWon = false;

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
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }

        bool gameOver = true;
        foreach (AiMessenger messenger in m_messengers)
        {
            if (messenger.state != AiMessenger.MessengerState.dead)// messenger.gameObject.activeSelf)
            {
                gameOver = false;
                break;
            }
        }

        if (m_playerWon)
        {
            winText.gameObject.SetActive(true);
        }
        else if (gameOver)
        {
            gameOverText.gameObject.SetActive(true);
        }
	}
}
