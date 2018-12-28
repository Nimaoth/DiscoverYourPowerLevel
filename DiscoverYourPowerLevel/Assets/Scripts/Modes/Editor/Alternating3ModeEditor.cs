using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Alternating3ModeBehaviour))]
public class Alternating3ModeEditor : ModeEditor
{
    private bool drawPlayer1Keys = true;
    private bool drawPlayer2Keys = true;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        base.OnGUI(position, property, label);

        DrawProperty(property.FindPropertyRelative("GainPerHit"));

        if (DrawFoldout("Player 1", ref drawPlayer1Keys)) {
            DrawProperty(property.FindPropertyRelative("Player1Key1"), 1);
            DrawProperty(property.FindPropertyRelative("Player1Key2"), 1);
            DrawProperty(property.FindPropertyRelative("Player1Key3"), 1);
        }

        if (DrawFoldout("Player 2", ref drawPlayer2Keys)) {
            DrawProperty(property.FindPropertyRelative("Player2Key1"), 1);
            DrawProperty(property.FindPropertyRelative("Player2Key2"), 1);
            DrawProperty(property.FindPropertyRelative("Player2Key3"), 1);
        }
    }
}
