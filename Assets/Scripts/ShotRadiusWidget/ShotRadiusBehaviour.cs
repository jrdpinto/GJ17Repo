using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotRadiusBehaviour : MonoBehaviour {

    public GameObject messenger_;
    
    // Update is called once per frame
    void FixedUpdate() {
        transform.position = messenger_.transform.position;
    }
}
