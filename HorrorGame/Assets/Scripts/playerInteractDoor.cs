using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteractDoor : MonoBehaviour
{
    public Camera camera;
    public float maxDistance;

    private GameObject selectedDoor=null;
    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, maxDistance))
        {
            Debug.DrawRay(camera.transform.position, camera.transform.forward,Color.red);

            Debug.Log(hit.transform.gameObject.name);

            if (hit.transform.tag.Equals("door"))
            {
                selectedDoor = hit.transform.gameObject;
                selectedDoor.GetComponent<Outline>().enabled = true;
            }
            else { if(selectedDoor!=null) selectedDoor.GetComponent<Outline>().enabled = false; }
        }
    }
}
