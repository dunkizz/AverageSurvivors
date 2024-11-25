using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Weapon : Item
{
    [Header("Properties")]
    [SerializeField]public WeaponData wepData;
    [Header("User")]
    [SerializeField]private Unit unit;
    // Dictionary to store weapon data by ID

    private void OnEnable()
    {
        PlusAndResetStat();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
        //setActiveIfUsing();
        matchItem();
    }

    void matchItem()
    {
        Id = wepData.weaponId;
        Name = wepData.weaponName;
        Type = wepData.weaponType;
    }

    void PlusAndResetStat()
    {
        bool isReset = false;
        //reset
        if (isReset == false)
        {
            unit.GetBasedStat();
            isReset = true;
        }
        //plus
        if (isReset == true)
        {
            unit.currentUnitDamage += wepData.damage;
            unit.currentUnitCritChance += wepData.critChance;
            unit.currentUnitHeavyAttackChance += wepData.heavyAtkChance;
        }
    }

   
}


    

