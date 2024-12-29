using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityType
{
    Player,
    Enemy1
}

public class EntityData
{
    EntityType type;

    //variables

    protected Vector2 position;
    public Vector2 Position { get { return position; } set { position = value; } }

    public Vector2 LookDirection;

    protected float collisionRange = 1f;

    protected float health;

    protected float speed = 5;

    public bool isInView;

    //methods
    public virtual void TakeDamage(float damage){ health -= damage;  }
    public virtual void InitHealth(float value) { health = value; }


    public float GetCollRange() { return collisionRange; }

    public float GetSpeed(){ return speed; }
}
