using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;

    public GameObject bola;
    public GameObject gameOverUI;
    public GameObject youWinUI;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Retry();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
        if (bola == null)
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }else if (bola != null)
        {
            Time.timeScale = 1;
        }

        if(score == 100)
        {
            youWinUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void UpdateScore(int scoretoAdd)
    {
        score += scoretoAdd;
        scoreText.text = "Score: " + score;
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
}
