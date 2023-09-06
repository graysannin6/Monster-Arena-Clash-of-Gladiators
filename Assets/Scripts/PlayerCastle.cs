using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCastle : Building
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Die();
        }
    }

    public override void Die()
    {
        GameStateManager.instance.PlayerLost();
        base.Die();
    }

}
