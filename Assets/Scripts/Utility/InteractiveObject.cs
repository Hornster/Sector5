using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour, IUseable
{
    [SerializeField]
    private int id;

    public int Id { get => id; private set => id = value; }

    public virtual void Use()
    {

    }
}
