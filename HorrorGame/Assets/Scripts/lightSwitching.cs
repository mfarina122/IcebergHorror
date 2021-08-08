using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSwitching : MonoBehaviour
{
    public Interact interactObject;
    public List<Light> lights;
    void Update()
    {
        if (!interactObject.isOn)
            foreach(Light light in lights)
                light.transform.gameObject.active = true;
        else
            foreach (Light light in lights)
                light.transform.gameObject.active = false;
    }
}
