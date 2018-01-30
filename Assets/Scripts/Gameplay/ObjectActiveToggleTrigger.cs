using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveToggleTrigger : MonoBehaviour {
    public GameObject[] m_objects;
    public bool m_enableOnTriggerEnter = false;
    public string tagTrigger = "Player";

    void OnTriggerEnter (Collider coll)
    {
        if (coll.tag == tagTrigger)
        {
            foreach(GameObject obj in m_objects)
            {
                obj.SetActive(m_enableOnTriggerEnter);
            }
        }
    }
}
