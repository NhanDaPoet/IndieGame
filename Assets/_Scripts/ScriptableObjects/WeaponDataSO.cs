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
    public void AddData(ComponentData data)
    {
        if (ComponentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        ComponentData.Add(data);
    }

}
