using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(MashSingleModeBehaviour))]
public class MashSingleModeEditor : ModeEditor
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        base.OnGUI(position, property, label);
        
        DrawProperty(property.FindPropertyRelative("Player1Key"));
        DrawProperty(property.FindPropertyRelative("Player2Key"));
        DrawProperty(property.FindPropertyRelative("GainPerHit"));
    }
}
