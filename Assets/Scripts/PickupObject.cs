using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {

    //Public Variables
    Camera mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance = 3;

	// Use this for initialization
	void Start () {
        mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        if (carrying)
        {
            Carry(carriedObject);
            CheckDrop();
        } else
        {
            Pickup();
        }

        distance += Input.GetAxis("Mouse ScrollWheel") * 1.0f;

        distance = Mathf.Clamp(distance, 1.5f, 5.0f);
	}

    void Carry(GameObject o) {
        
        o.transform.position = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * 5);

    }

    void Pickup() {
        if (Input.GetKeyDown(KeyCode.E)) {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if (p != null) {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    void CheckDrop() {
        if (Input.GetKeyDown(KeyCode.E)) {
            DropObject();
        }
    }

    void DropObject() {
        carrying = false;
        carriedObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
        distance = 3.0f;
    }
}
