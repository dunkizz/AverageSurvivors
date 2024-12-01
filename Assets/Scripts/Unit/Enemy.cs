using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField]private TimeSystem timeSystem;
    // Start is called before the first frame update
    void Start()
    {
        timeSystem = GameObject.FindObjectOfType<TimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeSystem.isDay == true)
        {
            Destroy(gameObject);
        }
    }
}
