using UnityEditor;
using UnityEngine;

public class ModeEditor : PropertyDrawer
{
    private bool playersUnfolded = false;

    protected Rect currentRect;

    protected void DrawProperty(SerializedProperty prop, int indent = 0) {
        var oldIndent = EditorGUI.indentLevel;

        try {
            if (indent >= 0) {
                EditorGUI.indentLevel += indent;
            }
            EditorGUI.PropertyField(currentRect, prop);
            NextRect();
        } finally {
            EditorGUI.indentLevel = oldIndent;
        }
    }

    protected bool DrawFoldout(string name, ref bool foldout) {
        foldout = EditorGUI.Foldout(currentRect, foldout, name);
        NextRect();
        return foldout;
    }

    protected void NextRect() {
        currentRect.y += EditorGUIUtility.singleLineHeight;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        currentRect = new Rect(position.x, position.y, position.width, EditorGUIUtility.singleLineHeight);

        // if (DrawFoldout("Players", ref playersUnfolded)) {
        //     DrawProperty(property.FindPropertyRelative("player1"), 1);
        //     DrawProperty(property.FindPropertyRelative("player2"), 1);
        // }

        DrawProperty(property.FindPropertyRelative("UIPrefab"));
    }
}
