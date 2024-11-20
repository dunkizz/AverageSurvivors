using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    [SerializeField] private Currency currency;
    [SerializeField] private CurrencyManager currencyManager;
    [SerializeField] private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        currencyManager = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (currency.CurrencyType)
            {
                case CurrencyType.Gold:
                    currencyManager.Gold++;
                    Destroy(parent);
                    break;
                case CurrencyType.Wood:
                    currencyManager.Wood++;
                    Destroy(parent);
                    break;
                case CurrencyType.Rock:
                    currencyManager.Rock++;
                    Destroy(parent);
                    break;
            }
        }
    }
}
