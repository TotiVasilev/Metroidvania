using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    //in the inspector, attach this script to the 2 teleport objecs, the destination transform for teleport 1 is teleport 2 and so on
    [SerializeField] private Transform destination; //position of the other teleport


    public Transform GetDestination()//Make it public, use it in PlayerTeleport script
    {
        return destination;
    }
    
}
