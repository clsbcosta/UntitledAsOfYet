using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayableClass
{
    Sorcerer, Warrior,
};

public static class ClassData
{
    // Create Class:
    //      Spell List,
    //      Health, HealthRegen, Mana, ManaRegen,
    //      MagCritChance, MagCritMult, PhysCritChance, PhysCritMult,
    //      MoveSpeed, Armor, PhysResist, MagResist
    //      MagicDamage, PhysicalDamage
    // Numbers are multipliers (1.2 = 20% stat boost)
    public static IDictionary<PlayableClass, PlayableClassData> PlayableClasses = new Dictionary<PlayableClass, PlayableClassData>()
    {
        {
            PlayableClass.Sorcerer, new PlayableClassData(
                new List<Spell>() { },
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1)
            },
        {
            PlayableClass.Warrior, new PlayableClassData(
                new List<Spell>() { },
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1, 1, 1,
                1, 1)
            }
    };

}


public struct PlayableClassData
{
    public float[] baseAttributes;
    public IList<Spell> Spells;
    public PlayableClassData(List<Spell> Spells, float Health, float HealthRegen, float Mana, float ManaRegen,
        float MagCritChance, float MagCritMult, float PhysCritChance, float PhysCritMult,
        float MoveSpeed, float Armor, float PhysResist, float MagResist, float MagicDamage, float PhysicalDamage)
    {
        baseAttributes = new float[]{ Health, HealthRegen, Mana, ManaRegen,
            MagCritChance, MagCritMult, PhysCritChance, PhysCritMult, 
            MoveSpeed, Armor, PhysResist, MagResist,
            MagicDamage, PhysicalDamage };
        this.Spells = Spells;
    }
}
