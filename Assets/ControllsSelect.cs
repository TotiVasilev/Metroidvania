using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControllsSelect : MonoBehaviour, ISelectHandler
{
    public GameObject WalkingAnim;
    public GameObject IsAttackingAnim;
    public GameObject EnemiAnim;
    public void OnSelect(BaseEventData eventData)
    {
        WalkingAnim.SetActive(false);
        IsAttackingAnim.SetActive(true);
        EnemiAnim.SetActive(false);
    }
}
