using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour
{
    private float maxDuration = 0;
    private float duration = 0;

    // Attrib Modifier
    [SerializeField]
    private bool dispellable; // Bool Can be dispelled?
    [SerializeField]
    private bool positive; // Buff or Debuff?
    [SerializeField]
    private AttribModifier effect; // Attribute Modification

    // Dot
    [SerializeField]
    private DamageType damageType; // Damage Type
    [SerializeField]
    private float damage; // Damage / Health DOT

    private Character target; // Character affected

    public void Start()
    {
        target = transform.parent.parent.GetComponent<Character>();
        target.attribModifiers.Add(effect); // Apply Attrib Modifier
        if (target.isServer) target.CalculateAttributes(); // If server recalculate attribs
    }

    public void Initialize(float maxDuration)
    {
        if (duration < maxDuration) // Set duration or refresh
        {
            this.maxDuration = maxDuration;
            duration = maxDuration;
        }
    }

    public void Update()
    {
        if (duration > 0) duration -= Time.deltaTime;
        if (target.isServer)
        {
            if (damage != 0) target.Damage(damage*Time.deltaTime, damageType);
            if (duration <= 0) target.RpcRemoveStatusEffect(transform.name);
        }
        // If Server and duration expired rpc remove
    }

    // Reove Self
    public void RemoveEffect()
    {
        target.attribModifiers.Remove(effect);
        if (target.isServer) target.CalculateAttributes();
        Destroy(gameObject);
    }
}
