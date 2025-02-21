using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHouseRotator : MonoBehaviour
{
    public float rotateSpeed = 9f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
