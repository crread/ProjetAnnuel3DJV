using System.Collections.Generic;
using UnityEditor;
using UnityEditor.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Tools
{
    public class CreateNavMeshsTool : EditorWindow
    {

        private bool _noneNavmeshObjectInScene = true; 
        
        [MenuItem("Window/navmeshs baker")]
        private static void Init()
        {
            CreateNavMeshsTool window = (CreateNavMeshsTool) EditorWindow.GetWindow(typeof(CreateNavMeshsTool));
            window.minSize = new Vector2(300, 400);
            window.Show();
        }
        
        private void OnGUI()
        {
            _noneNavmeshObjectInScene = true;

            if (GameObject.Find("NavMesh Player") != null)
            {
                _noneNavmeshObjectInScene = false;
                GUILayout.Label("Bake player navMesh", EditorStyles.boldLabel);

                var go = GameObject.Find("NavMesh Player");
                ClickManager(go);
            }

            if (GameObject.Find("Navmesh Flag") != null)
            {
                _noneNavmeshObjectInScene = false;
                GUILayout.Label("Bake flag navMesh", EditorStyles.boldLabel);
                
                var go = GameObject.Find("Navmesh Flag");
                ClickManager(go);
            }

            if (_noneNavmeshObjectInScene)
                GUILayout.Label("None Navmesh implemented in the scene", EditorStyles.boldLabel);
            else
            {
                GUILayout.Label("Bake all navMesh", EditorStyles.boldLabel);

                List<GameObject> goArray = new List<GameObject>();

                if (GameObject.Find("Navmesh Flag") != null)
                    goArray.Add(GameObject.Find("Navmesh Flag"));

                if (GameObject.Find("NavMesh Player") != null)
                    goArray.Add(GameObject.Find("NavMesh Player"));
                
                if (GUILayout.Button("Bake"))
                {
                    foreach (var go in goArray)
                    {
                        Bake(go);
                    }
                }
                
                GUILayout.Label("Clear all navMesh", EditorStyles.boldLabel);
                
                if (GUILayout.Button("Clear"))
                {
                    foreach (var go in goArray)
                    {
                        Clear(go);
                    }
                }
            }
        }

        private void ClickManager(GameObject go)
        {
            if (GUILayout.Button("Bake"))
            {
                Bake(go);
            }

            if (GUILayout.Button("Clear"))
            {
                Clear(go);
            }
        }
        
        private void Bake(GameObject go)
        {
            var navMeshSurface = go.GetComponent<NavMeshSurface>();
            navMeshSurface.BuildNavMesh();
            Object[] surfaces = {navMeshSurface};
            var navMeshManager = CreateInstance<NavMeshAssetManager>();
            navMeshManager.StartBakingSurfaces(surfaces);
        }

        private void Clear(GameObject go)
        {
            var navMeshSurface = go.GetComponent<NavMeshSurface>();
            Object[] surfaces = {navMeshSurface};
            var navMeshManager = CreateInstance<NavMeshAssetManager>();
            navMeshManager.ClearSurfaces(surfaces);
        }
    }
}
