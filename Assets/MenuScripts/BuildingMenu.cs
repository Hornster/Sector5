using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildingMenu : MonoBehaviour
{
    [SerializeField] private Placer placer;
    [SerializeField] private RectTransform bulldozerIcon;
    private Demolition demolition;

    private bool demolishActivation = false;
    private bool buildingActivation = false;

    [SerializeField] private List<GameObject> buildingPanels;
    private int lastId = 0;

    private void Awake()
    {
        demolition = GetComponent<Demolition>();
    }

    private void Update()
    {
        if (bulldozerIcon.gameObject.activeSelf)
        {
            bulldozerIcon.position= Mouse.current.position.ReadValue();
        }
    }

    public void OnClickBuildingElement(int type)
    {
        OnDeactive();

        placer.Type=(ConstructType)type;
        Cursor.visible = false;
    }

    public void OnClickBuildingKind(int id)
    {
        buildingPanels[lastId].SetActive(false);
        buildingPanels[id].SetActive(true);
        lastId = id;
    }

    public void OnClickBulldozer()
    {
        bulldozerIcon.gameObject.SetActive(true);
        demolition.isActive = true;
        Cursor.visible = false;
    }

    public void OnDeactive()
    {
        bulldozerIcon.gameObject.SetActive(false);
        Cursor.visible = true;
        demolition.isActive = false;
        placer.ResetSetup();
    }
}
