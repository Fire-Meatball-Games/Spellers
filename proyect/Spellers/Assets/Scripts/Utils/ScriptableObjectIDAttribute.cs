using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace Utils
{
    public class UniqueIdentifierAttribute : PropertyAttribute { }

#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(UniqueIdentifierAttribute))]
    public class UniqueIdentifierDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            string assetPath = AssetDatabase.GetAssetPath(property.serializedObject.targetObject.GetInstanceID());
            string uniqueId = AssetDatabase.AssetPathToGUID(assetPath);

            property.stringValue = uniqueId;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    } 
}

#endif

