using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractHandler : MonoBehaviour
{
    public Camera playerCamera;
    [Space,Header("Settings")]
    [Tooltip("max distance witch player can interact with objects")]
    public float maxDistance;
    public KeyCode interactionKey;
    [HideInInspector]
    public bool isInteracting = false;

    private GameObject selectedDoor=null;
    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, maxDistance))
        {
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward, Color.red);
            
            if (hit.transform.tag.Equals("interactable"))
            {
                selectedDoor = hit.transform.gameObject;
                selectedDoor.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(interactionKey)) isInteracting = true;
                if (Input.GetKeyUp(interactionKey)) isInteracting = false;
            }
            else { if (selectedDoor != null) selectedDoor.GetComponent<Outline>().enabled = false; }
        }
        else { if (selectedDoor != null) selectedDoor.GetComponent<Outline>().enabled = false; }

        if (Input.GetKeyUp(interactionKey)) isInteracting = false;
    }
}
