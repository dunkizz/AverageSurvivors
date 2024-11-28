using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGateText : MonoBehaviour
{
    private CurrencyManager currencyManager;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.SetText($"NEED {currencyManager.Key}/3 KEYS");
    }
}
