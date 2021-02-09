using UnityEngine;

namespace Map
{
    public class CameraControl : MonoBehaviour
    {
        public Transform camera;
        public Transform player;

        //private float FLOAT_TOLERANCE = 0.0001f;
        private Vector3 _offset = Vector3.zero;
        void Start()
        {
            _offset = new Vector3(camera.position.x - player.position.x,
                camera.position.y - player.position.y, 
                camera.position.z - player.position.z);
            camera.LookAt(player);
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButton(1))
            {
                rotateCamera();
            }

            transform.position = player.position + _offset;
            transform.LookAt(player.position);
        }

        private void rotateCamera()
        {
            _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * _offset;
            _offset = Quaternion.AngleAxis(Input.GetAxis("Mouse Y") * 4f, Vector3.left) * _offset;
        }
    
        /* void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetAxis("Mouse ScrollWheel") < 0f )
        {
            ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));
        }
        
        if (Math.Abs(camera.position.x - player.position.x) > FLOAT_TOLERANCE || 
            Math.Abs(camera.position.y - player.position.y) > FLOAT_TOLERANCE)
        {
            UpdateCameraPosition();
        }
    }

    private void UpdateCameraPosition()
    {
        camera.position = player.position + _offset;
    }

    private void ZoomCamera(float zoomCoef)
    {
        camera.LookAt(player);
        _offset.x += zoomCoef * 10f;
        _offset.y += zoomCoef * 10f;
    }

    private void RotateCamera()
    {
    }*/
    }
}
