using System;
using System.Numerics;
using Process.NET;

namespace WoWTest.Core.Models
{
    public class WowObject : MemoryObject
    {
        protected IProcess wowProcess;

        public WowObject(IProcess wowProcess, IntPtr basePointer) : base(basePointer)
        {
            this.wowProcess = wowProcess;
        }

        public IntPtr DescriptorFields
        {
            get { return this.wowProcess.Memory.Read<IntPtr>(this.baseAddress + (int)Offsets.WowObject.DescriptorFields); }
        }
        public ObjectType Type
        {
            get { return (ObjectType)this.wowProcess.Memory.Read<byte>(this.baseAddress + (int)Offsets.WowObject.Type); }
        }

        public virtual UInt128 Guid
        {
            get { return this.wowProcess[DescriptorFields].Read<UInt128>(0x0); }
            set { return; }
        }

        public virtual Vector3 Position
        {
            get
            {
                var unitInfo = this.wowProcess.Memory.Read<IntPtr>(this.baseAddress + (int)Offsets.Player.PlayerInformation);
                return new Vector3(this.wowProcess.Memory.Read<float>(unitInfo + (int)Offsets.Player.PlayerPositionX), this.wowProcess.Memory.Read<float>(unitInfo + (int)Offsets.Player.PlayerPositionY), this.wowProcess.Memory.Read<float>(unitInfo + (int)Offsets.Player.PlayerPositionZ));
            }
        }

        public float Rotation
        {
            get { return this.wowProcess.Memory.Read<float>(this.baseAddress + (int)Offsets.WowObject.Rotation); }
        }
    }
}
