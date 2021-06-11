using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operation : MonoBehaviour
{
    public bool translate;
    public bool rotate;
    public bool scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void translation()
    {
        translate = true;
        rotate = false;
        scale = false;
    }
    public void rotation()
    {
        rotate = true;
        translate = false;
        scale = false;
    }
    public void scaling()
    {
        rotate = false;
        translate = false;
        scale = true;
    }
   
}
