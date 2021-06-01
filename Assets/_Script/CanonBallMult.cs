using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CanonBallMult : MonoBehaviour
{
    public float _Force = 50;
    public int MultiPlyCount;
    
    public List<GameObject> balls = new List<GameObject>();


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("2x"))
        {
            MultiPlyCount = 2;
            for (int i = 0; i < MultiPlyCount; i++)
            {
                spwanBalls();
            }
        }
        if (other.gameObject.CompareTag("3x"))
        {
            MultiPlyCount = 3;
            for (int i = 0; i < MultiPlyCount; i++)
            {
                spwanBalls();
            }
        }
        if (other.gameObject.CompareTag("5x"))
        {
            MultiPlyCount = 5;
            for (int i = 0; i < MultiPlyCount; i++)
            {
                spwanBalls();
            }
        }
    }

    public void spwanBalls()
    {
        GameObject obj = Instantiate(FindObjectOfType<CanonBallSpw>().CloneBall, transform.position, Quaternion.identity);
        if (!balls.Contains(obj))
        {
            balls.Add(obj);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("zombie"))
        {
            Destroy(Instantiate(CanonBallSpw.ballpwnner.BallPartical, transform.position, Quaternion.identity).gameObject.transform.parent = transform, 2);
            Destroy(this.gameObject,0.5f);
        }
        if (collision.gameObject.CompareTag("zombie"))
        {
            CanonBallSpw.ballpwnner.KillCount += 1;
        }
    }
}
