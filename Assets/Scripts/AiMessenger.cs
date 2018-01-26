using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AiMessenger : Shootable {
    [SerializeField]
    float m_moveSpeed = 5;
    [SerializeField]
    float m_rotationSpeed = 1;
    [SerializeField]
    float m_maxRadiusToChangeDirection = 2;

    public float shotAreaOfEffectRadius {  get { return m_maxRadiusToChangeDirection; } }

    Rigidbody m_rigidbody;

    Quaternion m_startRotation;
    Quaternion m_setEndRotation;

    Quaternion m_endRotation
    {
        get
        {
            return m_setEndRotation;
        }
        set
        {
            m_startRotation = transform.localRotation;
            m_rotationTimer = 0;
            m_setEndRotation = value;
        }
    }
    float m_rotationTimer = 1;

    Vector3 m_initialEularDirection;

	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
        m_startRotation = transform.localRotation;
        m_endRotation = transform.localRotation;
        m_initialEularDirection = transform.localEulerAngles;
    }
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = m_endRotation;// Quaternion.Lerp(m_startRotation, m_endRotation, m_rotationTimer);
        m_rotationTimer += m_rotationSpeed * Time.deltaTime;

        Vector3 velocity = new Vector3(m_moveSpeed, 0, 0);
        velocity = transform.localRotation * velocity;
        m_rigidbody.velocity = velocity;

       /* if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 pos = transform.position;
            pos.z -= 1;
            ShotAt(pos);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 pos = transform.position;
            pos.z += 1;
            ShotAt(pos);
        }*/
    }

    public override void ShotAt(RaycastHit hit)
    {
        base.ShotAt(hit);

        Vector3 shotPos = hit.point;
        Vector2 shotPos2d = new Vector2(shotPos.z, shotPos.x);
        Vector3 position = transform.position;
        Vector2 actorPos2D = new Vector2(position.z, position.x);

        if (Vector2.Distance(actorPos2D, shotPos2d) <= m_maxRadiusToChangeDirection)
        {
            // We need to change direction
            Vector2 relativeShotPos = shotPos2d - actorPos2D;

            float rotationModifier = 90;
            if (relativeShotPos.x > 0)
            {
                rotationModifier *= -1;
            }

            Vector3 eularRotation = m_endRotation.eulerAngles;
            eularRotation.y += rotationModifier;

            float rotationCap = 90;
            if (eularRotation.y < m_initialEularDirection.y - rotationCap)
                eularRotation.y = m_initialEularDirection.y - rotationCap;
            else if (eularRotation.y > m_initialEularDirection.y + rotationCap)
                eularRotation.y = m_initialEularDirection.y + rotationCap;

            m_endRotation = Quaternion.Euler(eularRotation);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        m_endRotation = Quaternion.Euler(m_initialEularDirection);
    }
}
