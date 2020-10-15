using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractiveObject
{

    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private GameObject doorObject;

    public bool IsOpen { get => isOpen; private set => isOpen = value; }
    public GameObject DoorObject { get => doorObject; private set => doorObject = value; }

    public override void Use()
    {
        if(IsOpen == true)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    private void Open()
    {
        isOpen = true;
        DoorObject.SetActive(false);
        Debug.Log(string.Format("Doors {0} opened", Id));
    }

    private void Close()
    {
        isOpen = false;
        DoorObject.SetActive(true);
        Debug.Log(string.Format("Doors {0} closed", Id));
    }
}
