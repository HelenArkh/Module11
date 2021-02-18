using System;
using System.Collections.Generic;
using System.Text;

namespace Module11
{
    public abstract class AbstractCommand : IChatCommand
    {
        public string CommandText;

        public bool CheckMessage(string message)
        {
            return CommandText == message;
        }
    }
}
