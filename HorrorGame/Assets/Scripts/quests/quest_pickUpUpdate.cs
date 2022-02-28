using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quest_pickUpUpdate : MonoBehaviour
{
    [Tooltip("The outline object to interact with")]
    public Outline outlineableObject;
    public checkDPadUpdates updateChecker;
    [Space]
    public audioPlayer audio;

    playerInteractHandler interacter;
    printMessage message;

    private void Start()
    {
        if (!outlineableObject.tag.Equals("interactable")) Debug.LogError("The object with outline is not interactable");
        
        interacter = GameObject.Find("player").GetComponent<playerInteractHandler>();
        message = GetComponent<printMessage>();
    }

    private void Update()
    {
        if (interacter.isInteracting && outlineableObject.enabled)
        {
            message.showMessage("d-Pad updated: flash-light");
            updateChecker.updateUpgrades();
            audio.playAudio();
            GameObject.Destroy(outlineableObject.gameObject);
            GetComponent<quest_pickUpUpdate>().enabled = false;
        }
    }
}
