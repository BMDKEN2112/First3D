using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    private Image batteryPower;
    public float batteryChunk;
    public float drainTime = 2f;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        batteryPower = GameObject.Find("FLBatteryPower").GetComponent<Image>();
        InvokeRepeating("FLBatteryDrain", drainTime, drainTime);
    }

    // Update is called once per frame
    void Update()
    {
        batteryPower.fillAmount = batteryChunk;
    }

    private void FLBatteryDrain()
    {
        if (batteryChunk > 0.0f)
        {
            batteryChunk -= 0.25f;
        }
    }

    public void StopDrain()
    {
        CancelInvoke("FLBatteryDrain");
    }
}
