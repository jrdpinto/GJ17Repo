using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFromFile : MonoBehaviour {

    [SerializeField] TextAsset text;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = text.text;
	}
}
