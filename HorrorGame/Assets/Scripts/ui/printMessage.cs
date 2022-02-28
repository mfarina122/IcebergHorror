using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class printMessage : MonoBehaviour
{
    public Animator messageAnimator;
    public TextMeshProUGUI message;

    public void showMessage(string text)
    {
        messageAnimator.Play("displayMsg");
        message.text = text;
    }
}
