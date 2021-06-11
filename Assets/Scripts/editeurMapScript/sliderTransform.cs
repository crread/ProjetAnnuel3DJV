using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderTransform : MonoBehaviour
{
    public float positionX = 0.0f;
    public float positionY = 0.0f;
    public float positionZ = 0.0f;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ajustPositionX(float newPositionX)
    {
        positionX = newPositionX;
      
    }
    public void ajustPositionY(float newPositionY)
    {
        positionY = newPositionY;

    }
    public void ajustPositionZ(float newPositionZ)
    {
        positionZ = newPositionZ;

    }
    
}
