using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(Items))]
public class HideValuesByType : Editor
{

    // this are serialized variables in YourClass
    SerializedProperty hasEffects;
    SerializedProperty pointsAmount;
    SerializedProperty boostMultiplier;
    SerializedProperty duration;
    SerializedProperty tooltip;
    SerializedProperty effectType;
    SerializedProperty icon;
    SerializedProperty currency;
    SerializedProperty price;


    private void OnEnable()
    {
        hasEffects = serializedObject.FindProperty("hasEffects");
        pointsAmount = serializedObject.FindProperty("pointsAmount");
        boostMultiplier = serializedObject.FindProperty("boostMultiplier");
        duration = serializedObject.FindProperty("duration");
        tooltip = serializedObject.FindProperty("tooltip");
        effectType = serializedObject.FindProperty("effectType");
        icon = serializedObject.FindProperty("icon");
        currency = serializedObject.FindProperty("currency");
        price = serializedObject.FindProperty("price");
    }

    public override void OnInspectorGUI()
    {
        // If we call base the default inspector will get drawn too.
        // Remove this line if you don't want that to happen.
        serializedObject.Update();
        EditorGUILayout.PropertyField(hasEffects);

        if (!hasEffects.boolValue)
        {
            EditorGUILayout.PropertyField(pointsAmount);
            EditorGUILayout.PropertyField(currency);
        }
        else
        {
            EditorGUILayout.PropertyField(boostMultiplier);
            EditorGUILayout.PropertyField(duration);
            EditorGUILayout.PropertyField(tooltip);
            EditorGUILayout.PropertyField(effectType);
            EditorGUILayout.PropertyField(icon);
            EditorGUILayout.PropertyField(price);
        }

        // must be on the end.
        serializedObject.ApplyModifiedProperties();

        // add this to render base
        base.OnInspectorGUI();
    }
}
