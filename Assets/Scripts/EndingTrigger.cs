using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour {

    GameManager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            //Application.Quit();
            print("you win");
            gameManager.spawnCubes = false;

            GameObject[] walls = GameObject.FindGameObjectsWithTag("Terrain");
            foreach (GameObject wall in walls) {
                Destroy(wall);
            }
        }
    }
}
