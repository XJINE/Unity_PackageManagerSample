using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SampleEditorScript:Editor
{
    static SampleEditorScript()
    {
        SceneView.duringSceneGui += OnGUI;
    }

    static void OnGUI(SceneView sceneView)
    {
        Handles.BeginGUI();
        GUILayout.Label("SampleEditorScript");
        Handles.EndGUI();
    }
}