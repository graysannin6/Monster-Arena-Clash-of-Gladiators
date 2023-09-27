using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Unity.VisualScripting;
public class PlayerUnitInterfaceButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] PlayerUnitInterfaceController controller;
    [SerializeField] CurrencyManager currencyManager;
    [SerializeField] Image image;
    [SerializeField] GameObject unitPrefrab;
    [SerializeField] TextMeshProUGUI costText;
    [SerializeField] float cost = 0f;
    bool mouseDown = false;


    void Start()
    {
        if (costText != null)
        {
            costText.text = cost.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown)
        {
            RunWaitMouseUp();
        }
    }

    void RunWaitMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            image.color = Color.white;
            mouseDown = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currencyManager.GetCurrentCurrency() < cost)
        {
            return;
        }
        mouseDown = true;
        image.color = Color.green;
        controller.PrepareUnitForSpawn(unitPrefrab, cost);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;
        image.color = Color.white;
    }
}
