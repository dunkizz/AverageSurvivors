using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Idle,
    Moving,
    Dashing,
    Die,
    Attack
}

public class Unit : MonoBehaviour
{
    [Header("Unit")]
    [SerializeField]protected string name;
    [SerializeField]protected string type;
    [SerializeField]private UnitState state;
    [SerializeField]protected Rigidbody rb;
    
    public UnitState State { get { return state; } set { state = value; } }
    //status = hp,defense,cri,movespeed
    [Header("Status")]
    [SerializeField]protected int health;
    [SerializeField]protected float damage;
    [SerializeField]protected float defense;
    [SerializeField]protected float critChance;
    [SerializeField]protected float moveSpeed;
    [SerializeField]protected float heavyAttackChance;
    [Header("Equipment")] 
    [SerializeField] private GameObject inHand_Item;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Dead()
    {
        
    }

    void animation()
    {
        
    }
    public void SetState(UnitState toState)
    {
        state = toState;
    }

}
