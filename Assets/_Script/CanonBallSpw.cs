using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanonBallSpw : MonoBehaviour
{
    public static CanonBallSpw ballpwnner;
    public GameObject BallPartical;
    public GameObject MultBall;
    public GameObject CloneBall;
    public GameObject Target;
    public Transform SpwnPosition;
    public TextMeshProUGUI healthText;
    public Slider slider;
    public float maxHealth = 100;
    public float currentHealth;
    public float healthSpeed = 3;
    public bool GameOver = false;

    [Header("Zombie Killing")]
    public TextMeshProUGUI CountOfZKilled;
    public int MaxNumberToKill = 10;
    public int KillCount = 0;

    float _force;
    private void Start()
    {
        ballpwnner = this;
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject obj = Instantiate(MultBall, SpwnPosition.position, Quaternion.identity);
            _force = obj.GetComponent<CanonBallMult>()._Force;
            obj.GetComponent<Rigidbody>().AddForce(SpwnPosition.forward * _force, ForceMode.Impulse);
            Destroy(obj, 3);
        }
        CountOfZKilled.text = KillCount + "/" + MaxNumberToKill.ToString();
        StartCoroutine(WinOrLose());
        healthBar();
    }
    int i = 0;

    IEnumerator WinOrLose()
    {
        if (KillCount >= MaxNumberToKill && !GameOver)
        {
            GameOver = true;
            _levelManager.manager.left.Play();
            _levelManager.manager.right.Play();
            yield return new WaitForSeconds(0.8f);
            _levelManager.manager.NextScreen.SetActive(true);
            FindObjectOfType<multiplyerSpwanner>().enabled = false;
            /*FindObjectOfType<bigSpwnner>().enabled = false;
            FindObjectOfType<smallSpwnner>().enabled = false;*/
            FindObjectOfType<bigSpwnner>().gameObject.SetActive(false);
            FindObjectOfType<smallSpwnner>().gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            healthText.gameObject.SetActive(false);
            Target.SetActive(false);
        }
        if(KillCount != MaxNumberToKill && currentHealth <= 0 && !GameOver)
        {
            GameOver = true;
            yield return new WaitForSeconds(0.8f);
            _levelManager.manager.FailScreen.SetActive(true);
            FindObjectOfType<multiplyerSpwanner>().enabled = false;
            /*FindObjectOfType<bigSpwnner>().enabled = false;
            FindObjectOfType<smallSpwnner>().enabled = false;*/
            FindObjectOfType<bigSpwnner>().gameObject.SetActive(false);
            FindObjectOfType<smallSpwnner>().gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            healthText.gameObject.SetActive(false);
            Target.SetActive(false);
        }
    }
    void healthBar()
    {
        if(currentHealth < slider.value)
        {
            slider.value -= healthSpeed;
            healthText.text = "Castle Health : " + slider.value + "%".ToString();
        }
    }
}
