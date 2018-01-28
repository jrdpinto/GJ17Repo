using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {
    [SerializeField]
    LevelManager levelManager_;

    void OnTriggerEnter()
    {
        levelManager_.m_playerWon = true;
    }

}
