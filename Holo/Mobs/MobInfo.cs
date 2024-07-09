using Holo.Harvestable;
using System.Collections.Generic;
using System.Linq;

namespace Holo.Mobs;

public sealed class MobInfo
{
    public static readonly List<MobInfo> MobsInfo =
    [
	
		//#region Hide        
		// Steppe biome
		new(386, 1, MobType.SKINNABLE), // Marmot
		new(387, 2, MobType.SKINNABLE), // Impala
		new(388, 3, MobType.SKINNABLE), // Moabird
		new(389, 4, MobType.SKINNABLE), // Giant stag
		new(390, 5, MobType.SKINNABLE), // Terrorbird
		new(391, 6, MobType.SKINNABLE), // Hyena
		new(392, 7, MobType.SKINNABLE), // Rhino
		new(393, 7, MobType.SKINNABLE), // Bighorn Rhino
		new(394, 8, MobType.SKINNABLE), // Mammoth
		new(395, 8, MobType.SKINNABLE), // Ancient Mammoth
		   // Steppe biome treasure
        new(396, 4, MobType.SKINNABLE), // T4_MOB_TREASURE_HIDE_STEPPE_GIANTSTAG
        new(397, 5, MobType.SKINNABLE), // T5_MOB_TREASURE_TERRORBIRD
        new(398, 6, MobType.SKINNABLE), // T6_MOB_TREASURE_DESERTWOLF
        new(399, 7, MobType.SKINNABLE), // T7_MOB_TREASURE_RHINO
        new(400, 8, MobType.SKINNABLE), // T8_MOB_TREASURE_ANCIENTMAMMOTH

        new(475, 3, MobType.SKINNABLE), // 
        new(476, 5, MobType.SKINNABLE), // Cougar
        new(477, 7, MobType.SKINNABLE), // Cougar


         // Mists
         new(330, 1, MobType.SKINNABLE), // WOLPERTINGER
         new(331, 2, MobType.SKINNABLE), // FOX
         new(332, 3, MobType.SKINNABLE), // DEER
         new(333, 4, MobType.SKINNABLE), // GIANTSTAG
         new(334, 5, MobType.SKINNABLE), // OWL
         new(335, 6, MobType.SKINNABLE), // HOUND
         new(336, 7, MobType.SKINNABLE), // DIREBEAR
         new(337, 8, MobType.SKINNABLE), // DRAGONHAWK


        //Mist Cougars
         new(492, 3, MobType.SKINNABLE),//??
         new(493, 4, MobType.SKINNABLE),
         new(494, 5, MobType.SKINNABLE),
         new(495, 6, MobType.SKINNABLE),
         new(496, 7, MobType.SKINNABLE),
         new(497, 8, MobType.SKINNABLE),


        new(364, 6, MobType.SKINNABLE), //wolf ava

        new(508,4,MobType.HARVESTABLE,HarvestableMobType.LOGS),
        new(509, 5, MobType.HARVESTABLE, HarvestableMobType.LOGS),
        new(510, 6, MobType.HARVESTABLE, HarvestableMobType.LOGS),


        new(568, 3, MobType.HARVESTABLE, HarvestableMobType.LOGS),
        new(569, 4, MobType.HARVESTABLE, HarvestableMobType.LOGS),
        new(570, 5, MobType.HARVESTABLE, HarvestableMobType.LOGS),
        new(571, 6, MobType.HARVESTABLE, HarvestableMobType.LOGS),
        new(572, 7, MobType.HARVESTABLE, HarvestableMobType.LOGS),
        new(573, 8, MobType.HARVESTABLE, HarvestableMobType.LOGS),

        //new(594, 5, MobType.HARVESTABLE, HarvestableMobType.LOGS),
        //new(595, 6, MobType.HARVESTABLE, HarvestableMobType.LOGS),


        //new(619, 6, MobType.HARVESTABLE, HarvestableMobType.LOGS),

        new(554, 5, MobType.HARVESTABLE, HarvestableMobType.FIBER),
        new(555, 6, MobType.HARVESTABLE, HarvestableMobType.FIBER),

        new(560, 6, MobType.HARVESTABLE, HarvestableMobType.FIBER), //ava spect

        new(586, 3, MobType.HARVESTABLE, HarvestableMobType.FIBER),
        new(587, 4, MobType.HARVESTABLE, HarvestableMobType.FIBER),
        new(588, 5, MobType.HARVESTABLE, HarvestableMobType.FIBER),
        new(589, 6, MobType.HARVESTABLE, HarvestableMobType.FIBER),        
        new(590, 7, MobType.HARVESTABLE, HarvestableMobType.FIBER),
        new(591, 8, MobType.HARVESTABLE, HarvestableMobType.FIBER),

        new(612, 5, MobType.HARVESTABLE, HarvestableMobType.FIBER),
        new(613, 6, MobType.HARVESTABLE, HarvestableMobType.FIBER),//no confirmat
        new(614, 7, MobType.HARVESTABLE, HarvestableMobType.FIBER),

        new(553, 4, MobType.HARVESTABLE, HarvestableMobType.FIBER),
        new(637, 6, MobType.HARVESTABLE, HarvestableMobType.FIBER),

        new(538, 4, MobType.HARVESTABLE, HarvestableMobType.ORE),
        new(540, 6, MobType.HARVESTABLE, HarvestableMobType.ORE),

        new(580, 3, MobType.HARVESTABLE, HarvestableMobType.ORE),
        new(581, 4, MobType.HARVESTABLE, HarvestableMobType.ORE),
        new(582, 5, MobType.HARVESTABLE, HarvestableMobType.ORE),
        new(583, 6, MobType.HARVESTABLE, HarvestableMobType.ORE),
        new(584, 7, MobType.HARVESTABLE, HarvestableMobType.ORE),
        new(585, 8, MobType.HARVESTABLE, HarvestableMobType.ORE),

        new(607, 7, MobType.HARVESTABLE, HarvestableMobType.ORE),
        new(608, 7, MobType.HARVESTABLE, HarvestableMobType.ORE),


        new(87,0,MobType.WISP),
        new(88,1,MobType.WISP),
        new(89,2,MobType.WISP),
        new(90,3,MobType.WISP),
        new(91,4,MobType.WISP)

        //new(87,1,MobType.WISP)





    ];

    public int ID { get; }
    public byte Tier { get; }
    public MobType MobType { get; }
    public HarvestableMobType HarvestableMobType;

    private MobInfo(int id, byte tier, MobType mobType)
    {
        ID = id;
        Tier = tier;
        MobType = mobType;
    }

    private MobInfo(int id, byte tier, MobType mobType, HarvestableMobType harvestableMobType)
    {
        ID = id;
        Tier = tier;
        MobType = mobType;
        HarvestableMobType = harvestableMobType;
    }

    public override string ToString()
    {
        return "ID: " + ID + " Tier: " + Tier + " MobType: " + MobType;
    }

    public static MobInfo GetMobInfo(int mobId)
    {
        return MobsInfo.FirstOrDefault(m => m.ID == mobId);
    }
}
