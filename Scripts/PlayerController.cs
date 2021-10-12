using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    private Camera mainCamera;

    public float rotatSpeedMovent = 1f;
    public float rotatVelosity;

    private HeroCombat heroCombatScript;

    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();

        heroCombatScript = GetComponent<HeroCombat>();
    }

    void Update()
    {

        if (heroCombatScript.targetEnemy != null)
        {

            if (heroCombatScript.targetEnemy.GetComponent<HeroCombat>() != null)
            {
                if (!heroCombatScript.targetEnemy.GetComponent<HeroCombat>().isHeroAlive)
                {
                    heroCombatScript.targetEnemy = null;
                }
            }

        }




        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Floor")
                {
                    agent.SetDestination(hit.point);
                    heroCombatScript.targetEnemy = null;
                    agent.stoppingDistance = 0f;

                    Quaternion rotationOnLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationOnLookAt.eulerAngles.y,
                        ref rotatVelosity,
                        rotatSpeedMovent * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0f, rotationY, 0f);
                }


            }
        }
    }



}
