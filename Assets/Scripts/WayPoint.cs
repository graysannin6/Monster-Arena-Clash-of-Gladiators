using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] WayPoint nextWayPoint;

    public WayPoint GetNextWaypoint()
    {
        return nextWayPoint;
    }
}
