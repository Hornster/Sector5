using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common.Enums
{
    /// <summary>
    /// Defines types of responses of responses shown in the console.
    /// Colors are assignable and configurable for each enum in
    /// Prefabs->SO->UI->ConsoleColorsSO Scriptable Object.
    /// </summary>
    public enum ConsoleOutputType
    {
        Regular,
        Error,
        Positive,
        Warning
    }
}
