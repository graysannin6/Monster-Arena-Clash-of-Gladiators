using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class UnitAI : MonoBehaviour
{
    [SerializeField] UnitAnimator unitAnimator;
    [SerializeField] int factionID = 0;
    NavMeshAgent agent;
    [SerializeField] WayPoint wayPoint;
    bool alive = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = wayPoint.transform.position;
    }

    void Update()
    {
        if (alive)
        {
            RunAI();
        }
        else
        {
            TriggerDeath();
        }
    }

    public virtual void RunAI()
    {
        if (Vector3.Distance(agent.destination,transform.position) < 0.5f)
        {
            wayPoint = wayPoint.GetNextWaypoint();
        }

        agent.destination = wayPoint.transform.position;
    }

    public virtual void InitializeAI(WayPoint startingWaypoint,int faction)
    {
        wayPoint = startingWaypoint;
        agent.destination = wayPoint.transform.position;
        factionID = faction;
    }

    public void TriggerDeath()
    {
        alive = false;
        unitAnimator.AnimateDeath();
    }
}
