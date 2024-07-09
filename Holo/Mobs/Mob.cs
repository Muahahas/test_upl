using Holo.Harvestable;

namespace Holo.Mobs;

public sealed class Mob(int id, int typeId, float posX, float posY, int health, byte enchantmentLevel)
{
    public int ID { get; } = id;
    public int TypeId { get; } = typeId;
    public float PosX { get; set; } = posX;
    public float PosY { get; set; } = posY;
    public int Health { get; set; } = health;
    public byte EnchantmentLevel { get; set; } = enchantmentLevel;
    public MobInfo MobInfo { get; } = MobInfo.GetMobInfo(typeId);

    public override string ToString()
    {
        return "ID:" + ID + " TypeId: " + TypeId + " PosX: " + PosX + " PosY: " + PosY + " Health: " + Health + " EnchantmentLevel: " + EnchantmentLevel;
    }

    public string getMapStringInfo()
    {
        if (MobInfo != null)
        {
            if (MobInfo.MobType == MobType.HARVESTABLE)
            {
                switch (MobInfo.HarvestableMobType)
                {
                    case HarvestableMobType.ESSENCE:
                        return "E";
                    case HarvestableMobType.FIBER:
                        return "F";
                    case HarvestableMobType.HIDE:
                        return "L";
                    case HarvestableMobType.ORE:
                        return "O";
                    case HarvestableMobType.LOGS:
                        return "W";
                    case HarvestableMobType.HIGHLAND:
                        return "R";

                }
            }
            else if (MobInfo.MobType == MobType.SKINNABLE)
            {
                return "S";
            }
            else if (MobInfo.MobType == MobType.OTHER)
            {
                return "M";
            }
        }
        return "M";
    }
}
