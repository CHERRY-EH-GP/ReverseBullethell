using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    SpriteRenderer sprite;

    void UpdatePositionAndRotation(Vector3 position, Vector3 lookDir)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(lookDir);
    }
}
