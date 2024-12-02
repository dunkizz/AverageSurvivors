using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    [Header("TimeSettings")]
    [SerializeField]private Light directionalLight;
    [SerializeField]private TextMeshProUGUI timerText;
    [SerializeField]private TextMeshProUGUI timeDescriptionText;
    [SerializeField]public bool isDay;
    [SerializeField]private float timer;
    [Header("Day Time")]
    [SerializeField]private float dayIntensity;
    //[SerializeField]private int dMin;
    [SerializeField]public float dSec;
    [Header("Night Time")] 
    [SerializeField]private float nightIntensity;
    //[SerializeField]private int nMin;
    [SerializeField]public float nSec;
    [SerializeField]public float currentNsec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        
        //Clock
        if (isDay)
        {
            SecToMin(dSec - timer); // Countdown for day time
        }
        else
        {
            SecToMin(nSec - timer); // Countdown for night time
        }
    }

    void Timer()
    {
        if (isDay == false)
        {
            currentNsec = nSec - timer;
        }
        else
        {
            currentNsec = nSec;
        }
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
    

    void SecToMin(float sec)
    {
        
        int minutes = (int)(sec / 60);
        int remainingSeconds = (int)(sec % 60);
        
        //set text time
        timerText.text = $"{minutes:D2}:{remainingSeconds:D2}";
        //set text desc
        if (isDay)
        {
            timeDescriptionText.text = "Before Night";
        }
        else
        {
            timeDescriptionText.text = "Before Dawn";
        }
        //Debug.Log($"TimeLeft: {minutes:D2}:{remainingSeconds:D2}");
    }

    
}
