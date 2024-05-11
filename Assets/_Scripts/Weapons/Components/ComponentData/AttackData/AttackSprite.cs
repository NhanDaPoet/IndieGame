using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AttackSprite : AttackData
{
    [field: SerializeField] public Sprite[] Sprites {  get;private set; }
}
