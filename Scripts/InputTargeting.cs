using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTargeting : MonoBehaviour
{
    public GameObject selectedHero;
    public bool heroPlayer;
    RaycastHit hit;


    void Start()
    {
        selectedHero = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<Targetable>() != null)
                {
                    if (hit.collider.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
                    {
                        selectedHero.GetComponent<HeroCombat>().targetEnemy = hit.collider.gameObject;
                    }
                    else if (hit.collider.gameObject.GetComponent<Targetable>() == null)
                    {
                        selectedHero.GetComponent<HeroCombat>().targetEnemy = null;
                    }
                }

            }

        }




    }
}
