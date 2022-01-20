using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class quest_openDoor : MonoBehaviour
{
    [Header("The interactions")]
    [Tooltip("The object to interact with")]
    public Interact interactObject;

    printMessage message;
    playerInteractHandler interacter;

    private void Start()
    {
        interacter = GameObject.Find("player").GetComponent<playerInteractHandler>();
        interactObject.interactableFlag = false;
        message = GameObject.Find("quests").GetComponent<printMessage>();
    }

    private void Update()
    {
        if (interacter.isInteracting && interactObject.outlineableObject.enabled)
        {
            message.showMessage("It's stuck");
        }
    }
}
