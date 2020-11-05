using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Placer : MonoBehaviour
{
    ConstructType ImplType;
    // Tu ustawiasz z gui co na mape bedziesz wstawial
    public ConstructType Type
    {
        get
        {
            return ImplType;
        }
        set
        {
            ImplType = value;
            SetupData();
        }
    }    
    public GameObject[] Prefabs;
    GameObject Prefab = null;
    GameObject Visualisation = null;

    [SerializeField] private LayerMask layerMask;

    void Awake()
    {
        // Test
        Type = ConstructType.NONE;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        if (Physics.Raycast(ray, out hit, 1000 ,  layerMask, QueryTriggerInteraction.Ignore))
        {
            Tile tile = hit.collider.gameObject.GetComponent<Tile>();
            if(tile && Prefab)
            {
                if (Visualisation)
                {
                    Visualisation.transform.position = tile.transform.position;
                    Visualisation.transform.localRotation = hit.transform.localRotation * Prefab.transform.localRotation;
                }
            }
            if (tile && Prefab && Mouse.current.leftButton.isPressed )
            {
                if (tile.Type == Type && hit.transform.childCount == 0)
                {
                    GameObject Spawned = Instantiate(Prefab, hit.transform);
                    Spawned.transform.localRotation = Prefab.transform.rotation;
                    Spawned.transform.position = hit.transform.position;
                    ResetSetup();                    
                }
                else
                {
                    ResetSetup();
                }
            }
        }
    }

    void SetupData()
    { 
        if( Type == ConstructType.NONE )
        {
            return;
        }
        foreach(GameObject Obj in Prefabs)
        {
            if( Obj.GetComponent<Wall>().Type == Type)
            {
                Prefab = Obj;
                Visualisation = Instantiate(Prefab);
                return;
            }
        }
    }

    public void ResetSetup()
    {
        Type = ConstructType.NONE;
        Prefab = null;
        if (Visualisation)
        {
            Destroy(Visualisation);
            Visualisation = null;
        }
        Cursor.visible = true;
    }
}
