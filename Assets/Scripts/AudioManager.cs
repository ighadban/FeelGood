using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    //Public variables
    public static AudioManager audioManager;
    public AudioSource audioSource;

	// Use this for initialization
	void Awake () {
        audioManager = this;
	}

    public void PlayAudio(AudioClip soundEffect) {
        audioSource.PlayOneShot(soundEffect);
    }
}
