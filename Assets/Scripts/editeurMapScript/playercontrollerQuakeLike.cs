using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrollerQuakeLike : MonoBehaviour
{
    [SerializeField]
    private Transform playerController;
    [SerializeField]
    private Transform playerEyesController;
    [SerializeField]
    private float speedController;
    [SerializeField]
    private float pitchSpeedRotation;
    [SerializeField]
    private float yawSpeedRotation;
    [SerializeField]
    private Vector3 lastDirection;
    [SerializeField]
    private float rotationIntent;
    private bool rotationIntentBool;
    private Vector2 lastMousePosition;
    private float lastPitchIntent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject t = GameObject.Find("scripts");
        float speedCamControl = t.transform.GetComponent<sliderSpeedControl>().speedCam;
        speedController = speedCamControl;
        lastDirection = Vector3.zero;
        rotationIntent = 0.0f;
        rotationIntent = Input.mousePosition.x - lastMousePosition.x;
        lastPitchIntent = Input.mousePosition.y - lastMousePosition.y;
        lastMousePosition = Input.mousePosition;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            lastDirection+= Vector3.right;
            //rotationIntent += 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
             lastDirection -= Vector3.right;
            //rotationIntent -= 1.0f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            lastDirection += Vector3.up;
            //rotationIntent += 1.0f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            lastDirection -= Vector3.up;
            //rotationIntent -= 1.0f;
        }
        if (Input.GetAxis("Mouse ScrollWheel")<0f)
        {
            lastDirection -= Vector3.forward;
        }
        if  (Input.GetAxis("Mouse ScrollWheel")>0f)
            {
            lastDirection += Vector3.forward;
        }
        lastDirection = lastDirection.normalized;



    }

    void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            playerController.Rotate(0f, rotationIntent * yawSpeedRotation * Time.fixedDeltaTime, 0f);
            playerEyesController.Rotate(-lastPitchIntent * pitchSpeedRotation * Time.fixedDeltaTime, 0f, 0f);

            var rotationX = playerEyesController.rotation.eulerAngles.x;
            if (rotationX > 180f)
            {
                rotationX = -360f + rotationX;
            }

            playerEyesController.localRotation = Quaternion.Euler(Mathf.Clamp(rotationX, -80f, 80f), 0f, 0f);
        }
        playerController.position += playerController.rotation * lastDirection * (speedController * Time.fixedDeltaTime);

    }
}