using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    private NavMeshAgent agent;

    private GameObject target;
    private Animator demonAnime;
    private bool isDead = false;
    private float turnSmoothVelocity;
    public float dist;
    public float rotationSmooth = 10;
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Target");
        agent = this.GetComponent<NavMeshAgent>();
        demonAnime = this.transform.GetChild(0).GetComponent<Animator>();
    }
    void Update()
    {
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (!isDead)
        {
            agent.SetDestination(target.transform.position);
            if (agent.velocity.magnitude > 0)
            {
                float targetAngle = Mathf.Atan2(agent.velocity.x, agent.velocity.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, rotationSmooth);
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }
        if (isDead)
        {
            agent.SetDestination(this.transform.position);
            demonAnime.SetBool("Dead", true);
            Destroy(this.gameObject, 4.5f);
        }
        if (dist <= 3)
        {
            CanonBallSpw.ballpwnner.currentHealth -= 20;
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            isDead = true;
            transform.GetComponent<Collider>().enabled = false;
        }
    }
}
