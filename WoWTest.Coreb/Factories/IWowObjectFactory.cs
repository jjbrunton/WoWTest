using WoWTestConsole.Models;

namespace WoWTestConsole.Factories
{
    public interface IWowObjectFactory
    {
        T Create<T>(WowObject wowObject) where T : WowObject;
    }
}
