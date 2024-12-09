using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Manager : MonoBehaviour
{
    public EnemyView enemyView;

    public PlayerView playerView;

    [Tooltip("Spawn distance from player")]
    public float spawnDistance = 30f;

    Dictionary<EnemyData, EnemyView> enemies;

    PlayerData playerData;


    public void Awake()
    {
        playerData = new PlayerData(new Vector2(0,0), 500f);

        GenerateEnemies(100);

        // Enemies Attack must have a delay 
    }

    public void FixedUpdate()
    {
        foreach(KeyValuePair<EnemyData, EnemyView> enemyObject in enemies)
        {
            if (!enemyObject.Key.isInView) continue;

            float dist = Vector2.Distance(enemyObject.Key.GetPosition(), playerData.GetPosition());
            if(dist < enemyObject.Key.GetCollRange() + playerData.GetCollRange())
            {
                playerData.TakeDamage(0);
                enemyObject.Key.TakeDamage(700f);
            }
        }
    }

    public void GenerateEnemies(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Vector3 assignedPos = playerView.transform.position + GetSpawnPoint();

            EnemyView _enemyView = Instantiate(enemyView, assignedPos, Quaternion.identity, transform);

            EnemyData _EnemyData = new EnemyData(assignedPos, Random.value < 0.5f, 256f);
            // TODO add some kind of reward

            enemies.Add(_EnemyData, _enemyView);
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return Random.insideUnitCircle.normalized * new Vector3(1,1,0) * spawnDistance;
    }
}


