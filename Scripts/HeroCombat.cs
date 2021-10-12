using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCombat : MonoBehaviour
{
    public enum HeroAttackType { Melee, Ranged }
    public HeroAttackType heroAttakType;

    public GameObject targetEnemy;
    public float attackRange;
    public float rangedAttackRange;
    public float rotateSpeedForAttack;

    private PlayerController moveScript;
    private Stats statsSkript;
    private Animator anim;

    public bool basicAtkIdle = false;
    public bool isHeroAlive;
    public bool perfomMeleeAttack = true;

    [Header("Ranged Varialbes")]
    public bool perfomRangedAttack = true;
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    void Start()
    {
        moveScript = GetComponent<PlayerController>();
        statsSkript = GetComponent<Stats>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (targetEnemy != null)
        {

            //MELEE ATTACK
            if (heroAttakType == HeroAttackType.Melee)
            {
                if (Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position) > attackRange)
                {
                    moveScript.agent.SetDestination(targetEnemy.transform.position);
                    moveScript.agent.stoppingDistance = attackRange - 0.175f;

                }
                else
                {

                    Quaternion rotationOnLookAt = Quaternion.LookRotation(targetEnemy.transform.position - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationOnLookAt.eulerAngles.y,
                        ref moveScript.rotatVelosity,
                        rotateSpeedForAttack * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0f, rotationY, 0f);

                    moveScript.agent.SetDestination(transform.position);

                    if (perfomMeleeAttack)
                    {
                        StartCoroutine(MeleeAttackInterval());
                    }
                }
            }

            //RANGED ATTACK
            if (heroAttakType == HeroAttackType.Ranged)
            {
                if (Vector3.Distance(gameObject.transform.position, targetEnemy.transform.position) > rangedAttackRange)
                {
                    moveScript.agent.SetDestination(targetEnemy.transform.position);
                    moveScript.agent.stoppingDistance = attackRange - 0.175f;

                }
                else
                {

                    Quaternion rotationOnLookAt = Quaternion.LookRotation(targetEnemy.transform.position - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationOnLookAt.eulerAngles.y,
                        ref moveScript.rotatVelosity,
                        rotateSpeedForAttack * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0f, rotationY, 0f);

                    moveScript.agent.SetDestination(transform.position);

                    if (perfomRangedAttack)
                    {
                        StartCoroutine(RangedAttackInterval());
                    }
                }
            }
        }
    }

    IEnumerator MeleeAttackInterval()
    {
        perfomMeleeAttack = false;
        anim.SetBool("Basic Attack", true);

        yield return new WaitForSeconds(statsSkript.attakTime / ((100 + statsSkript.attakTime) * 0.01f));

        if (targetEnemy == null)
        {
            anim.SetBool("Basic Attack", false);
            perfomMeleeAttack = true;
        }
    }

    IEnumerator RangedAttackInterval()
    {
        perfomRangedAttack = false;
        anim.SetBool("Ranged Attack", true);

        yield return new WaitForSeconds(statsSkript.attakTime / ((100 + statsSkript.attakTime) * 0.01f));

        if (targetEnemy == null)
        {
            anim.SetBool("Ranged Attack", false);
            perfomRangedAttack = true;
        }
    }

    public void MeleeAttack()
    {
        if (targetEnemy != null)
        {
            if (targetEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
            {
                targetEnemy.GetComponent<Stats>().health -= statsSkript.attakDmg;
            }
        }

        perfomMeleeAttack = true;
    }

    public void RangedAttack()
    {
        if (targetEnemy != null)
        {
            if (targetEnemy.GetComponent<Targetable>().enemyType == Targetable.EnemyType.Minion)
            {
                SpawnRangedProj("Minion", targetEnemy);
            }
        }

        perfomRangedAttack = true;
    }

    void SpawnRangedProj(string typeEnemy, GameObject targetedEnemyObj)
    {
        float dmg = statsSkript.attakDmg;

        GameObject bullet = Instantiate(projPrefab, projSpawnPoint.transform.position, Quaternion.identity);

        if (typeEnemy == "Minion")
        {
            bullet.GetComponent<RangedAttack>().targetType = typeEnemy;

            bullet.GetComponent<RangedAttack>().target = targetedEnemyObj;
            bullet.GetComponent<RangedAttack>().targetSet = true;

        }
    }

}
