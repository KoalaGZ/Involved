using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

    private GameObject raycastedObj;

    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private int rayLength = 10;

    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        float theDistance;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, forward, out hit, rayLength, layerMaskInteract.value ))
        {
            theDistance = hit.distance; 
            if (hit.collider.CompareTag("Interact"))
            {
                raycastedObj = hit.collider.gameObject;
                

                Debug.LogFormat("Distance: {0} ObjectName: {1}", theDistance, raycastedObj);
            }
        }
	}
}
