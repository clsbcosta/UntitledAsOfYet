using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayableClass
{
    Sorcerer, Warrior,
};

public static class ClassData
{
    public static IDictionary<PlayableClass, PlayableClassData> PlayableClasses = new Dictionary<PlayableClass, PlayableClassData>()
    {
        {
            PlayableClass.Sorcerer, new PlayableClassData(
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
            PlayableClass.Warrior, new PlayableClassData(
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


public struct PlayableClassData
{
    public IDictionary<AttributeType, float> baseAttributes;
    public IList<Spell> Spells;
    public PlayableClassData(Dictionary<AttributeType, float> baseAttributes, List<Spell> Spells)
    {
        this.baseAttributes = baseAttributes;
        this.Spells = Spells;
    }
}
