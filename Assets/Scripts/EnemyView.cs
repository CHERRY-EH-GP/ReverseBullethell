using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    SpriteRenderer sprite;

    void UpdateHealthColor(Vector3 health)
    {
        sprite.color = new Color(health.x, health.y, health.z, 256);
    }
    
    void UpdatePositionAndRotation(Vector3 position,  Vector3 lookDir)
    {
        transform.position = position;
        transform.rotation = Quaternion.LookRotation(lookDir);
    }
}


