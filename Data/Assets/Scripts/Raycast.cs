using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        float Distance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, (forward), out hit)) {
            Distance = hit.distance;
            print (Distance + " " + hit.collider.gameObject.name);
        }
	}
}
