using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingLeveling : MonoBehaviour
{
    [SerializeField] private LevelWIndow levelWIndow;
    private void Awake()
    {
        LevelSystem levelSystem = new LevelSystem();
        Debug.Log(levelSystem.GetLevelNumber());
        levelSystem.AddExperience(50);
        Debug.Log(levelSystem.GetLevelNumber());
        levelSystem.AddExperience(60);
        Debug.Log(levelSystem.GetLevelNumber());


        levelWIndow.SetLevelSystem(levelSystem);
    }
}
