using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

