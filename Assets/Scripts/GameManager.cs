using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject[] currentCubes;
    public bool spawnCubes = true;
    public float maxCubes = 60;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape)) {
            SceneManager.LoadScene("mainmenu");
        }

        if (currentCubes.Length >= maxCubes) {
            spawnCubes = false;
        }

        currentCubes = GameObject.FindGameObjectsWithTag("Cube");
	}
}
