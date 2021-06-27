using WoWTest.Core.Models;

namespace WoWTest.GUI.ViewModels
{
    public class ObjectRecord
    {
        private readonly WowObject wowObject;

        public ObjectRecord (WowObject wowObject)
        {
            this.wowObject = wowObject;
        }
    }
}
