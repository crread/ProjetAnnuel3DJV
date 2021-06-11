using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speed = 0.0f;
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementKeyboard();
       
     
    }
    void MovementKeyboard()
    {
        if(Input.GetAxis("Vertical")>0)
        {
            transform.position += speed * Vector3.forward * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.position -= speed * Vector3.forward * Time.deltaTime;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position -= speed * Vector3.right * Time.deltaTime;
        }

    }

}
