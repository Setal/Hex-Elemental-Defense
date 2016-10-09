using UnityEngine;

namespace Assets.Scripts.MainMenu
{
    public class LightRotator : MonoBehaviour
    {

        public float Speed=20;


        // Update is called once per frame
        void Update ()
        {
	        transform.Rotate(Vector3.up * Time.deltaTime * Speed, Space.World);
        }
    }
}
