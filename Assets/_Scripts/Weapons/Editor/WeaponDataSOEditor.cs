using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(WeaponDataSO))]
public class WeaponDataSOEditor : Editor
{
    private static List<Type> dataCompTypes = new List<Type>();

    private WeaponDataSO dataSO;
    private bool showForceUpdateButtons;
    private bool showAddComponentButton;

    private void OnEnable()
    {
        dataSO = target as WeaponDataSO;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Set Number of Attacks"))
        {
            foreach (var item in dataSO.ComponentData)
            {
                item.InitializeAttackData(dataSO.NumberOfAttacks);
            }
        }
        showAddComponentButton = EditorGUILayout.Foldout(showAddComponentButton, "Add Component");

        if(showAddComponentButton)
        {
            foreach (var dataComptype in dataCompTypes)
            {
                if (GUILayout.Button(dataComptype.Name))
                {
                    var comp = Activator.CreateInstance(dataComptype) as ComponentData;
                    if (comp == null)
                        return;

                    comp.InitializeAttackData(dataSO.NumberOfAttacks);

                    dataSO.AddData(comp);
                }
            }
        }

        showForceUpdateButtons = EditorGUILayout.Foldout(showForceUpdateButtons, "Force Update Buttons");

        if (showForceUpdateButtons)
        {
            if (GUILayout.Button("Force Update Component Name"))
            {
                foreach ( var item in dataSO.ComponentData)
                {
                    item.SetComponentName();
                }
            }
            if (GUILayout.Button("Force Update Attack Name"))
            {
                foreach (var item in dataSO.ComponentData)
                {
                    item.SetAttackDataNames();
                }
            }

        }

    }

    [DidReloadScripts]
    private static void OnRecompile()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var types = assemblies.SelectMany(assembly => assembly.GetTypes());
        var filteredTypes = types.Where(type => type.IsSubclassOf(typeof(ComponentData)) && !type.ContainsGenericParameters && type.IsClass);
        dataCompTypes = filteredTypes.ToList();
    }
}

