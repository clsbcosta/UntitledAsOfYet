using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable<float>
{
    // My Class and Race
    public IPlayableClass myClass;


    // Attributes
    private IDictionary<AttributeType, float> baseAttributes; // Character Base Attributes
    public IDictionary<AttributeType, float> attributes; // Character Current Attributes
    private IDictionary<AttributeType, float> attribPercMods; // Percent Modifier for each Attribute
    public List<AttribModifier> attribModifiers; // List of Attribute Modifiers

    public virtual void Start()
    {
        baseAttributes = myClass.GetBaseAttributes();
    }

    public virtual void Update()
    {
        //CalculateAttributes();
    }

    // Take Damage Interface
    public void Damage(float damageTaken)
    {
        throw new NotImplementedException();
    }

    // Recalculate Attributes based on Base Attributes and Attribute Modifiers
    private void CalculateAttributes()
    {
        attributes = baseAttributes;
        attribPercMods = new Dictionary<AttributeType, float>()
        {
            { AttributeType.Health, 1 }, {AttributeType.HealthRegen, 1 },
            { AttributeType.Mana, 1 }, {AttributeType.ManaRegen, 1 },
            { AttributeType.MagCritChance, 1 }, { AttributeType.MagCritMult, 1 },
            { AttributeType.PhysCritChance, 1 }, { AttributeType.PhysCritMult, 1 },
            { AttributeType.MoveSpeed, 1 }, { AttributeType.Armor, 1 },
            { AttributeType.PhysResist, 1 }, { AttributeType.MagResist, 1 }
        };
        // Add flat attribute increases and percentage attribute inceases
        foreach (AttribModifier attribMod in attribModifiers)
        {
            attributes[attribMod.attribute] += attribMod.flatMod;
            attribPercMods[attribMod.attribute] += attribMod.percMod;
        }
        // Apply percentage modifiers
        foreach (AttributeType key in Enum.GetValues(typeof(AttributeType)))
        {
            attributes[key] *= attribPercMods[key];
        }
    }
}
