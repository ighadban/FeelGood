using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject[] rallyPoints;
    private int index = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        MoveCamera(rallyPoints);

        Cursor.visible = true;
	}

    void MoveCamera(GameObject[] points) {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, points[index].transform.position, 0.4f * Time.deltaTime);

        if (Vector3.Distance(Camera.main.transform.position, points[index].transform.position) < 0.2f) {
            index++;

            if (index == 2) {
                index = 0;
            }
        }
    }

    public void StartGame() {
        SceneManager.LoadScene("testLevel");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
