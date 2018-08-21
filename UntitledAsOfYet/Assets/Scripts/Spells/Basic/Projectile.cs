using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : SpellStage {
    public float speed;
    public float duration;

    public void Update()
    {
        // Move Spell
        transform.parent.transform.position += transform.parent.transform.forward * speed * Time.deltaTime;

        duration -= Time.deltaTime;
        // Check Duration
        if (spellController.isServer)
        {
            if (duration <= 0)
            {
                spellController.TriggerNextStage();
            }
        }
    }

    // Collision Detection
}
