using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionMenu;

    public void Resume()
    {
        gameObject.SetActive(false);
    }

    public void OnClickOption()
    {
        optionMenu.SetActive(true);
    }

    public void OnClickExit()
    {
        //TODO go to menu
    }
}
