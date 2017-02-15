﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Cube") {
            if (other.GetComponent<Pickupable>().cubeTag == "Good" && other.GetComponent<Pickupable>().rb.velocity.magnitude == 0.0f) {
                Application.Quit();
            }
        }
    }
}
