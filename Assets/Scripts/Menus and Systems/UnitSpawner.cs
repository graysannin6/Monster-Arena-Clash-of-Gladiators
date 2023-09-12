using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] int factionID;
    [SerializeField] WayPoint leftWaypoint;
    [SerializeField] WayPoint rightWaypoint;
    

    public void SpawnUnit(GameObject unitPrefab, Vector3 spawnPosition)
    {
        GameObject newUnit = Instantiate(unitPrefab,spawnPosition,Quaternion.identity);
        newUnit.GetComponent<UnitAI>().InitializeAI(GetCloserWaypoint(spawnPosition),factionID);
    }

    WayPoint GetCloserWaypoint(Vector3 position)
    {
        float leftDistance = Vector3.Distance(leftWaypoint.transform.position,position);
        float rightDistance = Vector3.Distance(rightWaypoint.transform.position,position);

        if (leftDistance < rightDistance)
        {
            return leftWaypoint;
        }
        else
        {
            return rightWaypoint;
        }
    }
}
