using UnityEngine;

namespace Assets.Scripts
{
    public class TestCameraScript : MonoBehaviour
    {

        float horizontalSpeed = 4.0f;
        float verticalSpeed = 4.0f;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Fire2"))
            {
                var h = horizontalSpeed * Input.GetAxis("Mouse Y");
                var v = verticalSpeed * Input.GetAxis("Mouse X");
                transform.Rotate(h, v, 0);
            }

        }
    }
}
