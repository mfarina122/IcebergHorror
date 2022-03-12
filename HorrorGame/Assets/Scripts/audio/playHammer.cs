using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playHammer : MonoBehaviour
{
    public AudioSource src;
    void Awake(){
        src.Play();
    }
}
