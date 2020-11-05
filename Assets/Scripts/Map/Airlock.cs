using UnityEngine;

public class Airlock : InteractiveObject
{
    [SerializeField]
    private bool isOpen;
    [SerializeField]
    private GameObject airlockObject;

    public bool IsOpen { get => isOpen; private set => isOpen = value; }
    public GameObject AirlockObject { get => airlockObject; private set => airlockObject = value; }

    public void Set(int id, GameObject obj, bool isOpen)
    {
        this.isOpen = isOpen;
        this.airlockObject = obj;
        this.Initialize(id, CommandReceivers.Airlock);
    }

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
