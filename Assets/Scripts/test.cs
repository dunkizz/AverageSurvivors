using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]private float startX;

    [SerializeField] private float endX;

    [SerializeField] private float timer;
    [SerializeField]private float duration;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            float newX = Mathf.Lerp(startX, endX, t);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            if (timer >= duration)
            {
                timer = 0;
            }
        }
    }
}
