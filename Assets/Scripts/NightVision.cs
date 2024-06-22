using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightVision : MonoBehaviour
{
    private Image zoomBar;
    private Image batteryPower;
    private Camera cam;
    public float batteryChunk = 1f;
    public float drainTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        zoomBar = GameObject.Find("Zoombar")?.GetComponent<Image>();
        batteryPower = GameObject.Find("BatteryPower")?.GetComponent<Image>();
        cam = GameObject.Find("FirstPersonCharacter")?.GetComponent<Camera>();
        

       
    }

    private void OnEnable()
    {
        InvokeRepeating("BatteryDrain", drainTime, drainTime);
        if (zoomBar != null)
        {
            zoomBar.fillAmount = 0.6f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (cam == null || zoomBar == null) return;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (cam.fieldOfView > 10)
            {
                cam.fieldOfView -= 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        batteryPower.fillAmount = batteryChunk;
    }

    private void BatteryDrain()
    {
        if (batteryChunk > 0.0f)
        {
            batteryChunk -= 0.25f;
        }
    }

    public void StopDrain()
    {
        CancelInvoke("BatteryDrain");
    }
}
