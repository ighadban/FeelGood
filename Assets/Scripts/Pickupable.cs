using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

    //Public Variables
    public Material alpha;
    public Material notAlpha;
    public Material buildMaterial;
    public float velocity;
    public Rigidbody rb;
    AudioManager audioManager;
    MeshRenderer meshRenderer;
    public AudioClip[] hitSounds;
    public string cubeTag;

    public bool beenPickedUp = false;
    public bool fixedBlock = false;

    //Test Variables
    public float testvelocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();
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

        if (col.gameObject.tag == "Cube" && beenPickedUp && col.gameObject.GetComponent<Pickupable>().beenPickedUp) {
            rb.isKinematic = true;
            col.gameObject.GetComponent<Pickupable>().rb.isKinematic = true;
            meshRenderer.material = buildMaterial;
            col.gameObject.GetComponent<Pickupable>().meshRenderer.material = col.gameObject.GetComponent<Pickupable>().buildMaterial;
            fixedBlock = true;
            col.gameObject.GetComponent<Pickupable>().fixedBlock = true;
        }
    }
}
