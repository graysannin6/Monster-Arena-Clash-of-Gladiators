using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScaleShift : MonoBehaviour
{
    [SerializeField] float scaleMagnitude = .35f;
    [SerializeField] float scaleDuration = .5f;
    float timer = 0;
    bool isShifting = true;

    void Update()
    {
        if (isShifting)
        {
            RunShifting();
        }
    }

    void RunShifting()
    {
        if (scaleDuration == 0)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime / scaleDuration;
        }

        transform.localScale = Vector3.one + (Vector3.one * scaleMagnitude * (1 - timer));

        if (timer >= 1)
        {
            transform.localScale = Vector3.one;
            isShifting = false;
        }
    }

    public void TriggerScaleShift()
    {
        timer = 0;
        isShifting = true;
    }
}
