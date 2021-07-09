using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct ComponentData
{
    public ComponentData(Component component)
    {
        id = component.GetInstanceID();
        type = component.GetType().ToString();
        parameters = new Dictionary<string, string>();
    }
    
    public int id;
    public string type;
    public Dictionary<string, string> parameters;
}

public struct GameObjectData
{
    public GameObjectData(GameObject go)
    {
        isActive = go.activeSelf;
        isStatic = go.isStatic;
        name = go.name;
        layer = go.layer;
        tag = go.tag;
        children = null;
        components = null;
    }
    
    public bool isActive;
    public bool isStatic;
    public string name;
    public int layer;
    public string tag;
    public GameObjectData[] children;
    public ComponentData[] components;

}
public class SaveMapScript : MonoBehaviour
{
    private GameObjectData[] _rootGameObjectData;
    private GameObject[] _rootGameObjects;
    private Scene _scene;

    private void Start()
    {
        _scene = SceneManager.GetActiveScene();
    }
    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            SaveMap();
        }
    }
    
    private void SaveMap()
    {
        GetRootHierarchyGameObjects();

        if (_rootGameObjects.Length > 0)
        {
            _rootGameObjectData = new GameObjectData[_rootGameObjects.Length];
            
            for (var i = 0 ; i < _rootGameObjects.Length ; i++)
            {
                Debug.LogWarning(_rootGameObjects[i].name + "\n\n\n");
                _rootGameObjectData[i] = ExtractGameObjectData(_rootGameObjects[i]);
            }
        }
    }
    
    private void GetRootHierarchyGameObjects()
    {
        _rootGameObjects = _scene.GetRootGameObjects();
    }

    private GameObjectData ExtractGameObjectData(GameObject go)
    {
        GameObjectData goData = new GameObjectData(go);
        var components = GetComponents(go);

        if (components.Length > 0)
        {
            goData.components = ExtractComponentsData(components);
        }

        // if (go.transform.childCount > 0)
        // {
        //     goData.children = new GameObjectData[go.transform.childCount];
        //     // GetChildren(rootGameObject);
        // }
        
        return goData;
    }
    
    private Component[] GetComponents(GameObject go) => go.GetComponents(typeof(Component));

    private ComponentData[] ExtractComponentsData(Component[] components)
    {
        var componentDataArray = new ComponentData[components.Length];
        
        for (var i = 0 ; i < components.Length ; i++)
        {
            Debug.LogError( "Type : " + components[i].GetType()+ "\n\n");
            componentDataArray[i] = GetParamsOfComponent(components[i]);
        }

        return componentDataArray;
    }
    
    private ComponentData GetParamsOfComponent(Component co)
    {
        ComponentData coData = new ComponentData(co);

        foreach (var field in co.GetType().GetFields())
        {
            if (field.IsPublic)
            {
                Object obj = co;
                Debug.Log("Type : " + field.FieldType + "  -----Value : " + field.GetValue(obj) + "   Name :" + field.Name + "\n");
            }
            
            // Debug.Log(" ## Name : " + property.Name + " // Type : " + property.PropertyType.ToString() + " -- Value :" + property.GetValue(co, null).ToString() + "\n" );
        }
        
        return coData;
    }
    
    private void GetChildren(GameObject go)
    {
        
    }
}
