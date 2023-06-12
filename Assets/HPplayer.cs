using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPplayer : MonoBehaviour
{
    public CheckpointController deathController;
    public Slider hpSlider;
    public int maxHP = 100;
    private int currentHP;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
        
    }

    public void UpdateHP(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        hpSlider.value = currentHP;
    }
    // Update is called once per frame
    private void Update()
    {
        if (currentHP <= 0)
        {
            deathController.Die();
        }
    }
}
