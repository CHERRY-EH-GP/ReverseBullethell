using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Manager : MonoBehaviour
{
    [Header("Settings")]
    public CameraBounds cameraBounds;

    public EnemyView enemyView;

    public PlayerView playerView;

    [Tooltip("Spawn distance from player")]
    public float spawnDistance = 30f;



    Dictionary<EnemyData, EnemyView> enemies = new Dictionary<EnemyData, EnemyView>();
    PlayerData playerData;


    public void Awake()
    {
        playerData = new PlayerData(new Vector2(0,0), 500f);

        GenerateEnemies(100);
        // Enemies Attack must have a delay 
    }

    public void FixedUpdate()
    {
        UpdateAI();
    }

    private void UpdateAI()
    {
        foreach (KeyValuePair<EnemyData, EnemyView> enemy in enemies)
        {
            UpdateDataMovement(enemy);
            UpdateView(enemy);

            if (!enemy.Key.isInView) continue;
            
            UpdateViewMovement(enemy);
            //CheckCollisions(enemy);
        }
    }

    private void UpdateView(KeyValuePair<EnemyData, EnemyView> enemy)
    {

        enemy.Key.isInView = cameraBounds.bounds.Contains(enemy.Key.Position);

        // TODO MAKE A POOL
        enemy.Value.gameObject.SetActive(enemy.Key.isInView);
    }

    private void  UpdateViewMovement(KeyValuePair<EnemyData, EnemyView> enemy)
    {
        // Handle Movement - EnemyView
        enemy.Value.UpdatePositionAndRotation(enemy.Key.Position, playerData.Position - enemy.Key.Position);
    }

    private void UpdateDataMovement(KeyValuePair<EnemyData, EnemyView> enemy)
    {
        // Handle Movement - EnemyData
        Vector2 newPosition = Vector2.MoveTowards(enemy.Key.Position, playerData.Position, enemy.Key.GetSpeed() * Time.deltaTime);
        enemy.Key.Position = newPosition;
    }

    private void CheckCollisions(KeyValuePair<EnemyData, EnemyView> enemy)
    {
        // Handle "Collisions"
        float dist = Vector2.Distance(enemy.Key.Position, playerData.Position);
        if (dist < enemy.Key.GetCollRange() + playerData.GetCollRange())
        {
            playerData.TakeDamage(0);
            enemy.Key.TakeDamage(20f);
        }
    }

    public void GenerateEnemies(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Vector3 assignedPos = playerView.transform.position + GetSpawnPoint();

            EnemyView _enemyView = Instantiate(enemyView, assignedPos, Quaternion.identity, transform);

            EnemyData _EnemyData = new EnemyData(assignedPos, 256f, true);
            // TODO add some kind of reward
            //Random.value < 0.5f

            enemies.Add(_EnemyData, _enemyView);
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return Random.insideUnitCircle.normalized * new Vector3(1,1,0) * spawnDistance;
    }
}


