using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : MonoBehaviour {

    //Public Variables
    public Material alpha;
    public Material notAlpha;
    public float velocity;
    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
