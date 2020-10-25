using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesUIController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TMP_Text navigationCoords;
    [SerializeField]
    private TMPro.TMP_Text scrapmetal;
    [SerializeField]
    private TMPro.TMP_Text circuits;

    void Start()
    {
        PlayerManager.Instance.NavigationCoords.OnValueChange += ChangeNavigationCoordsText;
        PlayerManager.Instance.Scrapmetal.OnValueChange += ChangeScrapmetalText;
        PlayerManager.Instance.Circuits.OnValueChange += ChangeCircuitsText;
    }

    private void ChangeNavigationCoordsText(float value)
    {
        navigationCoords.text = value.ToString();
    }

    private void ChangeScrapmetalText(float value)
    {
        navigationCoords.text = value.ToString();
    }

    private void ChangeCircuitsText(float value)
    {
        navigationCoords.text = value.ToString();
    }
}
