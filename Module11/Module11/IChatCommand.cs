using System;
using System.Collections.Generic;
using System.Text;

namespace Module11
{
    public interface IChatCommand
    {
        bool CheckMessage(string message);
    }
}
