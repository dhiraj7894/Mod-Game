using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigSpwnner : MonoBehaviour
{
    public GameObject bDemon_1, bDemon_2;
    private float time;
    public float maxTime;
    public List<Transform> SpwanPoints = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            float RZ = Random.Range(0, 2);
            int i = Random.Range(0, SpwanPoints.Count);
            if (RZ == 0)
            {
                GameObject d1 = Instantiate(bDemon_1, SpwanPoints[i].position, Quaternion.identity);
                d1.transform.parent = transform;
            }
            if (RZ == 1)
            {
                GameObject d1 = Instantiate(bDemon_2, SpwanPoints[i].position, Quaternion.identity);
                d1.transform.parent = transform;
            }
            time = maxTime;
        }
    }
}
