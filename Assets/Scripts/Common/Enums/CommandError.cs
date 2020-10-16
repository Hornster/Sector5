﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Common.Enums
{
    public enum CommandError
    {
        NoError,
        ParseErrorIncorrectCommandType,
        ParseErrorIncorrectCommandReceiver,
        ParseErrorIncorrectReceiverID,
        ParseErrorIncorrectCommandArgs
    }
}
