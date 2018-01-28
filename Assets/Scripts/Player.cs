using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Sniper {
    [SerializeField]
    float reloadTime = 1.5f;
    [SerializeField]
    UnityEngine.UI.Text ammoCountText;
    
    bool m_canShoot = true;
    ReticalController retical;

    AudioSource shootAudio;
    AudioSource reloadAudio;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        retical = GameObject.FindObjectOfType<ReticalController>();

        AudioSource[] audioClips = GetComponents<AudioSource>();
        shootAudio = audioClips[0];
        reloadAudio = audioClips[1];
    }

    // Update is called once per frame
    protected override void Update () {
        base.Update();

        if (Input.GetMouseButtonDown(0) && m_canShoot)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Shoot(ray);
            StartCoroutine(Reload(reloadTime));
        }

        if (ammoCountText)
        {
            ammoCountText.text = string.Format("Ammo - {0}/1", m_canShoot ? 1 : 0);
        }
    }

    public override void Kill()
    {
        // Can't be killed
    }

    IEnumerator Reload(float reloadTime)
    {
        
        yield return new WaitForSeconds(reloadTime/2);
        reloadAudio.Play();
        yield return new WaitForSeconds(reloadTime/2);

        m_canShoot = true;
    }

    protected override void Shoot(Ray ray)
    {
        StartCoroutine(DelayShot(ray));

        // Edit mouse cursor
        StartCoroutine(retical.ShootCursorAnim());
    }

    IEnumerator DelayShot(Ray ray)
    {
        yield return new WaitForSeconds(0.2f);

        base.Shoot(ray);
        m_canShoot = false;
        shootAudio.Play();
    }
}
