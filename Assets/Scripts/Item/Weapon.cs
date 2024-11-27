using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Weapon : Item
{
    [Header("User")]
    [SerializeField]private Unit unit;
    [Header("Stats")]
    public float weaponDamage;
    public float weaponSpeed;
    public float weaponCritChance;
    public float weaponHeavyAtkChance;
    // Dictionary to store weapon data by ID

    private void OnEnable()
    {
        PlusAndResetStat();
    }

    


    // Start is called before the first frame update
    void Start()
    {
        //runTimeWeaponData = wepData.CreateInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
        //setActiveIfUsing();
        //matchItem();
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
            unit.currentUnitDamage += weaponDamage;
            unit.currentUnitCritChance += weaponCritChance;
            unit.currentUnitHeavyAttackChance += weaponHeavyAtkChance;
        }
    }

   
}


    

