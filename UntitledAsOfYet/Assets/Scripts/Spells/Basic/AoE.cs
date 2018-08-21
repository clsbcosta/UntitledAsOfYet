using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AoE : SpellStage {
    public float startSize;
    public float endSize;
    public float expandRate;

    public override void Start()
    {
        transform.localScale = Vector3.one * startSize;
        base.Start();
    }

    public void Update()
    {
        transform.localScale += Vector3.one * expandRate * Time.deltaTime;

        // Check max size
        if (spellController.isServer)
        {
            if (transform.localScale.x >= endSize)
            {
                spellController.TriggerNextStage();
            }
        }
    }
}
