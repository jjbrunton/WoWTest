using System;
using System.Collections;
using System.Collections.Generic;
using Process.NET;
using Process.NET.Memory;
using WoWTestConsole.Models;

namespace WoWTestConsole
{
    public class ObjectManager : MemoryObject, IEnumerable<WowObject> 
    {
        private readonly IProcess wowProcess;

        public ObjectManager(IPointer pointer, IProcess wowProcess) : base(pointer.Read<IntPtr>((int)Offsets.ObjectManager.ObjectManagerBase))
        {
            this.wowProcess = wowProcess;
        }

		public IEnumerator<WowObject> GetEnumerator()
		{
			IntPtr currentGameObject = this.wowProcess[this.baseAddress].Read<IntPtr>((int)Offsets.ObjectManager.FirstObject);
			while (currentGameObject.ToInt64() != 0 && currentGameObject.ToInt64() % 2 == 0)
			{
				yield return new WowObject(this.wowProcess, currentGameObject);
				currentGameObject = this.wowProcess[currentGameObject].Read<IntPtr>((int)Offsets.ObjectManager.NextObject);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
