﻿using UnityEngine;

public class Airlock : InteractiveObject
{
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private GameObject airlockObject;

    public bool IsOpen { get => isOpen; private set => isOpen = value; }
    public GameObject AirlockObject { get => airlockObject; private set => airlockObject = value; }

    private void Start()
    {
        GetComponentInChildren<TextMesh>().text = $"A{Id.ToString()}";
    }

    public override void Use()
    {
        Toggle();
    }

    private void Toggle()
    {
        AirlockObject.SetActive(IsOpen);
        isOpen = !IsOpen;
    }
}
