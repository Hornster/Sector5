using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public ConstructType Type { get; private set; }
    public int Price { get; private set; }
    public void SetType(ConstructType type)
    {
        Type = type;
    }

    public void SetPrice(int price)
    {
        Price = price;
    }
}
