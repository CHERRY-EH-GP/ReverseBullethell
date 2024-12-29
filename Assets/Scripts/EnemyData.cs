using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

