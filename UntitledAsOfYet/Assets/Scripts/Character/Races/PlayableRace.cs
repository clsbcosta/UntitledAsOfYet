using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayableRace
{
    Human, Dwarf, Undead, Orc,
};

public static class RaceData
{
    // Create Race:
    //  PlayableRaceData Parameters:
    //      Spell List,
    //      Health, HealthRegen, Mana, ManaRegen,
    //      MagCritChance, MagCritMult, PhysCritChance, PhysCritMult,
    //      MoveSpeed, Armor, PhysResist, MagResist
    // Numbers are flat increases
    public static IDictionary<PlayableRace, PlayableRaceData> PlayableRaces = new Dictionary<PlayableRace, PlayableRaceData>()
    {
        {
            PlayableRace.Human, new PlayableRaceData(
                new List<Spell>() { },
                10, 10, 10, 10,
                10, 10, 10, 10,
                10, 10, 10, 10)
            },
        {
            PlayableRace.Dwarf, new PlayableRaceData(
                new List<Spell>() { },
                10, 10, 10, 10,
                10, 10, 10, 10,
                10, 10, 10, 10)
            },
        {
            PlayableRace.Undead, new PlayableRaceData(
                new List<Spell>() { },
                10, 10, 10, 10,
                10, 10, 10, 10,
                10, 10, 10, 10)
            },
        {
            PlayableRace.Orc, new PlayableRaceData(
                new List<Spell>() { },
                10, 10, 10, 10,
                10, 10, 10, 10,
                10, 10, 10, 10)
            }
    };
}


public struct PlayableRaceData
{
    public float[] baseAttributes;
    public IList<Spell> Spells;
    public PlayableRaceData(List<Spell> Spells, float Health, float HealthRegen, float Mana, float ManaRegen,
        float MagCritChance, float MagCritMult, float PhysCritChance, float PhysCritMult,
        float MoveSpeed, float Armor, float PhysResist, float MagResist)
    {
        baseAttributes = new float[]{ Health, HealthRegen, Mana, ManaRegen,
            MagCritChance, MagCritMult, PhysCritChance, PhysCritMult,
            MoveSpeed, Armor, PhysResist, MagResist };
        this.Spells = Spells;
    }
}
