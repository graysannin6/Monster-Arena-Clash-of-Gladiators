using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

   [SerializeField] GameEndedPanel gameEndedPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void PlayerWon()
   {
        gameEndedPanel.PlayerWon();
   }

   public void PlayerLost()
   {
        gameEndedPanel.PlayerLose();
   }
}
