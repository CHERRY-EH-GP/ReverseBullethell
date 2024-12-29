using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour, IEntityView
{
    public SpriteRenderer sprite;

    public void UpdateHealthColor(Vector3 health)
    {
        sprite.color = new Color(health.x, health.y, health.z, 1f); // Alpha range is 0-1
    }

    public void UpdatePositionAndRotation(Vector3 position, Vector3 lookDir)
    {
        transform.position = position;
        transform.up = lookDir;
    }
    
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive); // Delegate to the GameObject
    }
}