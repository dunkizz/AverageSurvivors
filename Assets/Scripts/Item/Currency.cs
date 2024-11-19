using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrencyType
{
    Gold,
    Wood,
    Rock
}
public class Currency : Item
{
    [SerializeField]private CurrencyManager currencyManager;
    private Rigidbody rb;
    private bool isGrounded;
    [Header("Currency")]
    [SerializeField]private CurrencyType currencyType;
    // Start is called before the first frame update
    void Start()
    {
        currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        IdCurrency();
        ModelMatchId(Id);
    }

    private void StopMovingAfterGrounded()
    {
        
    }

    private void CheckIfGrounded()
    {
        
    }

    private void IdCurrency()
    {
        switch (Id)
        {
            case 0:
                SetCurrency(CurrencyType.Gold);
                break;
            case 1:
                SetCurrency(CurrencyType.Wood);
                break;
            case 2:
                SetCurrency(CurrencyType.Rock);
                break;
        }
    }
    public void SetCurrency(CurrencyType toCurrency)
    {
        currencyType = toCurrency;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (Id)
            {
                case 0:
                    currencyManager.Gold += 1;
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
