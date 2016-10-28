using Assets.Scripts.MapObjects;
using UnityEngine;

namespace Assets.Scripts.GameObjects.Movement
{
    public interface IPathWalker
    {
        bool WalkForward(float speed, Path path);
    }
}
