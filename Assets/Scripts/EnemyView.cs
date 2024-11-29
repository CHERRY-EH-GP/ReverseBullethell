using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    SpriteRenderer enemy;

    void UpdateHealthState(Vector3 health)
    {
        enemy.color = new Color(health.x, health.y, health.z, 1);
    }

}

public class EntityData
{
    Vector2 position, LookDirection;

    float collisionRange = 1f;

    Vector3 health;

    bool dropReward;

    void InitHealth()
    {
        int r = Random.Range(0, 256);
        int g = Random.Range(0, 256);
        int b = Random.Range(0, 256);

        health = new Vector3(r, g, b);
    }

    void TakeDamage(float damage)
    {

        float selectedHealthbar = Mathf.Min(health.x, health.y);
    }

}
