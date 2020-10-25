using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField]
    private Resource navigationCoords;
    [SerializeField]
    private Resource scrapmetal;
    [SerializeField]
    private Resource circuits;

    [SerializeField]
    private Drone drone1;

    public Resource NavigationCoords { get => navigationCoords; set => navigationCoords = value; }
    public Resource Scrapmetal { get => scrapmetal; set => scrapmetal = value; }
    public Resource Circuits { get => circuits; set => circuits = value; }
}
