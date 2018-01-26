using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : Sniper {
    [SerializeField]
    float m_timeTillShotIsFired = 5;

    AiMessenger m_target = null;
    float m_shotCountdownTimer;

	// Use this for initialization
	protected override void Start () {
        base.Start();

        gameObject.SetActive(false);    // Enemies are disabled until they are activated by a trigger
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        if (m_target && m_target.gameObject.activeSelf)
        {
            m_timeTillShotIsFired -= Time.deltaTime;

            if (m_timeTillShotIsFired <= 0)
            {
                Vector3 shotDirection = transform.position - m_target.transform.position;
                Ray ray = new Ray(transform.position, shotDirection);
            }
        }
        else
        {
            ResetTimer();
        }
	}

    void OnEnable()
    {
        // Run popup animation
        ResetTimer();
    }

    void ResetTimer()
    {
        m_shotCountdownTimer = m_timeTillShotIsFired;
    }
}
