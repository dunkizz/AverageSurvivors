using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Unit units;
    [Header("Attack")]
    [SerializeField]private int maxHit = 4;
    private int hitCount;
    public int HitCount { get { return hitCount; } set { hitCount = value; } }
    private Animator anim;
    
    [Header("Dashing")]
    [SerializeField]private bool canDash = true;
    [SerializeField]private float dashingSpeed = 100f;
    [SerializeField]private float dashingDuration = 0.3f;
    [SerializeField]private float dashingCooldown = 0.65f;
    [SerializeField]private TrailRenderer dashTrail;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        units = GetComponent<Unit>();
        rb = GetComponent<Rigidbody>();
        dashTrail.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttack();
        if (hitCount == 0)
        {
            PlayerMovement();
            Dashing();
        }
        
    }

    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetState(UnitState.Attack);
            
            hitCount++;
            anim.SetInteger("attackInt", hitCount);
            StartCoroutine(attackDuration());
            
            Debug.Log($"Hit : {hitCount}");
            if (hitCount >= maxHit)
            {
                anim.SetInteger("attackInt",0);
                hitCount = 0;
            }
        }
    }

    void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);

        // Check if there is movement input
        if (movement.magnitude > 0.1f)
        {
            // Only update rotation if there is movement
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement.normalized), 0.2f);
            if (canDash == true)
            {
                SetState(UnitState.Moving);
            }
        }
        else if (movement.magnitude < 0.1f && canDash == true)
        {
            SetState(UnitState.Idle);
        }

        // Move the character
        transform.Translate(movement * units.MoveSpeed * Time.deltaTime, Space.World);
        
        
    }

    void Dashing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        SetState(UnitState.Dashing);
        canDash = false;
        dashTrail.emitting = true;
        
        rb.AddForce(transform.forward.normalized * dashingSpeed, ForceMode.Impulse);
        
        yield return new WaitForSeconds(dashingDuration);
        rb.velocity = Vector3.zero;
        dashTrail.emitting = false;
        
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private IEnumerator attackDuration()
    {
        if (hitCount != hitCount+1)
        {
            yield return new WaitForSeconds(2);
            hitCount = 0;
        }
    }
}
