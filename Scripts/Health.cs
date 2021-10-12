using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Slider playerSlider3D;
    private Slider playerSlider2D;

    Stats statsScript;

    void Start()
    {
        statsScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();

        playerSlider2D = GetComponent<Slider>();

        playerSlider2D.maxValue = statsScript.maxHealth;
        playerSlider3D.maxValue = statsScript.maxHealth;
        statsScript.health = statsScript.maxHealth;

    }


    void Update()
    {
        playerSlider2D.value = statsScript.health;
        playerSlider3D.value = playerSlider2D.value;
    }
}
