using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
    // My Class and Race
    public PlayableClass myClass;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void LoadMyAttributes()
    {
        baseAttributes = ClassData.PlayableClasses[myClass].baseAttributes;
    }

    protected override void LoadMySpells()
    {
        mySpells = ClassData.PlayableClasses[myClass].Spells;
    }
}
