using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour
{

    void Update()
    {
        if (transform.GetComponent<buttonHandler>().clicked)
            Application.Quit();
    }
}
