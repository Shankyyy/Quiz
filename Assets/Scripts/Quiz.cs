using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using System;

public class Quiz : MonoBehaviour
{
    [SerializeField] List<Questions> questionsList;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField, Header("UI Text"),Space(10)]
    TextMeshProUGUI questionText;
    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI TimerText;

    [SerializeField] TextMeshProUGUI[] answersText;

    [SerializeField] int num = 0;
    [SerializeField] int score = 0;
    [SerializeField] float timer = 30;
    

    
    public static Action<int,int> OnGameOver;
    private int answered = 0;

    private void Start()
    {
        ChangeQuestion();     
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        TimerText.text = "Timer: "+ Mathf.FloorToInt(timer % 60); ;
        if(timer <= 0)
        {
            num++;
            ChangeQuestion();
           
        }

    }

    private void ChangeQuestion()
    {
        timer = 30;
        questionText.text = questionsList[num].question;
        for (int i = 0; i < answersText.Length; i++)
        {
            answersText[i].text = questionsList[num].answers[i];
        }
    }

    public void CheckAnswer(int i)
    {
 
        if(questionsList[num].correctAnswer == questionsList[num].answers[i])
        {
            print("Correct answer ");
            score += 5;
            answered++;
            HandleScore();

            num++;
            if (num > questionsList.Count - 1) 
            {
               
                if(OnGameOver != null)
                {                  
                    OnGameOver(score,answered);
                }
                num = 0;
            }

            ChangeQuestion();
        }
        else
        {
            print("Wrong answer ");           
            num++;
            if (num > questionsList.Count - 1)
            {
                if (OnGameOver != null)
                {
                    OnGameOver(score,answered);
                }
                num = 0;
            }


            ChangeQuestion();
        }
    }

   
    private void HandleScore()
    {
        scoreText.text = "Score: " + score;
    }

   
}
