using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class pickUp_book : MonoBehaviour
{
    [Tooltip("The outline object to interact with")]
    public Outline outlineableObject;
    [Space]
    public text_book bookContent;
    [Space]
    public GameObject closeBookMessage;
    [Space]
    public KeyCode keyToCloseBook;
    [Space]
    public checkDPadUpdates updateLight;
    [Space]
    public audioPlayer audioOpen_book;
    public audioPlayer audioClose_book;

    public open_dPad dPadUser;
    GameObject dPadLight;
    TextMeshPro bookText;
    Animator bookAnimator;
    bool open = false;
    playerInteractHandler interacter;

    private void Start()
    {
        if (!outlineableObject.tag.Equals("interactable")) Debug.LogError("The object with outline is not interactable");

        bookAnimator = GetComponent<Animator>();
        interacter = GameObject.Find("player").GetComponent<playerInteractHandler>();

        bookText = GetComponentInChildren<TextMeshPro>();

        closeBookMessage.active = false;

        dPadLight = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        if (interacter.isInteracting && outlineableObject.enabled && !open)
        {
            interacter.showInteractText = false;
            open = true;

            bookText.text = bookContent.text;
            closeBookMessage.active = true;

            openBook(gameObject);
        }

        if (open)
        {
            if (Input.GetKeyDown(keyToCloseBook))
            { 
                open = false; 
                closeBookMessage.active = false; 
                openBook(gameObject); 
                interacter.showInteractText = true; }
        }
    }

    public void openBook(GameObject book)
    {
        changeBookCover(book);
        performeAnimation(open);
    }

    private void performeAnimation(bool isOpen)
    {
        if (isOpen)
            audioOpen_book.playAudio();
        else
            audioClose_book.playAudio();

        bookAnimator.Play(isOpen?"openBook":"closeBook");
        if(updateLight.isUpdate && dPadUser.enabled)
            dPadLight.active = !dPadLight.activeSelf;
    }

    public void changeBookCover(GameObject book)
    {
        Material material = book.GetComponent<MeshRenderer>().materials[1];
        transform.GetComponent<MeshRenderer>().sharedMaterials[1] = material;
    }
}
