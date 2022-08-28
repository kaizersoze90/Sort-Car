using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool GameActive { get; private set; }

    [Header("General Settings")]
    [SerializeField] UnityEvent victory;
    [SerializeField] float victoryWaitTime;
    [SerializeField] float gameOverWaitTime;
    [SerializeField] float carFinalAnimDelay;

    Mover[] _cars;

    void Awake()
    {
        GameActive = true;

        Time.timeScale = 1f;

        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        _cars = FindObjectsOfType<Mover>();
    }

    public void GameOver()
    {
        StartCoroutine(nameof(ProcessGameOver));
    }

    public void Victory()
    {
        StartCoroutine(nameof(ProcessVictory));
    }

    IEnumerator ProcessVictory()
    {
        GameActive = false;

        victory.Invoke();

        //Play victory animation for every car
        foreach (Mover car in _cars)
        {
            car.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(carFinalAnimDelay);
        }

        yield return new WaitForSeconds(victoryWaitTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ProcessGameOver()
    {
        GameActive = false;

        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(gameOverWaitTime);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
