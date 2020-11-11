using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNPC : MonoBehaviour
{
    public Transform target;
    public GameObject gunObject;
    public float sightLimit = 32.0f;
    public float chaseRange = 24.0f;
    public float attackRange = 16.0f;
    public float attackRate = 1.0f;

    private float nextAttackTime = 0.0f;
    private NavMeshAgent _agent = null;
    private EnemyGun _gun = null;

    // Start is called before the first frame update
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _gun = gunObject.GetComponent<EnemyGun>();
        sightLimit *= sightLimit;
        chaseRange *= chaseRange;
        attackRange *= attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }

        RaycastHit hit;

        float distance = Vector3.SqrMagnitude(_agent.transform.position - target.position);

        if (distance < sightLimit)
        {
            if (Physics.Raycast(gunObject.transform.position, gunObject.transform.up, out hit, 5000.0f))
            {
                //Debug.Log(hit.transform.name);
            }

            if (hit.transform.name == "PlayerBody" || distance < chaseRange)
            {
                if (distance < attackRange && hit.transform.name == "PlayerBody")
                {
                    _agent.isStopped = true;
                    _agent.transform.LookAt(target);
                    if (nextAttackTime <= Time.realtimeSinceStartup)
                    {
                        _gun.Shoot();
                        nextAttackTime = Time.realtimeSinceStartup + attackRate;
                    }

                }
                else
                {
                    _agent.isStopped = false;
                    _agent.transform.LookAt(target);
                    _agent.SetDestination(target.position);
                }
            }
            else
            {
                _agent.isStopped = true;
                _agent.transform.LookAt(target);
            }
        }
    }
}
