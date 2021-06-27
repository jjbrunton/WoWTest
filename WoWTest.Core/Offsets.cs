namespace WoWTest.Core
{
    public class Offsets
    {
        internal enum Player : int
        {
            LocalGuid = 0x2C03B40,
            CurrentRage = 0x19 * 4,
            CurrentEnergy = 0x1B * 4,
            MaxEnergy = 0x23 * 4,
            PlayerInformation = 0x198,
            PlayerPositionX = 0x20,
            PlayerPositionY = PlayerPositionX + sizeof(float),
            PlayerPositionZ = PlayerPositionX + sizeof(float) * 2,
        }

        internal enum ObjectManager : int
        {
            ObjectManagerBase = 0x2D297C8,
            FirstObject = 0x18,
            NextObject = 0x70
        }

        internal enum WowObject : int
        {
            X = 0x1600,
            Y = X + sizeof(float),
            Z = X + sizeof(float)*2,
            Rotation = X + 0x10,
            DescriptorFields = 0x10,
            Pitch = X + 0x14,
            GameObjectX = 0x1B0,
            GameObjectY = GameObjectX + sizeof(float),
            GameObjectZ = GameObjectX + sizeof(float)*2,
            GameObjectRotation = GameObjectX + 0x10,
            TransportGUID = 0x15F0,
            Type = 0x20
        }


        internal enum Unit : int
        {
            Level = 0x134,
            CurrentHealth = 0xDC,
            MaxHealth = 0xFC,
            CurrentMana = 0xE4,
            MaxMana = 0x104,
            Target = 0x9C
    }
    }
}
