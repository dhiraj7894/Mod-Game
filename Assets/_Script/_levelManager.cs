using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class _levelManager : MonoBehaviour
{
    public static _levelManager manager;

    [Header("Game Objects")]
    public GameObject HomeLevel;

    [Header("UIs")]
    public GameObject HomeScreen;
    public GameObject NextScreen;
    public GameObject FailScreen;
    public TextMeshProUGUI levelText;

    [Header("Levels")]
    public GameObject Levels;
    public GameObject[] gameLevels;

    public int levelNumber = 0;

    [Header("Confetti")]
    public ParticleSystem left;
    public ParticleSystem right;

    private void Start()
    {
        Application.targetFrameRate = 60;
        manager = this;
    }
    private void Update()
    {


        if (Levels == null)
            return;
    }
    public void spwnLevel()
    {
        HomeLevel.SetActive(false);
        HomeScreen.SetActive(false);
        Levels = Instantiate(gameLevels[0], Vector3.zero, Quaternion.identity);
        levelText.text = (levelNumber + 1).ToString();
        levelNumber += 1;
    }
    [SerializeField]
    int number;
    public void next()
    {
        Destroy(Levels);

        if (Levels != null && levelNumber <= 5)
        {
            Levels = null;
            NextScreen.SetActive(false);
            FailScreen.SetActive(false);
            next_1();
        }

        if (Levels != null && levelNumber >= 6)
        {
            Levels = null;
            NextScreen.SetActive(false);
            FailScreen.SetActive(false);
            next_2();
        }
    }
    public void Retry()
    {
        Destroy(Levels);
        levelText.text =  (levelNumber).ToString();
        Levels = Instantiate(gameLevels[0], Vector3.zero, Quaternion.identity);
        FailScreen.SetActive(false);
    }

    void next_1()
    {
        levelText.text = (levelNumber + 1).ToString();
        Levels = Instantiate(gameLevels[0], Vector3.zero, Quaternion.identity);
        levelNumber += 1;
    }
    void next_2()
    {
        number = Random.Range(0, 6);
        levelText.text = (levelNumber + 1).ToString();
        Levels = Instantiate(gameLevels[0], Vector3.zero, Quaternion.identity);
        levelNumber += 1;
    }
}
