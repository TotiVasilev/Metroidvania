using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaySelected : MonoBehaviour, ISelectHandler
{
    public GameObject WalkingAnim;
    public GameObject IsAttackingAnim;
    public GameObject EnemiAnim;
    public void OnSelect(BaseEventData eventData)
    {
        WalkingAnim.SetActive(true);
        IsAttackingAnim.SetActive(false);
        EnemiAnim.SetActive(false);
    }

    
}