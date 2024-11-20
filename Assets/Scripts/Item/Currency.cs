using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

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
    public CurrencyType CurrencyType { get { return currencyType; } set { currencyType = value; } }
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
                Name = "Gold";
                SetCurrency(CurrencyType.Gold);
                SetType(ItemType.Currency);
                break;
            case 1:
                Name = "Wood";
                SetCurrency(CurrencyType.Wood);
                SetType(ItemType.Currency);
                break;
            case 2:
                Name = "Rock";
                SetCurrency(CurrencyType.Rock);
                SetType(ItemType.Currency);
                break;
        }
    }
    public void SetCurrency(CurrencyType toCurrency)
    {
        currencyType = toCurrency;
    }
}
