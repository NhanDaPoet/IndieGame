using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Focus the code
[System.Serializable]
// --------------
public struct WeaponAttackDetails
{
    public string attackName;
    public float movementSpeed;
    public float damageAmount;

    public float knockbackStrength;
    public Vector2 knockbackAngle;
}
