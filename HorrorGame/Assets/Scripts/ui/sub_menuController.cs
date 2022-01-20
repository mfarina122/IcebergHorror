using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sub_menuController : MonoBehaviour
{
    public GameObject menu;
    bool open = false;

    void Start()
    {
        openMenu();
    }

    public void openMenu() { menu.SetActive(open); open = !open; }
}
