using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Logic.Data;
using JetBrains.Annotations;

namespace Assets.Scripts.Logic.Commands.Interpreter
{
    interface ICommandInterpreter
    {
        (bool, Command) Interpret(List<string> input, [NotNull] Command command);
    }
}
