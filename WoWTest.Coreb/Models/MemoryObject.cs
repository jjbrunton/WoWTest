using System;

namespace WoWTestConsole.Models
{
    public abstract class MemoryObject
    {
        protected readonly IntPtr baseAddress;

        protected MemoryObject(IntPtr baseAddress)
        {
            this.baseAddress = baseAddress;
        }

        public IntPtr BaseAddress => this.baseAddress;
    }
}
