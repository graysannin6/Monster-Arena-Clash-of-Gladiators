using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInterface : MonoBehaviour
{
    int factionID = 0;
    [SerializeField] float damage = 1f;

    public void InitializeCombatInterface(int faction, float newDamage)
    {
        factionID = faction;
        damage = newDamage;
    }

    public float GetDamage()
    {
        return damage;
    }

    public int GetFactionID()
    {
        return factionID;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Building>() != null)
        {
            if (collision.gameObject.GetComponent<Building>().GetFactionID() != factionID)
            {
                HitTarget(collision.gameObject);
            }
        }
        if (collision.gameObject.GetComponent<UnitCombat>() != null)
        {
            if (collision.gameObject.GetComponent<UnitCombat>().GetFactionID() != factionID)
            {
                HitTarget(collision.gameObject);
            }
        }
    }
    void HitTarget(GameObject target)
    {
        if (target.GetComponent<Building>() != null)
        {
            target.GetComponent<Building>().TakeDamage(damage);
        }
        if (target.GetComponent<UnitCombat>() != null)
        {
            target.GetComponent<UnitCombat>().TakeDamage(damage);
            
        }
        Destroy(gameObject);
    }
}
