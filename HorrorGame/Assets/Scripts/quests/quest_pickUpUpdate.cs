using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest_pickUpUpdate : MonoBehaviour
{
    [Tooltip("The outline object to interact with")]
    public Outline outlineableObject;
    public checkDPadUpdates updateChecker;

    playerInteractHandler interacter;
    printMessage message;
    bool questEnded = false;

    private void Start()
    {
        if (!outlineableObject.tag.Equals("interactable")) Debug.LogError("The object with outline is not interactable");
        
        interacter = GameObject.Find("player").GetComponent<playerInteractHandler>();
        message = GetComponent<printMessage>();
    }

    private void Update()
    {
        if (questEnded) return;

        if (interacter.isInteracting && outlineableObject.enabled)
        {
            message.showMessage("d-Pad updated: flash-light");
            updateChecker.updateUpgrades();
            GameObject.Destroy(outlineableObject.gameObject);
            questEnded = true;
        }
    }
}
