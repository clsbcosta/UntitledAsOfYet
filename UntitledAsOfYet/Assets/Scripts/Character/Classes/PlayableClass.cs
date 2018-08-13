using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayableClass
{
    Dictionary<AttributeType, float> GetBaseAttributes();
    List<Spell> GetSpells();
}
