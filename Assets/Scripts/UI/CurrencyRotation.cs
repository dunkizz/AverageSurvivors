using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyRotation : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]private float rotationSpeed = 50f;
    [SerializeField]private float xRotation = 0f;
    [SerializeField]private float yRotation = 0f;
    [SerializeField]private float zRotation = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(xRotation, yRotation, zRotation), Time.deltaTime * rotationSpeed);
    }
}
