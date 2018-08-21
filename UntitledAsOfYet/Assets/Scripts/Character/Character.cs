using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Character : NetworkBehaviour
{
    // Debug
    public bool test;

    // Spells
    protected IList<Spell> mySpells;

    // Attributes
    protected float[] baseAttributes; // Character Base Attributes
    protected float[] baseAttribPercMods; // Character Base Perc Mods
    
    public float[] attributes = new float[Enum.GetValues(typeof(AttributeType)).Length]; // Character Current Attributes
    private float[] attribPercMods; // Percent Modifier for each Attribute
    [HideInInspector]
    public List<AttribModifier> attribModifiers = new List<AttribModifier>(); // List of Attribute Modifiers

    // Current Health Mana
    [SyncVar]
    public float health;
    [SyncVar]
    public float mana;

    // Look Vectors
    public Vector3 lookDirection;

    // Time keeping
    private float elapsed;

    // Regen Settings
    private float regenInterval = 1;

    // Components
    protected Rigidbody myRigidBody;
    public Transform StatusEffectLocation;

    public virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        LoadMyAttributes();
        LoadMySpells();
        if (isServer)
        {
            CalculateAttributes();
            ResetHealthMana();
        }
    }

    private void Test()
    {
        test = false;
        RpcApplyEffect("MajorHealth", 10);
    }

    public virtual void Update()
    {
        // Server Calculations
        if (isServer)
        {
            CheckHealthManaRegen();
        }
        if (test) Test();
    }

    // Take Damage Interface
    [Server]
    public void Damage(float damage, DamageType damageType)
    {
        switch (damageType)
        {
            case DamageType.Heal:
                health += damage;
                CheckHealthCap();
                break;
            case DamageType.UnBlockable:
                health -= damage;
                break;
            case DamageType.Magical:
                health -= damage;
                break;
            case DamageType.Physical:
                health -= damage;
                break;
        }
    }

    // Cast Spell
    [Command]
    protected void CmdCastSpell(string spellAsset, Vector3 direction)
    {
        if (isServer)
        {
            GameObject newSpell = Instantiate(Resources.Load("Spells/" + spellAsset),
                transform.position, Quaternion.LookRotation(direction)) as GameObject;
            NetworkServer.Spawn(newSpell);
        }
    }

    // Recalculate Attributes based on Base Attributes and Attribute Modifiers
    [Server]
    public void CalculateAttributes()
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

    private void CheckHealthManaRegen()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= regenInterval)
        {
            elapsed -= regenInterval;
            health += attributes[(int)AttributeType.HealthRegen] * regenInterval; // Apply Regen
            mana += attributes[(int)AttributeType.ManaRegen] * regenInterval;
            CheckHealthCap();
            CheckManaCap();
        }
    }

    private void CheckManaCap()
    {
        if (mana > attributes[(int)AttributeType.Mana])
            mana = attributes[(int)AttributeType.Mana];
    }

    private void CheckHealthCap()
    {
        if (health > attributes[(int)AttributeType.Health])
            health = attributes[(int)AttributeType.Health];
    }

    [Server]
    private void ResetHealthMana()
    {
        health = attributes[(int)AttributeType.Health];
        mana = attributes[(int)AttributeType.Mana];
    }

    [ClientRpc]
    public void RpcRemoveStatusEffect(string name)
    {
        Transform target = StatusEffectLocation.Find(name + "Clone");
        if (target != null)
        {
            target.SendMessage("RemoveEffect");
        }
    }

    [ClientRpc]
    public void RpcApplyEffect(string name, float duration)
    {
        GameObject newEffect;
        Transform search = StatusEffectLocation.Find(name + "(Clone)");
        // Search for clone of statuseffect prefab in StatusEffectLocation
        if (search == null)
            // If none then create effect
            newEffect = Instantiate(Resources.Load("StatusEffects/" + name),
                Vector3.zero, Quaternion.identity, StatusEffectLocation) as GameObject;
        else
            // Otherwise update old effect
            newEffect = search.gameObject;
        // Update Duration
        newEffect.GetComponent<StatusEffect>().Initialize(duration);
    }
}
