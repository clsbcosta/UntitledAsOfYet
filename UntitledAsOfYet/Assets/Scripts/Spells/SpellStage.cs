using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class SpellStage : MonoBehaviour {
    protected SpellController spellController;

    public virtual void Start()
    {
        spellController = transform.parent.GetComponent<SpellController>();
    }
}
