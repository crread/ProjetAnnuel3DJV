using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_scene : MonoBehaviour
{

    public dataManager data;
    public Text coins;
    public instantiate inst;
   
   
    // Start is called before the first frame update
 
    void Start()
    {
        data.load();
        coins.text = data.data.coins.ToString();
        inst.clone[0].transform.position=data.data.posMap;
    }
    public void ClickCoins()
    {
        data.data.coins += 1;
       
        coins.text = data.data.coins.ToString();
        data.data.posMap.x += 0.5f;
    }
    public void ClickSave()
    {
       
        data.save();
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
