using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ENUM attribute names
public enum AttributeType
{
    Health = 0, HealthRegen = 1, Mana = 2, ManaRegen = 3,
    MagCritChance = 4, MagCritMult = 5, PhysCritChance = 6, PhysCritMult = 7,
    MoveSpeed = 8, Armor = 9, PhysResist = 10, MagResist = 11,
    MagicDamage = 12, PhysicalDamage = 13
};

// Class to store Attribute Modification
[System.Serializable]
public class AttribModifier
{
    public AttributeType attribute;
    public float flatMod, percMod;
    public AttribModifier(AttributeType type, float flatMod, float percMod)
    {
        this.attribute = type; this.flatMod = flatMod; this.percMod = percMod;
    }
}



