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
    [SerializeField]
    float rotationStep_ = 90.0f;
    [SerializeField]
    float rotationLimit_ = 90.0f;

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

    Vector3 m_initialEulerDirection;

	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
        m_startRotation = transform.localRotation;
        m_endRotation = transform.localRotation;
        m_initialEulerDirection = transform.localEulerAngles;

        m_initialEulerDirection = CorrectVectorRange(m_initialEulerDirection);

        Debug.Log("Current direction: " + transform.forward);
    }
	
	// Update is called once per frame
	void Update () {
        transform.localRotation = m_endRotation;// Quaternion.Lerp(m_startRotation, m_endRotation, m_rotationTimer);
        m_rotationTimer += m_rotationSpeed * Time.deltaTime;

        Vector3 velocity = transform.forward * m_moveSpeed;
        velocity.y = m_rigidbody.velocity.y;
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
        Vector2 shotPos2d = new Vector2(shotPos.x, shotPos.z);
        Vector3 position = transform.position;
        Vector2 actorPos2D = new Vector2(position.x, position.z);

        if (Vector2.Distance(actorPos2D, shotPos2d) <= m_maxRadiusToChangeDirection)
        {
            // Determine the angle between the messenger and the shot
            Vector2 shotDirection = shotPos2d - actorPos2D;
            shotDirection.Normalize();
            Vector2 direction2D;
            direction2D.x = transform.forward.x;
            direction2D.y = transform.forward.z;
            float signedAngle = Vector2.SignedAngle(shotDirection, direction2D);
            //Debug.Log("Shot direction: "+ shotDirection + " Direction: " + transform.forward + " Shot angle: " + angle);
            //Debug.Log("Angle: " + signedAngle);

            // Determine rotation
            float angle = Mathf.Abs(signedAngle);
            float rotation = 0.0f;
            if (angle <= 130.0f)
            {
                // Negate rotation as the messenger needs to rotate in the opposite direction of the shot
                rotation = -(Mathf.Sign(signedAngle) * rotationStep_);
            }

            Debug.Log(angle);
            Debug.Log(rotation);

            Vector3 eulerRotation = CorrectVectorRange(m_endRotation.eulerAngles);
            eulerRotation.y += rotation;
            float rotationCap = 90;
            if (eulerRotation.y < m_initialEulerDirection.y - rotationCap)
                eulerRotation.y = m_initialEulerDirection.y - rotationCap;
            else if (eulerRotation.y > m_initialEulerDirection.y + rotationCap)
                eulerRotation.y = m_initialEulerDirection.y + rotationCap;

            m_endRotation = Quaternion.Euler(eulerRotation);
        }
    }

    Vector3 CorrectVectorRange(Vector3 vec)
    {
        if (vec.y >= 180)
        {
            vec.y -= 360;
        }
        else if (vec.y <= -180)
        {
            vec.y += 360;
        }

        return vec;
    }

    void OnCollisionEnter(Collision col)
    {
        switch (col.gameObject.tag)
        {
            case ("PlayAreaBarrier"):
                m_endRotation = Quaternion.Euler(m_initialEulerDirection);
                break;
            default: break;
        }  
    }

    void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case ("Death"):
                Kill();
                break;
            default: break;
        }
    }
}
