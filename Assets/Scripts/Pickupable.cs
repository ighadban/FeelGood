using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

    //Public Variables
    public Material alpha;
    public Material notAlpha;
    public float velocity;
    public Rigidbody rb;
    AudioManager audioManager;
    public AudioClip[] hitSounds;
    public string cubeTag;

    //Test Variables
    public float testvelocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocity);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
	}
	
	// Update is called once per frame
	void Update () {
        testvelocity = rb.velocity.magnitude;
	}

    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "Terrain" || col.gameObject.tag == "Cube") {
            audioManager.PlayAudio(hitSounds[Random.Range(0,hitSounds.Length)]);
            //print("test");
        }
    }
}
