using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] currentCubes;
    public bool spawnCubes = true;
    public float maxCubes = 40;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

        if (currentCubes.Length >= maxCubes) {
            spawnCubes = false;
        }

        currentCubes = GameObject.FindGameObjectsWithTag("Cube");
	}
}
