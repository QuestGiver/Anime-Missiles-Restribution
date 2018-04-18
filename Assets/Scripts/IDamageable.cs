using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
   // float ApplyDamage(float damage);

    float ApplyTrueDamage(float damage, Vector3 hitPopint = default( Vector3));
}
