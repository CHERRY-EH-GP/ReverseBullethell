using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Manager : MonoBehaviour
{
    [Header("Settings")]
    public CameraBounds cameraBounds;

    public EnemyView entityView;

    public PlayerView playerView;

    [Tooltip("Spawn distance from player")]
    public float spawnDistance = 30f;

    [Tooltip("Spawn quantity")]
    public float spawnCount = 30f;
    
    Dictionary<EntityData, IEntityView> enemies = new Dictionary<EntityData, IEntityView>();

    Dictionary<EntityData, EnemyData> neighboors = new Dictionary<EntityData, EnemyData>();
    float distance = 3f;

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
        foreach (KeyValuePair<EntityData, IEntityView> enemy in enemies)
        {
            UpdateDataMovement(enemy);
            UpdateView(enemy);

            if (!enemy.Key.isInView) continue;
            
            UpdateViewMovement(enemy);
            //CheckCollisions(enemy);
        }
    }

    private void UpdateView<T>(KeyValuePair<T, IEntityView> enemy) where T : EntityData
    {

        enemy.Key.isInView = cameraBounds.bounds.Contains(enemy.Key.Position);

        // TODO MAKE A POOL
        enemy.Value.SetActive(enemy.Key.isInView);
    }

    private void UpdateViewMovement<T>(KeyValuePair<T, IEntityView> enemy) where T : EntityData
    {
        // Handle Movement - EnemyView
        enemy.Value.UpdatePositionAndRotation(enemy.Key.Position, enemy.Key.LookDirection);
    }

    private void UpdateDataMovement<T>(KeyValuePair<T, IEntityView> enemy) where T : EntityData
    {
        // Handle Movement - EnemyData
        Vector2 newPosition = Vector2.MoveTowards(enemy.Key.Position, playerData.Position, enemy.Key.GetSpeed() * Time.deltaTime);
        enemy.Key.Position = newPosition;

        //Handle Rotation
        enemy.Key.LookDirection = playerData.Position - enemy.Key.Position;
    }

    private void UpdateNeighboors()
    {
        foreach (KeyValuePair<EntityData, IEntityView> enemy in enemies)
        {
            foreach (KeyValuePair<EntityData, IEntityView> enemyTarget in enemies)
            {
                if(Vector2.Distance(enemy.Key.Position, enemyTarget.Key.Position) < distance)
                {
                    if(neighboors.ContainsKey(enemy.Key))
                    {

                    }
                }
            }
        }
    }



    private void CheckCollisions<T>(KeyValuePair<T, IEntityView> enemy) where T : EntityData
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

            IEntityView entityView = Instantiate(this.entityView, assignedPos, Quaternion.identity, transform);

            EnemyData _EnemyData = new EnemyData(assignedPos, 256f, true);
            // TODO add some kind of reward
            //Random.value < 0.5f

            enemies.Add(_EnemyData, entityView);
        }
    }

    public Vector3 GetSpawnPoint()
    {
        return Random.insideUnitCircle.normalized * new Vector3(1,1,0) * spawnDistance;
    }
}


