using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public float damage;
    public GameObject target;

    public bool targetSet = false;
    public string targetType;
    public float velocity = 5;
    public bool stopProjectile;




    void Update()
    {
        if (targetSet)
        {
            if (target == null)
            {
                Destroy(gameObject);
            }
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocity * Time.deltaTime);

            if (!stopProjectile)
            {
                if (Vector3.Distance(transform.position, target.transform.position) < 0.5f)
                {
                    if (targetType == "Minion")
                    {
                        target.GetComponent<Stats>().health -= damage;
                        stopProjectile = true;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
