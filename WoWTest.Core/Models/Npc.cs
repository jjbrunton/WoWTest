using System;
using Process.NET;

namespace WoWTest.Core.Models
{
    public class Npc : Creature
    {
        protected const int SummonedByOffset = 0xE * 4,
            UnitName1 = 0x17B8,
            AttackingGuidOffset = 0x0A38;

        public Npc(IProcess wowProcess, IntPtr baseAddress)
            : base(wowProcess, baseAddress)
        {
        }

        /*
        public string Name
        {
            get {
                var unitName1 = this.wowProcess.Memory.Read<IntPtr>(baseAddress + 0x1800);
                var unitName2 = this.wowProcess.Memory.Read<IntPtr>(unitName1 + 0xE0);
                return this.wowProcess.Memory.Read(unitName1 + 0xE0, Encoding.ASCII, 512);
            }
        }
        */
        public ulong AttackingGuid
        {
            get { return this.wowProcess.Memory.Read<ulong>(BaseAddress + AttackingGuidOffset); }
        }
        public ulong SummonedBy
        {
            get { return this.wowProcess.Memory.Read<ulong>(DescriptorFields + SummonedByOffset); }
        }
    }
}
