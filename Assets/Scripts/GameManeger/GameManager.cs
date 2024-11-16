using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("TimeSettings")]
    [SerializeField]private Light directionalLight;
    [SerializeField]private bool isDay;
    [SerializeField]private float timer;
    [Header("Day Time")]
    [SerializeField]private float dayIntensity;
    [SerializeField]private int dMin;
    [SerializeField]private float dSec;
    [Header("Night Time")] 
    [SerializeField]private float nightIntensity;
    [SerializeField]private int nMin;
    [SerializeField]private float nSec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        if (timer < dSec || timer < nSec)
        {
            timer += Time.deltaTime;
            float tD = timer / dSec; //normalized
            float tN = timer / nSec;
            if (isDay == true)
            {
                directionalLight.intensity = Mathf.Lerp(dayIntensity, nightIntensity, tD);
            }
            else
            {
                directionalLight.intensity = Mathf.Lerp(nightIntensity, dayIntensity, tN);
            }
            
            
            if (timer >= dSec && isDay == true)
            {
                timer = 0;
                isDay = false;
            }

            else if (timer >= nSec && isDay == false)
            {
                timer = 0;
                isDay = true;
            }
        }
    }

    
}
