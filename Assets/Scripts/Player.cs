using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Sniper {
    Camera cam;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        cam = Camera.main;
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Shoot(ray);
        }
    }
}
