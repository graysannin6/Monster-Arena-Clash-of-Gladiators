using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class PlayerUnitInterfaceButton : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    [SerializeField] PlayerUnitInterfaceController controller;
    [SerializeField] Image image;
    [SerializeField] GameObject unitPrefrab;
    [SerializeField] float cost = 0f;
    bool mouseDown = false;


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
        //if (eventData.button == PointerEventData.InputButton.Left) // Check if left mouse button was clicked
        //{
            mouseDown = true;
            image.color = Color.green;
            controller.PrepareUnitForSpawn(unitPrefrab, cost);
        //}
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        mouseDown = false;
        image.color = Color.white;
    }
}
