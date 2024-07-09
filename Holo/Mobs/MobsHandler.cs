using System.Collections.Concurrent;

namespace Holo.Mobs;

public static class MobsHandler
{
    public static readonly ConcurrentDictionary<int, Mob> Mobs = [];

    public static void AddMob(int id, int typeId, float posX, float posY, int health)
    {
        Mob m = new Mob(id, typeId, posX, posY, health, 0);
        Mobs.AddOrUpdate(id, m, (_, _) => m);
    }

    public static void RemoveMob(int id)
    {
        Mobs.TryRemove(id, out _);
    }

    internal static void UpdateMobEnchantmentLevel(int mobId, byte enchantmentLevel)
    {
        if (Mobs.TryGetValue(mobId, out Mob mob))
            mob.EnchantmentLevel = enchantmentLevel;
    }

    internal static void UpdateMobHealth(int mobId, int health)
    {
        if (Mobs.TryGetValue(mobId, out Mob mob))
            mob.Health = health;

        if (health < 1)
        {
            Mobs.TryRemove(mobId, out _);
        }
    }


    public static void UpdateMobsPosition(int id, float posX, float posY)
    {
        if (Mobs.TryGetValue(id, out Mob mob))
        {
            mob.PosX = posX;
            mob.PosY = posY;
        }
    }

    public static void Reset()
    {
        Mobs.Clear();
    }
}
