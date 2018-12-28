using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EditorExtensions {
public static class EditorSelection {
    public static IEnumerable<Transform> GetChildren(this Transform self) {
        for (int i = 0; i < self.childCount; i++)
            yield return self.GetChild(i);
    }

    public static IEnumerable<GameObject> GetChildren(this GameObject self) {
        for (int i = 0; i < self.transform.childCount; i++)
            yield return self.transform.GetChild(i).gameObject;
    }

    public class InputNumberWindow : EditorWindow {
        int nth = 1;

        void OnGUI()
        {
            nth = EditorGUILayout.IntField("Nth Child", nth);
            GUILayout.Space(70);

            if (GUILayout.Button("Ok!")) {
                this.Close();

                var selection = Selection.gameObjects;

                var newSelection = new List<GameObject>();
                foreach (var obj in selection) {
                    if (obj.transform.childCount >= nth) {
                        var child = obj.transform.GetChild(nth - 1);
                        newSelection.Add(child.gameObject);
                    }
                }

                Selection.objects = newSelection.ToArray();
            }
        }
    }

    [MenuItem("Selection/Select Previous Sibling _#UP")]
    public static void SelectPrevious() {
        var selection = Selection.gameObjects;
        var newSelection = new List<GameObject>();
        GameObject[] rootGameObjects = null;

        if (selection.Length == 0) {
            rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            newSelection.Add(rootGameObjects.Last());
        }

        foreach (var obj in selection) {
            if (obj.transform.parent != null) {
                var parent = obj.transform.parent;
                int index = obj.transform.GetSiblingIndex() - 1;
                if (index >= 0 && index < parent.childCount) {
                    newSelection.Add(parent.GetChild(index).gameObject);
                } else {
                    newSelection.Add(obj);
                }
            } else {
                if (rootGameObjects == null) {
                    rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
                }
                var index = ArrayUtility.IndexOf(rootGameObjects, obj) - 1;
                if (index >= 0 && index < rootGameObjects.Length) {
                    newSelection.Add(rootGameObjects[index]);
                } else {
                    newSelection.Add(obj);
                }
            }
        }

        Selection.objects = newSelection.ToArray();
    }

    [MenuItem("Selection/Select Next Sibling _#DOWN")]
    public static void SelectNext() {
        var selection = Selection.gameObjects;
        var newSelection = new List<GameObject>();
        GameObject[] rootGameObjects = null;

        if (selection.Length == 0) {
            rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
            newSelection.Add(rootGameObjects.First());
        }

        foreach (var obj in selection) {
            if (obj.transform.parent != null) {
                var parent = obj.transform.parent;
                int index = obj.transform.GetSiblingIndex() + 1;
                if (index >= 0 && index < parent.childCount) {
                    newSelection.Add(parent.GetChild(index).gameObject);
                } else {
                    newSelection.Add(obj);
                }
            } else {
                if (rootGameObjects == null) {
                    rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
                }
                var index = ArrayUtility.IndexOf(rootGameObjects, obj) + 1;
                if (index >= 0 && index < rootGameObjects.Length) {
                    newSelection.Add(rootGameObjects[index]);
                } else {
                    newSelection.Add(obj);
                }
            }
        }

        Selection.objects = newSelection.ToArray();
    }

    [MenuItem("Selection/Select Siblings _%#UP")]
    public static void SelectSiblings() {
        var selection = Selection.gameObjects;
        var newSelection = new List<GameObject>();
        GameObject[] rootGameObjects = null;

        foreach (var obj in selection) {
            if (obj.transform.parent != null) {
                newSelection.AddRange(obj.transform.parent.gameObject.GetChildren());
            } else {
                if (rootGameObjects == null) {
                    rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
                }

                newSelection.AddRange(rootGameObjects);
            }
        }

        Selection.objects = newSelection.ToArray();
    }

    [MenuItem("Selection/Select Parent _%UP")]
    public static void SelectParent() {
        var selection = Selection.gameObjects;
        var newSelection = new List<GameObject>();

        foreach (var obj in selection) {
            if (obj.transform.parent != null)
                newSelection.Add(obj.transform.parent.gameObject);
        }

        Selection.objects = newSelection.ToArray();
    }

    [MenuItem("Selection/Select All Children _%DOWN")]
    public static void SelectChildren() {
        var selection = Selection.gameObjects;

        var newSelection = new List<GameObject>();
        foreach (var obj in selection) {
            foreach (var child in obj.transform.GetChildren()) {
                newSelection.Add(child.gameObject);
            }
        }

        Selection.objects = newSelection.ToArray();
    }

    [MenuItem("Selection/Select First Child _%#DOWN")]
    public static void SelectFirstChild() {
        var selection = Selection.gameObjects;

        var newSelection = new List<GameObject>();
        foreach (var obj in selection) {
            if (obj.transform.childCount > 0) {
                var child = obj.transform.GetChild(0);
                newSelection.Add(child.gameObject);
            }
        }

        Selection.objects = newSelection.ToArray();
    }

    [MenuItem("Selection/Select Nth Children _%&DOWN")]
    public static void SelectNthChild() {
        InputNumberWindow window = ScriptableObject.CreateInstance<InputNumberWindow>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }
}
}
