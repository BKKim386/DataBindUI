using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace DBU
{
    [CustomEditor(typeof(SetterBase<>), true)]
    public class SetterBaseEditor : Editor
    {
        private List<string> _fieldPath;
        private SerializedProperty _bindNameProperty;
        
        private UIBaseLifetimeScope _targetScope;

        private int _index;
        
        private void OnEnable()
        {
            _fieldPath = new();
            _bindNameProperty = serializedObject.FindProperty("BindField");
            _targetScope = (target as MonoBehaviour).GetComponentInParent<UIBaseLifetimeScope>();

            if (_targetScope == null) return;
            
            var customAttribute = _targetScope.GetType().GetCustomAttributes(true)
                .FirstOrDefault(attribute => attribute is InjectorModelAttribute);

            if (customAttribute is InjectorModelAttribute injectorModelAttribute)
            {
                foreach (var model in injectorModelAttribute.InjectModel)
                {
                    var modelName = model.Name;

                    var paths = model.GetFields(BindingFlags.Instance | BindingFlags.Public)
                        .Select(field => $"{modelName}.{field.Name}").ToArray();
                    
                    _fieldPath.AddRange(paths);
                }
            }

            if (_bindNameProperty.stringValue != string.Empty)
            {
                _index = _fieldPath.FindIndex(path => path == _bindNameProperty.stringValue);
            }
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();


            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("BindField", GUILayout.Width(EditorGUIUtility.labelWidth));
            if (_fieldPath != null)
            {
                _index = EditorGUILayout.Popup(_index ,_fieldPath.ToArray());

                _bindNameProperty.stringValue = _fieldPath[_index];
            }
            else
            {
                EditorGUILayout.HelpBox("No parent object or no members found.", MessageType.Warning);
            }
            EditorGUILayout.EndHorizontal();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}