using System;
using System.Collections.Generic;
using System.Text;

namespace Module11
{
    public class CommandParser
    {
        private List<IChatCommand> Command;

        public CommandParser()
        {
            Command = new List<IChatCommand>();
        }
    }
}
