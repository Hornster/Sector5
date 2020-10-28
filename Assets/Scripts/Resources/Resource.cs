using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Resource
{
    [SerializeField]
    private string resourceName;
    [SerializeField]
    private float amount;

    public string ResourceName { get => resourceName; private set => resourceName = value; }
    public float Amount { get => amount; private set => amount = value; }
    public event Action<float> OnValueChange = delegate{};

    public void AddResource(float value)
    {
        float newValue = Mathf.Clamp(Amount + value, 0, float.MaxValue);

        if(newValue != Amount)
        {
            Amount = newValue;
            OnValueChange(Amount);
        }
    }
}
