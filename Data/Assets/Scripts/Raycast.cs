using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

    private GameObject raycastedObj;

    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private int rayLength = 1;
    [SerializeField] Material material1;
    [SerializeField] Material material2;

    public Material tempMaterial = null;

    // Update is called once per frame
    void Update () {

        RaycastHit hit;
        float theDistance;
        
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, forward, out hit, rayLength, layerMaskInteract.value ))
        {
            theDistance = hit.distance; 
            if (hit.collider.CompareTag("Interact") )
            {
                if(raycastedObj == null)
                {
                    raycastedObj = hit.collider.gameObject;
                    tempMaterial = hit.collider.GetComponent<MeshRenderer>().sharedMaterial;
                    hit.collider.GetComponent<MeshRenderer>().sharedMaterial = material2;
                }
                else if(raycastedObj != hit.collider.gameObject)
                {
                    
                    raycastedObj.GetComponent<MeshRenderer>().sharedMaterial = tempMaterial;
                    raycastedObj = null;
                }
                
                Debug.LogFormat("Distance: {0} ObjectName: {1}", theDistance, raycastedObj);
            }
            else if(raycastedObj != null)
            {
                
                raycastedObj.GetComponent<MeshRenderer>().sharedMaterial = tempMaterial;
                raycastedObj = null;
            }
        }
        else if (raycastedObj != null)
        {
            
            raycastedObj.GetComponent<MeshRenderer>().sharedMaterial = tempMaterial;
            raycastedObj = null;
        }
    }
}
