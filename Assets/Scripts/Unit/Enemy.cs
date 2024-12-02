using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    public Transform player;            // อ้างอิงไปยังตำแหน่งของ Player
    public float detectionRadius = 5f; // ระยะการตรวจจับ Player
    private NavMeshAgent agent;        // ใช้สำหรับการเคลื่อนที่ของ NPC
    private bool isPlayerDetected = false; // สถานะการตรวจจับ Player

    [SerializeField]private TimeSystem timeSystem;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        SphereCollider detectionCollider = gameObject.AddComponent<SphereCollider>();
        detectionCollider.radius = detectionRadius;
        detectionCollider.isTrigger = true; // ตั้งค่าให้เป็น Trigger
        timeSystem = GameObject.FindObjectOfType<TimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSystem.isDay == true)
        {
            Destroy(gameObject);
        }
        if (isPlayerDetected)
        {
            // เดินไปหาผู้เล่น
            agent.SetDestination(player.position);
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
            agent.ResetPath(); // หยุดการเคลื่อนที่
        }
    }
}
