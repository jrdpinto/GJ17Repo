using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Shootable {

    AiMessenger[] messengers;
   
	// Use this for initialization
	protected virtual void Start () {
        messengers = GameObject.FindObjectsOfType<AiMessenger>();
    }

    // Update is called once per frame
    protected virtual void Update () {
		
	}

    protected virtual void Shoot(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            foreach (AiMessenger messenger in messengers)
            {
                messenger.ShotAt(hit);
            }
        }
    }
}
