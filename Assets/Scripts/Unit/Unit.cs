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
    [SerializeField]private string name;
    [SerializeField]private string type;
    [SerializeField]private UnitState state;
    public UnitState State { get { return state; } set { state = value; } }
    [SerializeField]protected Rigidbody rb;
    
    [Header("Status")]
    [SerializeField]private int health;
    public int Health { get { return health; } set { health = value; } }
    [SerializeField]private float damage;
    public float Damage { get { return damage; } set { damage = value; } }
    [SerializeField]private float defense;
    public float Defense { get { return defense; } set { defense = value; } }
    [SerializeField]private float critChance;
    public float CritChance { get { return critChance; } set { critChance = value; } }
    [SerializeField]private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    [SerializeField]private float heavyAttackChance;
    public float HeavyAttackChance { get { return heavyAttackChance; } set { heavyAttackChance = value; } }
    
    [Header("Equipment")] 
    [SerializeField]private GameObject inHand_Item;
    
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

    public void SetState(UnitState toState)
    {
        state = toState;
    }

}
