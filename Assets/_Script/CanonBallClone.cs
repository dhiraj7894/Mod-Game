using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBallClone : MonoBehaviour
{
    Rigidbody rb;
    public float _Force = 50;
    public float _MovementForce = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float xForce = Random.Range(-_MovementForce, _MovementForce);
        float yForce = Random.Range(-_MovementForce, _MovementForce);
        float zForce = Random.Range(_Force/2f, _Force);
        Vector3 pos = new Vector3(xForce, yForce, transform.position.z);
        rb.velocity = pos;
        rb.AddForce(transform.forward * zForce, ForceMode.Impulse);
        Destroy(gameObject, 3);
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
