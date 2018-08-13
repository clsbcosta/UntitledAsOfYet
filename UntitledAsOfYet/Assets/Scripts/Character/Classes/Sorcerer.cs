using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorcerer : MonoBehaviour, IPlayableClass {
    private Dictionary<AttributeType, float> baseAttributes = new Dictionary<AttributeType, float>()
    {
        { AttributeType.Health, 100 }, {AttributeType.HealthRegen, 5 },
        { AttributeType.Mana, 200 }, {AttributeType.ManaRegen, 50 },
        { AttributeType.MagCritChance, 20 }, { AttributeType.MagCritMult, 2 },
        { AttributeType.PhysCritChance, 10 }, { AttributeType.PhysCritMult, 1.5f },
        { AttributeType.MoveSpeed, 100 }, { AttributeType.Armor, 0 },
        { AttributeType.PhysResist, 0 }, { AttributeType.MagResist, 5 }
    };
    private List<Spell> Spells = new List<Spell>();

    public Dictionary<AttributeType, float> GetBaseAttributes()
    {
        return baseAttributes;
    }

    public List<Spell> GetSpells()
    {
        return Spells;
    }
}
