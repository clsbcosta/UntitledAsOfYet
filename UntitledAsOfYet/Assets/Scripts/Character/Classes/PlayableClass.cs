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
                    { AttributeType.Health, 100 }, {AttributeType.HealthRegen, 5 },
                    { AttributeType.Mana, 200 }, {AttributeType.ManaRegen, 50 },
                    { AttributeType.MagCritChance, 20 }, { AttributeType.MagCritMult, 2 },
                    { AttributeType.PhysCritChance, 10 }, { AttributeType.PhysCritMult, 1.5f },
                    { AttributeType.MoveSpeed, 100 }, { AttributeType.Armor, 0 },
                    { AttributeType.PhysResist, 0 }, { AttributeType.MagResist, 5 }
                },
                new List<Spell>() { })
            },
        {
            PlayableClass.Warrior, new PlayableClassData(
                new Dictionary<AttributeType, float>()
                {
                    { AttributeType.Health, 200 }, {AttributeType.HealthRegen, 50 },
                    { AttributeType.Mana, 100 }, {AttributeType.ManaRegen, 5 },
                    { AttributeType.MagCritChance, 10 }, { AttributeType.MagCritMult, 1.5f },
                    { AttributeType.PhysCritChance, 20 }, { AttributeType.PhysCritMult, 2 },
                    { AttributeType.MoveSpeed, 100 }, { AttributeType.Armor, 5 },
                    { AttributeType.PhysResist, 15 }, { AttributeType.MagResist, 10 }
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
