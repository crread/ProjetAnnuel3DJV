using UnityEngine;

namespace Map
{
    public class CameraControl : MonoBehaviour
    {
        public Transform camera;
        public Transform player;
        
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
    }
}
