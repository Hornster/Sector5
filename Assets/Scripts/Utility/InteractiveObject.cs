using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IUseable
{
    [SerializeField]
    private int id;
    [SerializeField]
    private CommandReceivers commandReceiverType = CommandReceivers.None;

    public int Id { get => id; private set => id = value; }
    public CommandReceivers CommandReceiverType { get => commandReceiverType; private set => commandReceiverType = value; }

    public void Initialize(int id, CommandReceivers type)
    {
        Id = id;
        CommandReceiverType = type;
    }

    public virtual void Use()
    {

    }
}
