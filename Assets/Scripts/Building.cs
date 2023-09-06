using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private int factionID = 0;

    private float currentHP = 1;
    [SerializeField]private float maxHP = 50f; 
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public int GetFactionID()
    {
        return factionID;
    }
    
    public void TakeDamage(float damageAmount)
    {
        currentHP -= damageAmount;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
