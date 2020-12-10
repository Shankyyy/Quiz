using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] float Delay = 1f;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] RectTransform gameOverBody;
    [SerializeField,Space(10)] Ease ease;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI answeredText;

    CanvasGroup canvasGroup;

    private void OnEnable()
    {
        Quiz.OnGameOver += GameOver;
        print("sub");
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
        canvasGroup = gameOverPanel.transform.GetComponent<CanvasGroup>();
    }
    private void GameOver(int score,int answered)
    {
        scoreText.text = "Score: " + score;
        answeredText.text = "Answered: " + answered;
        gameOverPanel.SetActive(true);
        canvasGroup.DOFade(1, 1);
        gameOverBody.DOAnchorPosY(0, Delay).SetEase(ease).SetDelay(1);
        
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if(currentScene >= PlayerPrefs.GetInt("unlockLevel"))
        {
            PlayerPrefs.SetInt("unlockLevel", currentScene + 1);
        }

        if( currentScene > SceneManager.sceneCount)
        {
            SceneManager.LoadScene(0);
        }

        SceneManager.LoadScene(currentScene + 1);
    }

    public void LevelSelection()
    {
        SceneManager.LoadScene(0);
    }


    private void OnDisable()
    {
        Quiz.OnGameOver -= GameOver;
    }
}
