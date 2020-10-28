using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class DroneManager : Singleton<DroneManager>
    {
        [SerializeField]
        private List<Drone> drones;

        public List<Drone> Drones { get => drones; }

        public Drone GetAirlockById(int id)
        {
            for (int i = 0; i < drones.Count; i++)
            {
                if (drones[i].DroneId == id)
                {
                    return drones[i];
                }
            }

            return null;
        }
    }
}
