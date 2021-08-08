using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorInteract : MonoBehaviour
{
    public playerInteractHandler interacter;
    [Tooltip("the object that can get highlited")]
    public Outline outlineableObject;
    [Space,Header("Settings")]
    public Animator doorAnimator;
    public bool isOpen = false;
    void Update()
    {
        if (interacter.isInteracting && outlineableObject.enabled)
        {
            interacter.isInteracting = false;
            if (!isOpen)
            {
                doorAnimator.Play("doorOPEN");
                isOpen = true;
            }
            else
            {
                doorAnimator.Play("doorCLOSE");
                isOpen = false;
            }
        }
    }
}
