using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameEndedPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameEndedPanel;
    [SerializeField] TextMeshProUGUI panelText;
    [SerializeField] private string playerWonText = "Game Over- You won!";
    [SerializeField] private string playerLoseText = "Game Over- You lost!";
    // Start is called before the first frame update
    void Start()
    {
        gameEndedPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerWon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerLose();
        }

    }

    public void PlayerWon()
    {
        gameEndedPanel.SetActive(true);
        panelText.text = playerWonText;
    }
    public void PlayerLose()
    {
        gameEndedPanel.SetActive(true);
        panelText.text = playerLoseText;
    }
}
