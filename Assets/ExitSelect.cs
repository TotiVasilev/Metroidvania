using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExitSelect : MonoBehaviour, ISelectHandler
{
    public GameObject EnemiAnim;
    public GameObject IsAttackingAnim;
    public GameObject WalkingAnim;
    public void OnSelect(BaseEventData eventData)
    {
        EnemiAnim.SetActive(true);
        IsAttackingAnim.SetActive(false);
        WalkingAnim.SetActive(false);
    }
}
