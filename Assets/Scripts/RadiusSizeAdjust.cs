using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RadiusSizeAdjust : MonoBehaviour {
    [SerializeField]
    AiMessenger messenger;

	// Use this for initialization
	void Update () {
        float radius = messenger.shotAreaOfEffectRadius;
        transform.localScale = new Vector3(radius * 2, radius * 2, 1);
    }
}
