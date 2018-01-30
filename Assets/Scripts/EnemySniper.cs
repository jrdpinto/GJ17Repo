using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySniper : Sniper {
    [SerializeField]
    float m_timeTillShotIsFired = 5;
    [SerializeField]
    UnityEngine.UI.Text countdownText;

    AiMessenger m_target = null;
    float m_shotCountdownTimer;
    Renderer m_renderer;

    Quaternion m_startRotation, m_endRotation;
    float m_rotationLerpTimer = 0;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        m_renderer = GetComponent<Renderer>();

        m_startRotation = transform.rotation;
        m_endRotation = m_startRotation;
    }
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        if (m_target && m_target.gameObject.activeSelf && m_target.state != AiMessenger.MessengerState.dead)
        {
            Vector3 directionToTarget = (m_target.transform.position - transform.position).normalized;
            m_shotCountdownTimer -= Time.deltaTime;

            m_endRotation = Quaternion.LookRotation(directionToTarget);

            // Rotate the model to face the target
            transform.rotation = Quaternion.Lerp(m_startRotation, m_endRotation, m_rotationLerpTimer);// Quaternion.LookRotation(directionToTarget);

            // Enough time has elapsed, fire at the target
            if (m_shotCountdownTimer <= 0)
            {
                Vector3 shotDirection = directionToTarget;
                Ray ray = new Ray(transform.position, shotDirection);
                Shoot(ray);
                ResetTimer();
            }

            m_rotationLerpTimer += Time.deltaTime;
        }
        else
        {
          // Lost the target
            ResetTimer();
        }

        if (countdownText)
        {
            countdownText.gameObject.SetActive(m_target && m_target.gameObject.activeSelf && m_target.state != AiMessenger.MessengerState.dead);

            float time = m_shotCountdownTimer;
            if (time < 0)
                time = 0;
            countdownText.text = string.Format("{0:f2}", time);
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

    void OnTriggerEnter(Collider coll)
    {
        AiMessenger messenger = coll.gameObject.GetComponent<AiMessenger>();

        if (!m_target && messenger && messenger.state != AiMessenger.MessengerState.dead)
        {
            m_target = messenger;
        }
    }
}
