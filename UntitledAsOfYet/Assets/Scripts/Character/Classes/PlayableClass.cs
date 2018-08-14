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
                    { AttributeType.Health, 0 }, {AttributeType.HealthRegen, 0 },
                    { AttributeType.Mana, 0 }, {AttributeType.ManaRegen, 0 },
                    { AttributeType.MagCritChance, 0 }, { AttributeType.MagCritMult, 0 },
                    { AttributeType.PhysCritChance, 0 }, { AttributeType.PhysCritMult, 0 },
                    { AttributeType.MoveSpeed, 0 }, { AttributeType.Armor, 0 },
                    { AttributeType.PhysResist, 0 }, { AttributeType.MagResist, 0 }
                },
                new List<Spell>() { })
            },
        {
            PlayableClass.Warrior, new PlayableClassData(
                new Dictionary<AttributeType, float>()
                {
                    { AttributeType.Health, 0 }, {AttributeType.HealthRegen, 0 },
                    { AttributeType.Mana, 0 }, {AttributeType.ManaRegen, 0 },
                    { AttributeType.MagCritChance, 0 }, { AttributeType.MagCritMult, 0 },
                    { AttributeType.PhysCritChance, 0 }, { AttributeType.PhysCritMult, 0 },
                    { AttributeType.MoveSpeed, 0 }, { AttributeType.Armor, 0 },
                    { AttributeType.PhysResist, 0 }, { AttributeType.MagResist, 0 }
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
