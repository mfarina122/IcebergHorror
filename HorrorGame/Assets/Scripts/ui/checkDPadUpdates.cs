using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDPadUpdates : MonoBehaviour
{
    public GameObject lockedSimble;
    [HideInInspector]
    public bool isUpdate=false;

    public void updateUpgrades() { isUpdate = true; lockedSimble.active = false; }
    
}
