using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticalController : MonoBehaviour {
    public AnimationCurve recoilAnimCurve;
    public AnimationCurve decoilAnimCurve;

    bool m_cursorAnimPlaying = false;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_cursorAnimPlaying)
            transform.position = Input.mousePosition;
    }

    public IEnumerator ShootCursorAnim()
    {
        m_cursorAnimPlaying = true;

        Vector2 initCursorPos = Input.mousePosition;
        float recoilHeight = Screen.height * 0.15f;
        float recoilTime = 0.03f;
        float decoilTime = 0.2f;
        float startTime = Time.time;

        Vector2 finalCursorPos = initCursorPos;
        finalCursorPos.y += recoilHeight;

        do
        {
            yield return null;
            
            transform.position = Vector2.Lerp(initCursorPos, finalCursorPos, recoilAnimCurve.Evaluate((Time.time - startTime) / recoilTime));
        }
        while (Time.time - startTime < recoilTime);

        transform.position = finalCursorPos;
        yield return null;

        startTime = Time.time;
        do
        {
            yield return null;

            transform.position = Vector2.Lerp(finalCursorPos, Input.mousePosition, decoilAnimCurve.Evaluate((Time.time - startTime) / decoilTime));
        }
        while (Time.time - startTime < decoilTime);

        m_cursorAnimPlaying = false;
    }
}
