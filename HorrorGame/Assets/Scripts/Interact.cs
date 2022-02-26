using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Tooltip("the entity that will interact with this object")]
    public playerInteractHandler interacter;

    [Space,Tooltip("the object that can get highlited"),SerializeField]
    public Outline outlineableObject;

    [Space,Header("Settings")]
    [Tooltip("the animator of this object")]
    public Animator animator;
    [Tooltip("the name of the animation that will perform when opened")]
    public string name_animationOn;
    [Tooltip("the name of the animation that will perform when closed")]
    public string name_animationOff;

    [Space]
    [Tooltip("the initial state of this object")]
    public bool isOn = false;

    [HideInInspector]
    public bool interactableFlag = true;
    bool canAnimate = false;
 
    private void Start()
    {
        if (animator != null &&
            name_animationOn != "" &&
            name_animationOff != "")
        { canAnimate = true; }

        if (!outlineableObject.tag.Equals("interactable")) { Debug.LogError("The object " + transform.name + " isn't tagged interactable. Can't perform <interact.cs>"); }
        if (outlineableObject == null) { Debug.LogError("The object " + transform.name + " Doesn't have any <Outline.cs>. Can't perform <interact.cs>"); }
        if (interacter == null) { Debug.LogError("The object " + transform.name + " Doesn't have any <playerInteractHandler.cs>. Can't perform <interact.cs>"); }
    }

    void Update()
    {
        if (interactableFlag)
        {
            if (interacter.isInteracting && outlineableObject.enabled)
            {
                interacter.isInteracting = false;
                if (!animator.GetBool("isInteracting"))
                {
                    if (!isOn)
                    {
                        if (canAnimate)
                        {
                            animator.Play(name_animationOn);
                            animator.SetBool("isInteracting", true);
                        }
                        isOn = true;
                    }
                    else
                    {
                        if (canAnimate)
                        { 
                            animator.Play(name_animationOff);
                            animator.SetBool("isInteracting", true);
                        }
                        isOn = false;
                    }
                }
            }
        }
    }
}
