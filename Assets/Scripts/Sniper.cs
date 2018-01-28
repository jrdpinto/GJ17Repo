using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : Shootable {
    [SerializeField]
    GameObject bulletDustPrefab;

    Shootable[] m_shootables;
    ParticleSystem bulletDust;

    // Use this for initialization
    protected virtual void Start () {
        m_shootables = GameObject.FindObjectsOfType<Shootable>();

        GameObject dustParticles = GameObject.Instantiate(bulletDustPrefab, Vector3.zero, bulletDustPrefab.transform.rotation);
        bulletDust = dustParticles.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    protected virtual void Update () {
		
	}

    protected virtual void Shoot(Ray ray)
    {
        FireShot(ray);
    }

    protected void FireShot(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            foreach (Shootable shootable in m_shootables)
            {
                shootable.ShotAt(hit);
            }

            Vector3 dustPosition = hit.point;
            bulletDust.gameObject.transform.position = dustPosition;
            bulletDust.Play();
            bulletDust.GetComponent<AudioSource>().Play();
        }

    }
}
