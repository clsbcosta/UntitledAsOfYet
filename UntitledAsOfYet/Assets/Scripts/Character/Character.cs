using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Character : NetworkBehaviour, IDamageable<float>
{
    // Debug
    public bool syncAttributes = false;

    // Spells
    protected IList<Spell> mySpells;

    // Attributes
    protected float[] baseAttributes; // Character Base Attributes
    protected float[] baseAttribPercMods; // Character Base Perc Mods
    
    
    [HideInInspector] public float[] attributes; // Character Current Attributes
    private float[] attribPercMods; // Percent Modifier for each Attribute
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
        if (syncAttributes)
        {
            syncAttributes = false;
            CalculateAttributes();
        }

        //CalculateAttributes();
    }

    // Take Damage Interface
    public void Damage(float damageTaken)
    {
        throw new NotImplementedException();
    }

    // Recalculate Attributes based on Base Attributes and Attribute Modifiers
    [Server]
    private void CalculateAttributes()
    {
        attributes = (float[])baseAttributes.Clone();
        attribPercMods = (float[])baseAttribPercMods.Clone();
        // Add flat attribute increases and percentage attribute inceases
        foreach (AttribModifier attribMod in attribModifiers)
        {
            attributes[(int)attribMod.attribute] += attribMod.flatMod;
            attribPercMods[(int)attribMod.attribute] *= 1+attribMod.percMod;
        }
        // Apply percentage modifiers
        for (int i = 0; i < attributes.Length; i++)
        {
            attributes[i] *= attribPercMods[i];
        }
        RpcSyncAttributes(attributes);
    }

    [ClientRpc]
    private void RpcSyncAttributes(float[] attributes)
    {
        this.attributes = attributes;
    }

    protected virtual void LoadMySpells()
    {
        // Default load no spells
        mySpells = new List<Spell>();
    }

    protected virtual void LoadMyAttributes()
    {
        // Default load no attributes
        baseAttributes = new float[Enum.GetValues(typeof(AttributeType)).Length];
        baseAttribPercMods = new float[Enum.GetValues(typeof(AttributeType)).Length];
    }
}
