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

public class EnemyData : EntityData
{
    //variables
    protected bool dropReward;

    protected Vector3 healthColor;

    //methods
    public override void InitHealth(float value)
    {
        value = Mathf.Clamp(value, 0, 256);

        // TODO Change random method  

        int r = (int)Random.Range(0, value);
        int g = (int)Random.Range(0, value);
        int b = (int)Random.Range(0, value);

        health = r + g + b;
        healthColor = new Vector3(r, g, b);
    }

    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);
        // TODO remove value from healthColor
    }

    public EnemyData(Vector3 startPos,  float health, bool isInView = false, bool dropReward = false)
    {
        position = startPos;
        InitHealth(health);

        // optional parameters
        this.isInView = isInView;
        this.dropReward = dropReward;
    }

}

public class PlayerData : EntityData
{
    //variables
    //methods
    public override void InitHealth(float value)
    {
        base.InitHealth(value);
    }

    public override void TakeDamage(float value)
    {
        base.TakeDamage(value);
    }

    public PlayerData(Vector3 startPos, float health)
    {
        position = startPos;
        InitHealth(health);
    }
}
