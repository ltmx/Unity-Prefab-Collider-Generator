using UnityEditor;
using UnityEngine;

namespace Unity_Prefab_Collider_Generator_v1._0.Editor
{
    [CustomEditor(typeof(PrefabColliderGenerator)), CanEditMultipleObjects]
    public class PrefabColliderGeneratorEditor : UnityEditor.Editor
    {
        private PrefabColliderGenerator p;
        private Color guiColor = new Color(0.72f, 1f, 0.6f);
        private void OnEnable()
        {
            p = target as PrefabColliderGenerator;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (p.boundsGenerationType == PrefabColliderGenerator.BoundsGenerationType.Transforms)
            {
                p.IncludeParentTransform = EditorGUILayout.Toggle("Include Parent Transform", p.IncludeParentTransform);
                p.GenerateCollider(p.boundsGenerationType);
            }
            GUILayout.Space(10);
        
            GUI.backgroundColor = guiColor;

            if (GUILayout.Button(new GUIContent("Generate Collider"))) {
                p.GenerateCollider(p.boundsGenerationType);
            }
        
            GUILayout.BeginHorizontal();

            GUI.backgroundColor = GUI.color;
        
            if (GUILayout.Button(new GUIContent("Assign Self"))) {
                p.targetGameObject = p.gameObject;
            }
        
            if (GUILayout.Button(new GUIContent("Clean Duplicate Colliders"))) {
                p.ClearDuplicateColliders();
            }
        
            GUILayout.EndHorizontal();
        }
    }
}