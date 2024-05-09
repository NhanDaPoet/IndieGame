using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Base Weapon Data")]
public class WeaponDataSO : ScriptableObject
{
    [field: SerializeField] public int NumberOfAttacks {  get;private set; }

    [field: SerializeReference] public List<ComponentData> ComponentData {  get; private set; }

    public T GetData<T>()
    {
        return ComponentData.OfType<T>().FirstOrDefault();
    }

    [ContextMenu("Add Sprite Data")]
    private void AddSpriteData() => ComponentData.Add(new WeaponSpriteData());

    [ContextMenu("Add Movement Data")]
    private void AddMovementData() => ComponentData.Add(new MovementData());

}
