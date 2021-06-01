using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotetor : MonoBehaviour
{
    public ParticleSystem cannonPartical;
    public  float xSpeed = 50;
    public Vector2 xRotationLimit;
    float xAxis;
    float xRotation;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            cannonPartical.Play();
            xAxis = Input.GetAxisRaw("Mouse Y") * xSpeed * Time.deltaTime;
            xRotation -= xAxis;
            xRotation = Mathf.Clamp(xRotation, xRotationLimit.x, xRotationLimit.y);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
        

    }
}
