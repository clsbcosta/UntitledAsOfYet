using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable<float>
{
    // Spells
    protected IList<Spell> mySpells;

    // Attributes
    protected IDictionary<AttributeType, float> baseAttributes; // Character Base Attributes
    protected IDictionary<AttributeType, float> baseAttribPercMods; // Character Base Perc Mods
    public IDictionary<AttributeType, float> attributes; // Character Current Attributes
    private IDictionary<AttributeType, float> attribPercMods; // Percent Modifier for each Attribute
    public List<AttribModifier> attribModifiers = new List<AttribModifier>(); // List of Attribute Modifiers

    // Vectors
    

    // Components
    protected Rigidbody myRigidBody;

    public virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        LoadMyAttributes();
        LoadMySpells();
        CalculateAttributes();
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
        attributes = new Dictionary<AttributeType, float>(baseAttributes);
        attribPercMods = new Dictionary<AttributeType, float>(baseAttribPercMods);
        // Add flat attribute increases and percentage attribute inceases
        foreach (AttribModifier attribMod in attribModifiers)
        {
            attributes[attribMod.attribute] += attribMod.flatMod;
            attribPercMods[attribMod.attribute] *= 1+attribMod.percMod;
        }
        // Apply percentage modifiers
        foreach (AttributeType key in Enum.GetValues(typeof(AttributeType)))
        {
            attributes[key] *= attribPercMods[key];
        }
    }

    protected virtual void LoadMySpells()
    {
        // Default load no spells
        mySpells = new List<Spell>();
    }

    protected virtual void LoadMyAttributes()
    {
        // Default load no attributes
        baseAttributes = new Dictionary<AttributeType, float>();
        baseAttribPercMods = new Dictionary<AttributeType, float>();
    }
}
