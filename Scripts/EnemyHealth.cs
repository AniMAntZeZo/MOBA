using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public Slider enemySlider3D;


    Stats statsScript;

    void Start()
    {
        statsScript = GetComponent<Stats>();

        enemySlider3D.maxValue = statsScript.maxHealth;
       // statsScript.health = statsScript.maxHealth;

    }


    void Update()
    {
        enemySlider3D.value = statsScript.health;
    }
}
