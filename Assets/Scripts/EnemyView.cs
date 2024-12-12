using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public SpriteRenderer sprite;

    public void UpdateHealthColor(Vector3 health)
    {
        sprite.color = new Color(health.x, health.y, health.z, 256);
    }
    
    public void UpdatePositionAndRotation(Vector3 position,  Vector3 lookDir)
    {
        sprite.transform.position = position;
        sprite.transform.up = lookDir;
    }

    public Vector3 GetForward() { return transform.up; }
}


