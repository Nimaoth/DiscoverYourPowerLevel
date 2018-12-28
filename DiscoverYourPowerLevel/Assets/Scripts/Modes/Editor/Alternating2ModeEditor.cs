using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Alternating2ModeBehaviour))]
public class Alternating2ModeEditor : ModeEditor
{
    private bool drawPlayer1Keys = true;
    private bool drawPlayer2Keys = true;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        base.OnGUI(position, property, label);
        
        DrawProperty(property.FindPropertyRelative("GainPerHit"));
        DrawProperty(property.FindPropertyRelative("RandomizeButtons"));

        if (DrawFoldout("Player 1", ref drawPlayer1Keys)) {
            DrawProperty(property.FindPropertyRelative("Player1Key1"), 1);
            DrawProperty(property.FindPropertyRelative("Player1Key2"), 1);
        }

        if (DrawFoldout("Player 1", ref drawPlayer1Keys)) {
            DrawProperty(property.FindPropertyRelative("Player2Key1"), 1);
            DrawProperty(property.FindPropertyRelative("Player2Key2"), 1);
        }
    }
}
