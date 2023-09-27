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
    [SerializeField] BoxCollider objectCollider;
    [SerializeField] float timeToDestroy = 4f;
    bool alive = true;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
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
        GetComponent<UnitCombat>().InitializeCombat(faction);
    }

    public void TriggerDeath()
    {
        alive = false;
        unitAnimator.AnimateDeath();
        agent.destination = transform.position;
        agent.enabled = false;
        if (objectCollider != null)
        {
            objectCollider.enabled = false;
        }
        Destroy(gameObject,timeToDestroy);
    }

    public int GetFactionID()
    {
        return factionID;
    }
}
