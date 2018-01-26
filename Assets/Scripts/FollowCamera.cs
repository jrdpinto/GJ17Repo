using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    [SerializeField]
    Transform m_target;
    [SerializeField]
    float m_lerpSpeed = 1;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(position.x, m_target.transform.position.x, Time.deltaTime * m_lerpSpeed);
        transform.position = position;
    }
}
