using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpriteData : ComponentData
{
    [field: SerializeField] public AttackSprite[] AttackData {  get;private set; }
}
