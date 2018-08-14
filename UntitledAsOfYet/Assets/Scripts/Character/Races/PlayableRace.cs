using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayableRace
{
    Human, Dwarf, Undead, Orc,
};

public static class RaceData
{
    public static IDictionary<PlayableRace, PlayableRaceData> PlayableRaces = new Dictionary<PlayableRace, PlayableRaceData>()
    {
        {
            PlayableRace.Human, new PlayableRaceData(
                new Dictionary<AttributeType, float>()
                {
                    { AttributeType.Health, 1 }, {AttributeType.HealthRegen, 1 },
                    { AttributeType.Mana, 1 }, {AttributeType.ManaRegen, 1 },
                    { AttributeType.MagCritChance, 1 }, { AttributeType.MagCritMult, 1 },
                    { AttributeType.PhysCritChance, 1 }, { AttributeType.PhysCritMult, 1 },
                    { AttributeType.MoveSpeed, 1 }, { AttributeType.Armor, 1 },
                    { AttributeType.PhysResist, 1 }, { AttributeType.MagResist, 1 }
                },
                new List<Spell>() { })
            },
        {
            PlayableRace.Dwarf, new PlayableRaceData(
                new Dictionary<AttributeType, float>()
                {
                    { AttributeType.Health, 1 }, {AttributeType.HealthRegen, 1 },
                    { AttributeType.Mana, 1 }, {AttributeType.ManaRegen, 1 },
                    { AttributeType.MagCritChance, 1 }, { AttributeType.MagCritMult, 1 },
                    { AttributeType.PhysCritChance, 1 }, { AttributeType.PhysCritMult, 1 },
                    { AttributeType.MoveSpeed, 1 }, { AttributeType.Armor, 1 },
                    { AttributeType.PhysResist, 1 }, { AttributeType.MagResist, 1 }
                },
                new List<Spell>() { })
            },
        {
            PlayableRace.Undead, new PlayableRaceData(
                new Dictionary<AttributeType, float>()
                {
                    { AttributeType.Health, 1 }, {AttributeType.HealthRegen, 1 },
                    { AttributeType.Mana, 1 }, {AttributeType.ManaRegen, 1 },
                    { AttributeType.MagCritChance, 1 }, { AttributeType.MagCritMult, 1 },
                    { AttributeType.PhysCritChance, 1 }, { AttributeType.PhysCritMult, 1 },
                    { AttributeType.MoveSpeed, 1 }, { AttributeType.Armor, 1 },
                    { AttributeType.PhysResist, 1 }, { AttributeType.MagResist, 1 }
                },
                new List<Spell>() { })
            },
        {
            PlayableRace.Orc, new PlayableRaceData(
                new Dictionary<AttributeType, float>()
                {
                    { AttributeType.Health, 1 }, {AttributeType.HealthRegen, 1 },
                    { AttributeType.Mana, 1 }, {AttributeType.ManaRegen, 1 },
                    { AttributeType.MagCritChance, 1 }, { AttributeType.MagCritMult, 1 },
                    { AttributeType.PhysCritChance, 1 }, { AttributeType.PhysCritMult, 1 },
                    { AttributeType.MoveSpeed, 1 }, { AttributeType.Armor, 1 },
                    { AttributeType.PhysResist, 1 }, { AttributeType.MagResist, 1 }
                },
                new List<Spell>() { })
            }
    };

}


public struct PlayableRaceData
{
    public IDictionary<AttributeType, float> baseAttributes;
    public IList<Spell> Spells;
    public PlayableRaceData(Dictionary<AttributeType, float> baseAttributes, List<Spell> Spells)
    {
        this.baseAttributes = baseAttributes;
        this.Spells = Spells;
    }
}
