using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : SpellStage {
    public float duration;
    
    public void Update()
    {
        duration -= Time.deltaTime;
        
        if (spellController.isServer)
        {
            if (duration <= 0)
            {
                spellController.TriggerNextStage();
            }
        }
    }
}
