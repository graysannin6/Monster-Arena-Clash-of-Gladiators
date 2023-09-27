using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandradAI : UnitAI
{
    enum StandradAIState {Moving,Attacking,Dead}
    StandradAIState aiState = StandradAIState.Moving;

    [Space(10)]
    [SerializeField] float attackRange = 1f;
    [SerializeField] float attackDamage = 1f;
    [SerializeField] float attackCooldown = 1f;
    float attackCooldownTimer = 0f;
    [SerializeField] GameObject attackPrefab;
    GameObject target;

    public override void RunAI()
    {
        switch (aiState)
        {
            case StandradAIState.Moving:
                RunMovement();
                break;
            case StandradAIState.Attacking:
                RunAttacking();
                break;
            case StandradAIState.Dead:
                RunDead();
                break;
        }
    }
#region AI
    void RunMovement()
    {
        base.RunAI();
    }
    void RunAttacking()
    {
        if (target != null)
        {
            RunStandardAttackMode();
        }
        else
        {
            AttemptToAcquireNewTarget();
        }
    }

    private void AttemptToAcquireNewTarget()
    {
        Collider[] potentialTargets = Physics.OverlapSphere(transform.position,8);

        foreach (Collider potentialTarget in potentialTargets)
        {
            if (potentialTarget.gameObject.GetComponent<Building>())
            {
                if (potentialTarget.gameObject.GetComponent<Building>().GetFactionID() != GetFactionID())
                {
                    target = potentialTarget.gameObject;
                }
            }
            if (potentialTarget.gameObject.GetComponent<UnitCombat>())
            {
                if (potentialTarget.gameObject.GetComponent<UnitCombat>().GetFactionID() != GetFactionID())
                {
                    target = potentialTarget.gameObject;
                }
            }
        }

        if(target == null) aiState = StandradAIState.Moving;
    }

    private void RunStandardAttackMode()
    {
        if (TargetInRange())
        {
            StandStill();
            RunAttack();
        }
        else
        {
            ChaseTarget();
        }
    }

    private void RunAttack()
    {
        attackCooldownTimer += Time.deltaTime / attackCooldown;

        if (attackCooldownTimer >= 1)
        {
            attackCooldownTimer -= 1;

            RunAttackAnimation();

            SpawnAttackPrefab();
        }
    }

    private void SpawnAttackPrefab()
    {
        GameObject newAttack = Instantiate(attackPrefab,transform.position,Quaternion.identity);

        Vector3 attackTrajectory = (target.transform.position - transform.position);
        newAttack.GetComponent<Bullet>().InitializeBullet(GetFactionID(),attackDamage,attackTrajectory);
    }

    private void RunAttackAnimation()
    {
        if (attackRange > 1.5f)
        {
            GetComponent<UnitAnimator>().AnimateBowAttack();
        }
        else
        {
            GetComponent<UnitAnimator>().AnimateMelleeAttack();
        }
    }

    private void ChaseTarget()
    {
        GetComponent<NavMeshAgent>().destination = target.transform.position;
    }

    private void StandStill()
    {
        GetComponent<NavMeshAgent>().destination = transform.position;
    }

    private bool TargetInRange()
    {
        return Vector3.Distance(transform.position,target.transform.position) < attackRange;
    }

    void RunDead()
    {

    }
    #endregion

#region Attackables
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Building>() != null)
        {
            AttackBuilding(other.gameObject);
        }
        if (other.gameObject.GetComponent<UnitCombat>() != null)
        {
            AttackUnit(other.gameObject);
        }
    }

    private void AttackUnit(GameObject unitToAttack)
    {
        if (unitToAttack.GetComponent<UnitCombat>().GetFactionID() != GetFactionID())
        {
            aiState = StandradAIState.Attacking;
            target = unitToAttack;
        }
    }

    private void AttackBuilding(GameObject building)

    {
        if (building.GetComponent<Building>().GetFactionID() != GetFactionID())
        {
            aiState = StandradAIState.Attacking;
            target = building;
        }
    }
#endregion

}
