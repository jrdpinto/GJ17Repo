using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Sniper {
    Camera cam;
    bool m_canShoot = true;
    ReticalController retical;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        cam = Camera.main;
        retical = GameObject.FindObjectOfType<ReticalController>();
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();

        if (Input.GetMouseButtonDown(0) && m_canShoot)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Shoot(ray);
            StartCoroutine(Reload(2));
        }
    }

    public override void Kill()
    {
        // Can't be killed
    }

    IEnumerator Reload(float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);

        m_canShoot = true;
    }

    protected override void Shoot(Ray ray)
    {
        base.Shoot(ray);
        m_canShoot = false;

        // Edit mouse cursor
        StartCoroutine(retical.ShootCursorAnim());
    }
}
