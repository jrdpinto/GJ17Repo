using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Transform camTransform_;
    [SerializeField]
    public float maxDistance_ = 3.0f;
    [SerializeField]
    public float speed_ = 2.5f;

    private Vector3 originalPos_;
    private Vector3 direction_;
    private bool drifting_ = true;

	// Use this for initialization
	void Start ()
    {
        originalPos_ = camTransform_.localPosition;
        randomiseDirection();
        //Debug.Log("Original position_: "+originalPos_);
	}

    void randomiseDirection()
    {
        direction_ = Random.insideUnitSphere;
        direction_.x = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 currentPos = camTransform_.localPosition;
        float distanceTravelled = (currentPos - originalPos_).magnitude;
        if (drifting_ && distanceTravelled >= maxDistance_)
        {
            direction_ = (originalPos_ - currentPos).normalized;
            drifting_ = false;
            //Debug.Log("Returning to origin.");
        }
        else if (!drifting_ && distanceTravelled <= 0.1)
        {
            // Camera has returned to original position. Start drifting again.
            randomiseDirection();
            drifting_ = true;
            //Debug.Log("Drifting.");
        }

        // Move camera along offset
        camTransform_.localPosition += direction_ * (speed_*Time.deltaTime);
	}
}
