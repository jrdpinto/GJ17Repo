using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {

    public virtual void ShotAt(RaycastHit hit)
    {
        if (hit.transform.gameObject.GetInstanceID() == gameObject.GetInstanceID())
        {
            Kill();
        }
    }

    public virtual void Kill()
    {
        // Eventually run a death animation
        gameObject.SetActive(false);
    }
}
