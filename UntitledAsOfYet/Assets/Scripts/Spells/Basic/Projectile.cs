using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : SpellStage {
    public float speed;
    public float duration;
    public bool mustCollide; // Must collide to trigger next stage
    public float verticalVelocity; // Starting Vertical Velocity
    public float gravityStrength;

    private float gravVelocity = 0;

    public override void Start()
    {
        base.Start();
    }

    public void Update()
    {
        // Move Spell
        transform.parent.transform.position += transform.parent.transform.forward * speed * Time.deltaTime;
        gravVelocity += gravityStrength * Time.deltaTime;
        transform.parent.transform.position += Vector3.down * gravVelocity * Time.deltaTime;

        duration -= Time.deltaTime;
        // Check Duration
        if (spellController.isServer)
        {
            if (duration <= 0)
            {
                if (mustCollide)
                    spellController.RpcDestroySpell();
                else
                    spellController.TriggerNextStage();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (spellController.isServer)
        {
            if (other.tag == "Terrain")
            {
                spellController.TriggerNextStage();
            }
        }
        
    }

    // Collision Detection
}
