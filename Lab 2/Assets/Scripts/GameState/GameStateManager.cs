using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    //public List<MapState> mapStates = new List<MapState>();
    public GameState gameState;
    public Transform mapParent;

    //public TopDownPlayerMovement player;
    //private int playerHP; 

    private EnemySpawner spawner;
    private int currentMapID;
    private MapState currentMapState;

    private int treasureCollected;

    public int TreasureCollected { get => treasureCollected; set => treasureCollected = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        

        foreach (MapState mapState in gameState.mapStates)
        {
            mapState.InitializeDictionary();
        }

        InitializeMap(0);
    }
    public void InitializeMap(int mapID_)
    {

        foreach (MapState mapState in gameState.mapStates)
        {
            if (mapState.mapID == mapID_)
            {
                currentMapState = mapState;
                BeginEnemySpawn(currentMapState);
                break;
            }
        }
    }

    public void BeginEnemySpawn(MapState map)
    {
        spawner = mapParent.GetComponentInChildren<EnemySpawner>();
        foreach (EnemyState enemy in map.enemyStates)
        {

            if (enemy.currentHP > 0) spawner.Spawn(enemy.enemyID, enemy.currentHP);
        }
    }

    [ContextMenu("Try Save")]
    public void SaveGameState()
    {
        if (spawner != null)
        {
            List<Enemy> enemies = spawner.activeEnemies;
            Debug.Log(spawner.activeEnemies);
            foreach (Enemy enemy in enemies)
            {
                currentMapState.enemyDictionary[enemy.enemyID].currentHP = enemy.HP;
                Debug.Log(currentMapState.enemyDictionary[enemy.enemyID].currentHP);

            }
        }
    }
    
}

[Serializable]
public class MapState
{
    public int mapID;
    public List<EnemyState> enemyStates;
    [NonSerialized] public Dictionary<int, EnemyState> enemyDictionary;

    public void InitializeDictionary()
    {
        enemyDictionary = new Dictionary<int, EnemyState>();
        foreach (EnemyState enemy in enemyStates)
        {
            enemyDictionary.Add(enemy.enemyID, enemy);
        }
    }
}

[Serializable]
public class EnemyState
{
    public int enemyID;
    public int currentHP;
}

[Serializable]
public class GameState
{
    public List<MapState> mapStates;
    public int playerHP;
    public int treasure;
}