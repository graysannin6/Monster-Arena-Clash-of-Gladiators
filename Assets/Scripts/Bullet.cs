using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : CombatInterface
{
    Vector3 trajectory = Vector3.zero;
    [SerializeField] float bulletSpeed = 3f;

    private void FixedUpdate()
    {
        transform.Translate(trajectory * Time.fixedDeltaTime * bulletSpeed);
    }

    public void InitializeBullet(int factionID, float damage, Vector3 newTrajectory)
    {
        trajectory = newTrajectory;
        InitializeCombatInterface(factionID, damage);
    }
}
