using System;
using Process.NET;

namespace WoWTestConsole.Models
{
    public class Creature : WowObject
    {
        public Creature(IProcess wowProcess, IntPtr baseAddress)
            : base(wowProcess, baseAddress)
        { 
        }

        public UInt128 TargetGuid
        {
            get { return this.wowProcess.Memory.Read<UInt128>(DescriptorFields + (int)Offsets.Unit.Target); }
        }
        public int Level
        {
            get { return this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Unit.Level); }
        }
        public int CurrentHealth
        {
            get { return this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Unit.CurrentHealth); }
        }
        public int MaxHealth
        {
            get { return this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Unit.MaxHealth); }
        }
        public int CurrentMana
        {
            get { return this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Unit.CurrentMana); }
        }
        public int MaxMana
        {
            get { return this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Unit.MaxMana); }
        }
        public int HealthPercent
        {
            get
            {
                double percentage = CurrentHealth / MaxHealth;
                percentage = percentage * 100;
                return (int)Math.Round(percentage);
            }
        }
    }
}
