using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public float attakDmg;
    public float attakSpeed;
    public float attakTime;

    HeroCombat heroCombatScript;

    private GameObject player;
    public float expValue;


    void Start()
    {
        heroCombatScript = GameObject.FindGameObjectWithTag("Player").GetComponent<HeroCombat>();
        player = GameObject.FindGameObjectWithTag("Player");
        health = maxHealth;
    }



    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            heroCombatScript.targetEnemy = null;
            heroCombatScript.perfomMeleeAttack = false;

            player.GetComponent<LvlUpStats>().SetExperience(expValue);
        }


    }
}
