using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookMode : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile standard;
    public PostProcessProfile nightVision;
    public GameObject nightVisionOverlay;
    private bool nightVisionOn = false;
    public GameObject flashLightOverlay;
    private bool flashLightOn = false;
    private Light flashLight;

    // Start is called before the first frame update
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        flashLight = GameObject.Find("FlashLight").GetComponent<Light>();
        flashLight.enabled = false;
        nightVisionOverlay.SetActive(false);
        flashLightOverlay.SetActive(false);
        vol.profile = standard;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (nightVisionOn == false)
            {
                vol.profile = nightVision;
                nightVisionOverlay.SetActive(true);
                nightVisionOn = true;
                NightVisionOff();
            }
            else if (nightVisionOn == true)
            {
                vol.profile = standard;
                nightVisionOverlay.SetActive(false);
                nightVisionOverlay.GetComponent<NightVision>().StopDrain();
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionOn = false;
            }
          
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLightOn == false)
            {
                flashLightOverlay.SetActive(true);
                flashLight.enabled = true;
                flashLightOn = true;
                FlashLightSwitchOff();
            }
            else if (flashLightOn == true)
            {
                flashLightOverlay.SetActive(false);
                flashLight.enabled = false;
                flashLightOverlay.GetComponent<FlashLight>().StopDrain();
                flashLightOn = false;
            }
        }

        if (nightVisionOn == true)
        {
            NightVisionOff();
        }

        if (flashLightOn == true)
        {
            FlashLightSwitchOff();
        }

    }

    private void NightVisionOff()
    {
        if (nightVisionOverlay.GetComponent<NightVision>().batteryChunk <= 0)
        {
            vol.profile = standard;
            nightVisionOverlay.SetActive(false);
            this.gameObject.GetComponent<Camera>().fieldOfView = 60;
            nightVisionOn = false;
        }
    }

    private void FlashLightSwitchOff()
    {
        if (flashLightOverlay.GetComponent<FlashLight>().batteryChunk <= 0)
        {
            flashLightOverlay.SetActive(false);
            flashLight.enabled = false;
            flashLightOverlay.GetComponent<FlashLight>().StopDrain();
            flashLightOn = false;
        }
    }
}
