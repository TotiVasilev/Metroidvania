using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    [SerializeField] private LevelWIndow levelWIndow;
    [SerializeField] private MovePlayer player;
    [SerializeField] private BasicEnemyController[] enemy;
    private void Awake()
    {
        BasicEnemyController[] enemy = FindObjectsOfType<BasicEnemyController>();
        LevelSystem levelSystem = new LevelSystem();
        levelWIndow.SetLevelSystem(levelSystem);
        player.SetLevelSystem(levelSystem);
        foreach (BasicEnemyController enemyController in enemy)
        {
            enemyController.SetLevelSystem(levelSystem);
        }

        LevelSystemAnimated levelSystemAnimated = new LevelSystemAnimated(levelSystem);
        levelWIndow.SetLevelSystemAnimated(levelSystemAnimated);
    }
}
