using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private Animator gateAnim;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private bool isNightGate;
    [SerializeField] private bool isEndGate;
    [SerializeField] private bool gateIsUp = false;
    [SerializeField] private TimeSystem timeSystem;
    // Start is called before the first frame update
    void Start()
    {
        gateAnim = GetComponent<Animator>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        timeSystem = FindObjectOfType<TimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGate == true)
        {
            if (currencyManager.Key >= 3)
            {
                
                OpenGate();
            }
        }
        
        if (isNightGate == true)
        {
            if (timeSystem.isDay == false)
            {
                OpenGate();
            }

            if (timeSystem.isDay == true)
            {
                gateIsUp = false;
                CloseGate();
            }
        }
    }

    void OpenGate()
    {
        gateIsUp = true;
        if (gateIsUp == true)
        {
            gateAnim.SetBool("GateIsUp", true);
        }
    }

    void CloseGate()
    {
        //gateIsUp = false;
        if (gateIsUp == false)
        {
            gateAnim.SetBool("GateIsUp", false);
        }
    }
}
