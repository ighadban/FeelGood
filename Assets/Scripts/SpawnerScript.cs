using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour {

    //Public Variables
    GameManager gameManager;
    public float spawnTime;
    private float spawnRate;
    public float moveSpeed;
    public GameObject cube;
    PickupObject player;
    public GameObject[] rallyPoints;
    private int index = 1;
    public string spawnTag;

    public float timer = 15.0f;


	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PickupObject>();
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0.0f && gameManager.spawnCubes) {
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
            //spawnedCube.GetComponent<Pickupable>().cubeTag = spawnTag;
            spawnRate = spawnTime + Time.time;
        }
    }
}
