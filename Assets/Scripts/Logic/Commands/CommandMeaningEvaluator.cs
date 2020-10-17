using Assets.Scripts.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Logic.Commands
{
    /// <summary>
    /// Used to check if parsed command has any sense in terms of receiver-command
    /// relationship. (For example, whether can an interface go to another room)
    /// </summary>
    public class CommandMeaningEvaluator : MonoBehaviour
    {
        public bool ValidateCommand(Command command)
        {
            
        }
    }
}
