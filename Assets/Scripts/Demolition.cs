using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Demolition : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    public bool isActive { get; set; }

    private void FixedUpdate()
    {
        if (isActive && Mouse.current.leftButton.isPressed)
        {
            ShotRaycast();
        }
    }

    private void ShotRaycast()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var ray=Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        Debug.DrawLine(mousePos, ray.direction*10, Color.red, 10.0f);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            DestroyElement(hit);
        }
    }

    private void DestroyElement(RaycastHit hit)
    {
        Debug.Log(hit.transform.gameObject.name);

        Destroy(hit.transform.gameObject);
    }
}
