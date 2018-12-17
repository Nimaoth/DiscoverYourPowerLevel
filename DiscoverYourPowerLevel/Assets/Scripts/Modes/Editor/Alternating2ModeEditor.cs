using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Alternating2ModeBehaviour))]
public class Alternating2ModeEditor : ModeEditor
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        base.OnGUI(position, property, label);
        
        DrawProperty(property.FindPropertyRelative("RandomizeButtons"));
        DrawProperty(property.FindPropertyRelative("Player1Key1"));
        DrawProperty(property.FindPropertyRelative("Player1Key2"));
        DrawProperty(property.FindPropertyRelative("Player2Key1"));
        DrawProperty(property.FindPropertyRelative("Player2Key2"));
        DrawProperty(property.FindPropertyRelative("GainPerHit"));
    }
}
