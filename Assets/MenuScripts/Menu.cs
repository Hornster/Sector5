using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject newGamePanel;


    public void OnClickNewGame()
    {
        newGamePanel.SetActive(true);
    }

    public void OnClickOption()
    {
        optionPanel.SetActive(true);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
