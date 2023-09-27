using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    int factionID = 0;
    float currentHP = 1;
    [SerializeField] float maxHP = 15f;
    void Start()
    {
        currentHP = maxHP;
    }

    public virtual void TakeDamage(float amount)
    {
        if (currentHP <= 0)
        {
            return;
        }
        currentHP -= amount;

        if (currentHP <= 0)
        {
            GetComponent<UnitAI>().TriggerDeath();
        }
    }

    public int GetFactionID()
    {
        return factionID;
    }

    public virtual void InitializeCombat(int faction)
    {
        factionID = faction;
    }

   
}
