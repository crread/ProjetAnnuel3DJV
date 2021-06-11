using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sliderSpeedControl : MonoBehaviour
{
    public float speedTranslate=1.0f;
    public float speedRotate = 1.0f;
    public float speedScale = 1.0f;
    public float speedCam = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ajustSpeedTranslate(float newSpeedT)
    {
        speedTranslate = newSpeedT;
    }
    public void ajustSpeedRotate(float newSpeedRot)
    {
        speedRotate = newSpeedRot;
    }
    public void ajustSpeedScale(float newSpeedScale)
    {
        speedScale = newSpeedScale;
    }
    public void ajustCamControl(float newSpeedCam)
    {
        speedCam = newSpeedCam;
    }
}
