using Holo.Harvestable;
using Holo.Mobs;
using Holo.Utils;
using System;
using System.Data;
using System.IO;
using System.Windows.Ink;

namespace Holo;

public sealed class Config
{
    public Radar RadarParams { get; set; } = new();
    public PlayerSettings Players { get; set; } = new();
    public HarvestableSettings Wood { get; set; } = new();
    public HarvestableSettings Stone { get; set; } = new();
    public HarvestableSettings Hide { get; set; } = new();
    public HarvestableSettings Ore { get; set; } = new();
    public HarvestableSettings Fiber { get; set; } = new();
    public HarvestableSettings MWood { get; set; } = new();
    public HarvestableSettings MHide { get; set; } = new();
    public HarvestableSettings MOre { get; set; } = new();
    public HarvestableSettings MFiber { get; set; } = new();

    public WispSettings WSettings { get; set; } = new();

    public MobSettings Mobs { get; set; } = new();

    static Config()
    {
        try
        {
            if (File.Exists(FileName))
                Instance = Serializer.DeserializeFromFile<Config>(FileName);
        }
        catch (Exception)
        {
            // ignored
        }
        finally
        {
            if (Instance == null)
                Default();

            Save();
        }
    }

    public const string FileName = "config.json";
    public static Config Instance;

    public class Radar
    {
        public float XOffset { get; set; } = 10;
        public float YOffset { get; set; } = 160;
        public float Size { get; set; } = 200;
        public float Scale { get; set; } = 2.0f;
    }

    public class HarvestableSettings
    {
        public class TierSettings
        {
            public bool Enabled { get; set; } = true;
            public bool[] Enchants { get; set; } = [true, true, true, true];
        }

        public HarvestableSettings()
        {
            for (int i = 0; i < Tier.Length; ++i)
                Tier[i] = new TierSettings();
        }

        public TierSettings[] Tier { get; set; } = new TierSettings[8];
    }

    public class WispSettings {
        public bool[] Enchants { set; get; } = [true, true, true, true, true];
    }

    public class PlayerSettings
    {
        public bool ShowPlayers { get; set; } = true;
        public bool PlaySound { get; set; } = false;
    }

    public class MobSettings
    {
        public bool ShowMobs { get; set; } = true;
    }

    private static void Default()
    {
        Instance = new Config();
        Save();
    }

    public static void Save()
    {
        Serializer.Serialize(Instance, FileName);
    }

    public bool CanShowHarvestable(HarvestableType type, byte tier, byte enchant)
    {
        HarvestableSettings settings;
        //MainForm.Log(type.ToString());
        switch (type)
        {
            case (>= HarvestableType.FIBER and <= HarvestableType.FIBER_GUARDIAN_DEAD) or (>= HarvestableType.FIBER_AVA and <= HarvestableType.FIBER_GUARDIAN_DEAD_AVA):
                settings = Fiber;
                break;
            case (>= HarvestableType.WOOD and <= HarvestableType.WOOD_GUARDIAN_RED) or (>= HarvestableType.WOOD_AVA and <= HarvestableType.WOOD_GUARDIAN_RED_AVA):
                settings = Wood;
                break;
            case (>= HarvestableType.ROCK and <= HarvestableType.ROCK_GUARDIAN_RED) or (>= HarvestableType.ROCK_AVA and <= HarvestableType.ROCK_CRITTER_DEAD_AVA):
                settings = Stone;
                break;
            case (>= HarvestableType.HIDE and <= HarvestableType.HIDE_GUARDIAN) or (>= HarvestableType.HIDE_AVA and <= HarvestableType.HIDE_CRITTER_AVA):
                settings = Hide;
                break;
            case (>= HarvestableType.ORE and <= HarvestableType.ORE_GUARDIAN_RED)or (>= HarvestableType.ORE_AVA and <= HarvestableType.ORE_GUARDIAN_RED_AVA):
                settings = Ore;
                break;
            default:
                MainForm.Log(type.ToString());
                return false;
        }

        if (enchant > 0) 
            return settings.Tier[tier - 1].Enchants[enchant - 1];
        else
            return settings.Tier[tier - 1].Enabled;
            

        return false;
    }

    public bool CanShowMHarvestable(MobInfo info, byte tier, byte enchant)
    {
        //Mobs normals no entren ha de tenir mobINfo
        HarvestableSettings settings = null ;
        MobType mobType = info.MobType;


        if (mobType.Equals(MobType.SKINNABLE))
        {
            settings = MHide;
        }
        else if (mobType.Equals(MobType.HARVESTABLE))
        {
            HarvestableMobType hMobType = info.HarvestableMobType;            
            if (hMobType == HarvestableMobType.FIBER)
                settings = MFiber;
            if (hMobType == HarvestableMobType.HIDE)
                settings = MHide;
            if (hMobType == HarvestableMobType.ORE)
                settings = MOre;
            if (hMobType == HarvestableMobType.LOGS)
                settings = MWood;
            //return false;
        }
        else
        {
            return true;//false?
        }

        if (settings != null)
        {
            if (enchant > 0)
                return settings.Tier[tier - 1]
                    .Enchants[enchant - 1];
            else
                return settings.Tier[tier - 1].Enabled;
        }
        else
        {
            return false;//true?
        }

    }


    public bool canShowWisp(byte enchant)
    {
       // WispSettings settings = wSettings;
        return WSettings.Enchants[enchant];
    }

    
}
