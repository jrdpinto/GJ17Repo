using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    [SerializeField]
    Transform m_target;
    [SerializeField]
    float m_lerpSpeed = 1;

    float distanceToTarget_;

    void Start() {
        distanceToTarget_ = m_target.position.x - transform.position.x;
    }
	
	void FixedUpdate () {
        Vector3 updatedPosition = transform.position;
        updatedPosition.x = Mathf.Lerp(transform.position.x, m_target.position.x - distanceToTarget_, Time.deltaTime * m_lerpSpeed);
        transform.position = updatedPosition;
    }
}
