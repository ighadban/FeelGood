using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    //Public Variables
    public float spawnTime;
    private float spawnRate;
    public float moveSpeed;
    public GameObject cube;
    PickupObject player;
    public GameObject[] rallyPoints;
    private int index = 1;

    public float timer = 15.0f;


	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupObject>();
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0.0f) {
            SpawnCubes();
        }

        transform.LookAt(player.transform.position);

        Movement(rallyPoints);

	}

    void Movement(GameObject[] points) {
        transform.position = Vector3.MoveTowards(transform.position, points[index].transform.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, points[index].transform.position) < 1.0) {

            index++;

            if (index == 4) {
                index = 0;
            }
        }
    }

    void SpawnCubes() {

        if (Time.time > spawnRate) {
            Instantiate(cube, transform.position, transform.rotation);
            spawnRate = spawnTime + Time.time;
        }
    }
}
