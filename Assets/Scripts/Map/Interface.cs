using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : InteractiveObject
{
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private bool isGained;
    [SerializeField]
    private float navCoordsClaim;

    public float NavCoordsReward { get => navCoordsClaim; private set => navCoordsClaim = value; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public bool IsGained { get => isGained; set => isGained = value; }
    public int DronesInRangeNumber { get; set; }

    public override void Use()
    {
        GetResources();
    }

    public void GetResources()
    {
        if (IsActive == true && isGained == false)
        {
            PlayerManager.Instance.NavigationCoords.AddResource(NavCoordsReward);
            isGained = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Drone drone = other.GetComponent<Drone>();

        if(drone != null)
        {
            DronesInRangeNumber++;

            if (IsActive == false)
            {
                IsActive = true;
            }

            Debug.Log("Dron wykryty");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Drone drone = other.GetComponent<Drone>();

        if(drone != null)
        {
            DronesInRangeNumber--;

            if(DronesInRangeNumber == 0)
            {
                IsActive = false;
            }

            Debug.Log("Dron odszedl");
        }
    }
}
