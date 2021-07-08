using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class PrefabCreator : EditorWindow
{

    private string[] _primitiveOptions = new string[] {"Sphere", "Capsule", "Cylinder", "Cube", "Plane", "Quad"};
    private int _primitiveMeshIndex = 0;

    private string[] _selectTypeOptions = new string[] {"primitive meshs", "personnal mesh"};
    private int _selectTypeOptionsIndex = 0;
    
    private GameObject mesh;

    private bool _selectPrimitiveMesh = true;
    private string _personalMeshPath = "select a file (obj)";
    
    [MenuItem("Window/New prefab")]
    private static void Init()
    {
        PrefabCreator window = (PrefabCreator) EditorWindow.GetWindow(typeof(PrefabCreator));
        window.minSize = new Vector2(300, 400);
        window.Show();
    }
    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);

        _selectTypeOptionsIndex = EditorGUILayout.Popup(_selectTypeOptionsIndex, _selectTypeOptions);
        
        if (_selectTypeOptionsIndex == 0)
            _primitiveMeshIndex = EditorGUILayout.Popup(_primitiveMeshIndex, _primitiveOptions);
        else
            _personalMeshPath = EditorGUILayout.TextField("Text Field", _personalMeshPath);

        if (GUILayout.Button("Create"))
            InstantiatePrimitive();
    }

    private void InstantiatePrimitive()
    {
        switch (_primitiveMeshIndex) {
            case 0:
                mesh = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            case 1:
                mesh = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                break;
            case 2:
                mesh = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                break;
            case 3:
                mesh = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case 4:
                mesh = GameObject.CreatePrimitive(PrimitiveType.Plane);
                break;
            case 5:
                mesh = GameObject.CreatePrimitive(PrimitiveType.Quad);
                break;
        }
    }

    private void Example()
    {
        Texture2D texture = Selection.activeObject as Texture2D;

        ObjImporter newMesh = new ObjImporter();
        
        if (texture == null)
        {
            EditorUtility.DisplayDialog("Select Texture", "You must select a texture", "OK");
        }

        string path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");

        if (path.Length != 0)
        {
            var fileContent = File.ReadAllBytes(path);
            texture.LoadImage(fileContent);
        }
    }
}
