using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Damageable Interface
public interface IDamageable<T>
{
    void Damage(T damageTaken);
}
