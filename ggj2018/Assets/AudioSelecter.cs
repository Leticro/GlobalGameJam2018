using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelecter : MonoBehaviour {
    public AudioClip[] songs;
    AudioSource aud;
	// Use this for initialization
	void Start () {
        aud = GetComponent<AudioSource>();

        aud.clip = songs[Random.Range(0, songs.Length - 1)];
        aud.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
