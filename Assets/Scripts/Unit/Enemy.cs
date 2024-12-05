using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    private Player player;
    private Transform playerTransform;            // อ้างอิงไปยังตำแหน่งของ Player
    [SerializeField]private float detectionRadius = 3f; // ระยะการตรวจจับ Player
    private float attackRadius = 1.5f;  // ระยะการโจมตี Player
    private float attackCooldown = 1f; // ระยะเวลารอระหว่างการโจมตี
    private float lastAttackTime;      // เวลาโจมตีครั้งล่าสุด
    private NavMeshAgent agent;        // ใช้สำหรับการเคลื่อนที่ของ NPC
    private bool isPlayerDetected = false; // สถานะการตรวจจับ Player
    [SerializeField]private float distanceToPlayer;
    [SerializeField]private Spawner spawner;
    [SerializeField]private TimeSystem timeSystem;
    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        timeSystem = GameObject.FindObjectOfType<TimeSystem>();
        spawner = GameObject.FindObjectOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentUnitHealth <= 0 && !isDead)
        {
            isDead = true;
            EnemyDead();
        }
        distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        //destroy if day
        if (timeSystem.isDay == true)
        {
            Destroy(gameObject);
        }

        if (isPlayerDetected == false && currentUnitHealth > 0 && isDead == false)
        {
            SetState(UnitState.Moving);
            agent.destination = playerTransform.position;
        }

        if (isPlayerDetected == true && currentUnitHealth > 0 && isDead == false)
        {
            agent.ResetPath();
            transform.LookAt(playerTransform.position);
            AttackPlayer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // ตรวจจับ Player เมื่อเข้ามาในระยะ
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // หยุดตรวจจับ Player เมื่อออกจากระยะ
        if (other.CompareTag("Player"))
        {
            isPlayerDetected = false;
        }
    }
    private void AttackPlayer()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Enemy attacks the player!");
            SetState(UnitState.Attack);
            player.Health -= currentUnitDamage;
            lastAttackTime = Time.time;
        }
    }

    private void EnemyDead()
    {
        bool itemSpawned = false;
        agent.Stop();
        SetState(UnitState.Die);
        spawner.SpawnItem();
        StartCoroutine(DeadWait(2));
    }
    private IEnumerator DeadWait(int sec)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
    }
}
