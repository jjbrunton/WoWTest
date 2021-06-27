using WoWTest.Core.Models;

namespace WoWTest.Core.Factories
{
    public interface IWowObjectFactory
    {
        T Create<T>(WowObject wowObject) where T : WowObject;
    }
}
