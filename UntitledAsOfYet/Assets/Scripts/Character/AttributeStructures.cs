using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ENUM attribute names
public enum AttributeType
{
    Health, HealthRegen, Mana, ManaRegen,
    MagCritChance, MagCritMult, PhysCritChance, PhysCritMult,
    MoveSpeed, Armor, PhysResist, MagResist
};

// Struct to store Attribute Modifier
public struct AttribModifier
{
    public AttributeType attribute;
    public float flatMod, percMod;
    public AttribModifier(AttributeType type, float flatMod, float percMod)
    {
        this.attribute = type; this.flatMod = flatMod; this.percMod = percMod;
    }
}



