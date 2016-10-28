using System;
using Assets.Scripts.GameObjects.MapParts;
using Assets.Scripts.MapObjects;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Movement
{
    public class PointPathWalker : MonoBehaviour, IPathWalker
    {
        private int currentPoint;



        public Map Map;

        public bool WalkForward(float speed, Path path)
        {
            if (currentPoint == Map.Paths[0].Points.Count - 1)
            {
                return false;
            }

            var next = Map.Paths[0][currentPoint + 1];

            var targetRotation = Quaternion.LookRotation(Map[next].Position - transform.position);
            var str = Mathf.Min(3f * Time.deltaTime, 3);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);


            transform.position += transform.forward * Time.deltaTime * speed;

            float dist = Vector3.Distance(Map[next].Position, transform.position);

            if (dist <= 0.1)
            {
                currentPoint++;
            }

            return true;
        }

        // Use this for initialization
        void Start()
        {
            currentPoint = 0;            
        }

        // Update is called once per frame
        void Update()
        {
            WalkForward(0.5f,Map.Paths[0]);          
        }
    }
}
