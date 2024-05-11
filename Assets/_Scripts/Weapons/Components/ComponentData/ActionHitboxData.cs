using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ActionHitboxData : ComponentData<AttackActionHitBox>
    {
    [field: SerializeField] public LayerMask DetectableLayers {  get;private set; }
    }

