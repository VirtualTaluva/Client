﻿using System;
using VirtualTaluva.Protocol;

namespace VirtualTaluva.Client.Protocol
{
    public class CommandEventArgs<T> : EventArgs
        where T : AbstractCommand
    {
        private readonly T m_Command;

        public T Command { get { return m_Command; } }

        public CommandEventArgs(T c)
        {
            m_Command = c;
        }
    }
}
