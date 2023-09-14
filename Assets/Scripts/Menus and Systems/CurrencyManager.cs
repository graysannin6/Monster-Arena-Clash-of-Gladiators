using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CurrencyManager : MonoBehaviour
{
    [SerializeField] float maxCurrency = 10f;
    float currentCurrency = 0;
    [SerializeField] float baseIncomeRate = 1f;
    float incomeRateModifier = 1.0f;
    [SerializeField] GameObject currencyBarFill;
    [SerializeField] TextMeshProUGUI currencyBarText;
    float oldTimerValue = 0f;
    [SerializeField] UIScaleShift currencyBarTextScaleShift;
    // Start is called before the first frame update
    void Start()
    {
        currentCurrency = maxCurrency / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AccumulateCurrency();
        UpdateCurrencyUI();
    }

    void AccumulateCurrency()
    {
        currentCurrency += (baseIncomeRate * incomeRateModifier) * Time.deltaTime;
        oldTimerValue += (baseIncomeRate * incomeRateModifier) * Time.deltaTime;
        if (currentCurrency > maxCurrency)
        {
            currentCurrency = maxCurrency;
        }
    }

    void UpdateCurrencyUI()
    {
        if (currencyBarFill != null)
        {
            UpdateUIFillBar();
        }

        if (currencyBarText != null)
        {
            UpdateUIText();
        }
    }

    void UpdateUIFillBar()
    {
        currencyBarFill.transform.localScale = new Vector3(currentCurrency / maxCurrency, 1, 1);
    }

    void UpdateUIText()
    {
        currencyBarText.text = ((int)currentCurrency).ToString();

        if (currentCurrency == maxCurrency)
        {
            oldTimerValue = 0;
        }
        else
        {
            if (oldTimerValue >= 1)
            {
                oldTimerValue -= 1;
                currencyBarTextScaleShift.TriggerScaleShift();
            }
        }
    }
    #region External
    public float GetCurrentCurrency()
    {
        return currentCurrency;
    }

    public void SpendCurrency(float amount)
    {
        if (currentCurrency >= amount)
        {
            currentCurrency -= amount;
        }
        UpdateCurrencyUI();
    }
    #endregion
}
