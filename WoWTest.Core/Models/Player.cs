using System;
using System.Numerics;
using Process.NET;

namespace WoWTest.Core.Models
{
    public class Player : Creature
    {

        public Player(IProcess wowProcess, IntPtr baseAddress) : base(wowProcess, baseAddress)
        {
            this.wowProcess = wowProcess;
        }

        public int CurrentRage
        {
            get
            {
                int RageTemp = this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Player.CurrentRage);
                return (int)(Math.Floor((double)(RageTemp / 10)));
            }
        }
        public int MaxRage
        {
            get { return 100; }
        }
        public int CurrentEnergy
        {
            get { return this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Player.CurrentEnergy); }
        }
        public int MaxEnergy
        {
            get { return this.wowProcess.Memory.Read<int>(DescriptorFields + (int)Offsets.Player.MaxEnergy); }
        }
    }
}
