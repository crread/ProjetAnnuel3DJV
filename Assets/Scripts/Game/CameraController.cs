using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    public float zoomSpeed;
    private float speed;

    public float minZoomDist;
    public float maxZoomDist;
    public GameObject Unit;
    private bool mod;

    private Camera cam;
    private Vector3 _offset = Vector3.zero;

    private void Awake()
    {
        cam = Camera.main;
        mod = true;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (mod == true)
            {
                mod = false;
            }
            else if (mod == false)
            {
                mod = true;
            }
        }
        Vector3 p = Unit.transform.position;

        if (mod == true)
        {
            FocusOnPosition(p);
        }
        else if (mod == false)
        {
            FocusOnCenter();
        }

        if (Input.GetMouseButton(1))
        {
            rotateCamera();
        }
        
       Move();
        Zoom();
    }

    private void rotateCamera()
    {
        if (mod == true)
        {
            _offset = new Vector3(cam.transform.position.x - Unit.transform.position.x,
                cam.transform.position.y - Unit.transform.position.y,
               cam.transform.position.z - Unit.transform.position.z);
        }
        else
        {
            _offset = new Vector3(cam.transform.position.x - transform.position.x,
                cam.transform.position.y - transform.position.y,
               cam.transform.position.z - transform.position.z);
        }

        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * _offset;
        _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * 4f, Vector3.left) * _offset;

        if (mod == true)
        {
            cam.transform.position = Unit.transform.position + _offset;

            cam.transform.LookAt(Unit.transform.position);
        }
        else
        {
            cam.transform.position = transform.position + _offset;

            cam.transform.LookAt(transform.position);
        }
    
    }

    void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = transform.forward * zInput + transform.right * xInput; // direction to move at
        transform.position += dir * moveSpeed * Time.deltaTime; // Move the camera, using Time.deltaTime  will convert moveSpeed to a second range and oesn't depend on frameRate
    }

    void Zoom()
    {
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        float dist = Vector3.Distance(transform.position, cam.transform.position);// distance between camera and center of the screen(her parent)

        if (dist < minZoomDist && scrollInput > 0.0f)// if we are already at the min
            return;
        else if (dist > maxZoomDist && scrollInput < 0.0f)// if we are already at the max
            return;

        cam.transform.position += cam.transform.forward * scrollInput * zoomSpeed;// direction of zoom = cam.transform.forwad(z axis ), 
    }

    public void FocusOnPosition(Vector3 pos)
    {
        if (mod == true)
        {
            transform.position = pos;

        }
    }
    public void FocusOnCenter()
    {
        if (mod == true)
        {
           // transform.position = transform.position;

        }
    }

}
