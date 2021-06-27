namespace WoWTestConsole.Models
{
    public enum ObjectType : byte
    {
        Object = 0,
        Item = 1,
        Container = 2,
        Unit = 3,
        Player = 4,
        ActivePlayer = 5,
        GameObject = 6,
        DynamicObject = 7,
        Corpse = 8,
        AreaTrigger = 9,
        SceneObject = 10,
        Conversation = 11,
        AIGroup = 12,
        Scenario = 13,
        Loot = 14,
        Invalid
    }
}
