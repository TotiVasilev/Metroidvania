using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLeveling : MonoBehaviour
{
    [SerializeField] private LevelWIndow levelWIndow;
    [SerializeField] private MovePlayer player;
    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        levelWIndow.SetLevelSystem(levelSystem);
        player.SetLevelSystem(levelSystem);

        LevelSystemAnimated levelSystemAnimated = new LevelSystemAnimated(levelSystem);
        levelWIndow.SetLevelSystemAnimated(levelSystemAnimated);
    }
}
