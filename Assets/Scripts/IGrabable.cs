using UnityEngine;

public interface IGrabable
{
    void OnGrab();
    void OnRelease();
    void Move(Vector3 position);
}
