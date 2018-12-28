using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RhythmModeBehaviour))]
public class RhythmModeEditor : ModeEditor
{
    private Vector2 scroll = Vector2.zero;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        base.OnGUI(position, property, label);
        
        // scroll = EditorGUILayout.BeginScrollView(scroll);
        DrawProperty(property.FindPropertyRelative("GainPerHit"));

        DrawProperty(property.FindPropertyRelative("Player1Key"));
        DrawProperty(property.FindPropertyRelative("Player2Key"));

        DrawProperty(property.FindPropertyRelative("bpm"));
        DrawProperty(property.FindPropertyRelative("timingAccuracy"));
        DrawProperty(property.FindPropertyRelative("tickOffset"));
        DrawProperty(property.FindPropertyRelative("klickOffset"));
        DrawProperty(property.FindPropertyRelative("circleOffset"));
        DrawProperty(property.FindPropertyRelative("tickEffect"));
        DrawProperty(property.FindPropertyRelative("flashSpeed"));
        DrawProperty(property.FindPropertyRelative("circleSize"));

        // EditorGUILayout.EndScrollView();
    }
}
