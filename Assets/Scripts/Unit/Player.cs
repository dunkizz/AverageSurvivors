using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    private Unit[] units;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerAttack();
        PlayerMovement();
    }

    void PlayerAttack()
    {
        
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
            SetState(UnitState.Moving);
        }
        else
        {
            SetState(UnitState.Idle);
        }

        // Move the character
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
