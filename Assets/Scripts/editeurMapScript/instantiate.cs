using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{

    public Transform[] prefab;
    public Transform[] clone;
  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Awake()
    {
       
    }
    void Update()
    {

        // Instantiate the projectile at the position and rotation of this transform


        
        // Give the cloned object an initial velocity along the current
        // object's Z axis
        //clone.velocity = transform.TransformDirection(Vector3.forward * 10);

    }
 
    public void instance()
    {
        
        GameObject g = GameObject.Find("scripts");
       
        for(int i=0;i<1;i++)
         clone[0] = Instantiate(prefab[0], new Vector3(g.GetComponent<sliderTransform>().positionX, g.GetComponent<sliderTransform>().positionY + (i*2), g.GetComponent<sliderTransform>().positionZ), transform.rotation);
       
    }
    public void instance_2()
    {
        GameObject g = GameObject.Find("scripts");

        for (int i = 0; i < 1; i++)
            clone[1] = Instantiate(prefab[1], new Vector3(g.GetComponent<sliderTransform>().positionX, g.GetComponent<sliderTransform>().positionY + (i * 2), g.GetComponent<sliderTransform>().positionZ), transform.rotation);
    }
}

