using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public playerInteractHandler interacter;
    [Tooltip("the object that can get highlited")]
    public Outline outlineableObject;
    [Space,Header("Settings")]
    public Animator doorAnimator;
    public string name_animationOn;
    public string name_animationOff;
    [Space]
    public bool isOn = false;
    void Update()
    {
        if (interacter.isInteracting && outlineableObject.enabled)
        {
            interacter.isInteracting = false;
            if (!isOn)
            {
                doorAnimator.Play(name_animationOn);
                isOn = true;
            }
            else
            {
                doorAnimator.Play(name_animationOff);
                isOn = false;
            }
        }
    }
}
