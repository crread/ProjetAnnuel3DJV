using Game.Minions;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace tools
{
    public class ToolAnalyticMinionPathFinding : Editor
    {
        private static bool _showPath = false;
        private static bool _statusPath = false;
        private static bool _guiContextShow = false;
        private static GameObject _gameObjectSelected;

        [MenuItem("Window/Scene GUI/NavMeshAnalytic")]
        public static void NavMeshAnalytic()
        {
            if (!_guiContextShow)
                SceneView.duringSceneGui += OnScene;
            else
                SceneView.duringSceneGui -= OnScene;
            
            _guiContextShow = !_guiContextShow;
        }
        
        private static void DisplayDataFromToggle()
        {
            if (_gameObjectSelected && _gameObjectSelected.CompareTag("minion"))
            {
                if (_gameObjectSelected.GetComponent<Minion>().positionObjectToFollow)
                {
                    var positionObjectToFollow = _gameObjectSelected.GetComponent<Minion>().positionObjectToFollow.position;
                    var nextPositionToGo = _gameObjectSelected.GetComponent<NavMeshAgent>().nextPosition;
                    
                    if (_showPath)
                    {
                        Debug.DrawLine(_gameObjectSelected.transform.position, nextPositionToGo, Color.blue);
                        Debug.DrawLine(nextPositionToGo, positionObjectToFollow, Color.red);    
                    }

                    if (_statusPath)
                    {
                        Debug.Log(_gameObjectSelected.GetComponent<NavMeshAgent>().path.status);
                    }
                }
            }
        }
        
        private static void OnScene(SceneView sceneview)
        {
            GUILayout.BeginArea(new Rect(new Vector2(5,5), new Vector2(200,300)));
            _showPath = GUILayout.Toggle(_showPath, "show the curent path of the object selected");
            _statusPath = GUILayout.Toggle(_statusPath, "show the status of the path");
            GUILayout.EndArea();
            _gameObjectSelected = Selection.activeGameObject;
            DisplayDataFromToggle();
        }
    }
}
