using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HUDController : MonoBehaviour
{
    private PgkControlls controlls = null;

    [SerializeField] private BuildingMenu buildingMenu;

    private void Awake()
    {
        controlls = new PgkControlls();
    }

    private void OnEnable()
    {
        controlls.Menu.Esc.started += OnEscape;
        controlls.Menu.Esc.Enable();
    }

    private void OnDisable()
    {
        controlls.Menu.Esc.started -= OnEscape;
        controlls.Menu.Esc.Disable();
    }

    private void OnEscape(InputAction.CallbackContext context)
    {
        buildingMenu.OnDeactive();
    }
}
