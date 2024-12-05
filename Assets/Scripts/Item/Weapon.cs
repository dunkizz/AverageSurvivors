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
    [SerializeField]private BoxCollider HitBox;
    // Dictionary to store weapon data by ID

    private void OnEnable()
    {
        PlusAndResetStat();
    }

    void TurnOnHitBox()
    {
        if (unit.State == UnitState.Attack)
        {
            HitBox.isTrigger = true;
        }

        if (unit.State != UnitState.Attack)
        {
            HitBox.enabled = false;
        }
    }

    


    // Start is called before the first frame update
    void Start()
    {
        HitBox = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        HitBox.enabled = false;
        //TurnOnHitBox();
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

    private void OnTriggerEnter(Collider other)
    {
        
    }
}


    

