using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    [SerializeField] private List<int> levels; //TODO to activate levels

    public void OnSelectLevel(int id)
    {
        //TODO levels[id] start 
    }

    public void OnClickBack()
    {
        gameObject.SetActive(false);
    }
}
