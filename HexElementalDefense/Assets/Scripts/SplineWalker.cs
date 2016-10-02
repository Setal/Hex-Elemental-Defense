using Assets.Scripts.Math;
using UnityEngine;

namespace Assets.Scripts
{
    public enum SplineWalkerMode
    {
        Once,
        Loop,
        PingPong
    }

    public class SplineWalker : MonoBehaviour
    {
        public SplineWalkerMode mode;

        private bool goingForward = true;

        public bool lookForward;

        public BezierSpline spline;

        public float duration;

        private float progress;

        private void Update()
        {
            if (goingForward)
            {
                progress += Time.deltaTime / duration;
                if (progress > 1f)
                {
                    if (mode == SplineWalkerMode.Once)
                    {
                        progress = 1f;
                    }
                    else if (mode == SplineWalkerMode.Loop)
                    {
                        progress -= 1f;
                    }
                    else
                    {
                        progress = 2f - progress;
                        goingForward = false;
                    }
                }
            }
            else
            {
                progress -= Time.deltaTime / duration;
                if (progress < 0f)
                {
                    progress = -progress;
                    goingForward = true;
                }
            }

            Vector3 position = spline.GetPoint(progress);
            transform.localPosition = position;
            if (lookForward)
            {
                transform.LookAt(position + spline.GetDirection(progress));
            }
        }
    }
}