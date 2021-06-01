using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiplyerSpwanner : MonoBehaviour
{
    public GameObject x2, x3, x5;
    public GameObject refer;
    public float TimerIncreser=1;
    private int i;
    private float TimerNumber;
    void Start()
    {
        
    }

    void Update()
    {

        if(TimerNumber >= 0)
        {
            TimerNumber -= Time.deltaTime;
        }
        if (TimerNumber <= 0)
        {
            i = Random.Range(0, 3);
            if (i == 0 && refer == null)
            {
                GameObject x2x = refer = Instantiate(x2, new Vector3(-5.5f, 0.17f, 3.99f), Quaternion.Euler(90,180,0));
                x2x.transform.parent = transform;
                Destroy(x2x,5);
                if (x2x.transform.localPosition.x>= 1.25f)
                {
                    Destroy(x2x);
                    refer = null;
                }
            }
            if (i == 1 && refer == null)
            {
                GameObject x3x = refer = Instantiate(x3, new Vector3(1.5f, 0.17f, 3.99f), Quaternion.Euler(90, 180, 0));
                x3x.transform.parent = transform;
                Destroy(x3x, 7);
                if (x3x.transform.localPosition.x <= -5.4f)
                {
                    Destroy(x3x);
                    refer = null;
                }
            }
            if (i == 2 && refer == null)
            {
                GameObject x5x = refer = Instantiate(x5, new Vector3(1.5f, 0.17f, 3.99f), Quaternion.Euler(90, 180, 0));
                x5x.transform.parent = transform;
                Destroy(x5x, 9);
                if (x5x.transform.localPosition.x <= -5.3f)
                {
                    Destroy(x5x);
                    refer = null;
                }
            }
            TimerNumber = TimerIncreser;

        }
        if (refer == null)
            return;
    }
}
