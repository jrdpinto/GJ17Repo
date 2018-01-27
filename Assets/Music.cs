using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour {

    new AudioSource audio;
    public AudioClip musicStart;
	public AudioClip musicLoop;


    private static Music instance = null;
    public static Music Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        } else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
	{
        audio = GetComponent<AudioSource> ();
        audio.loop = true;

        StartCoroutine(playEngineSound());
	}

	IEnumerator playEngineSound()
	{
		audio.clip = musicStart;
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		audio.clip = musicLoop;
		audio.Play();
	}
}
