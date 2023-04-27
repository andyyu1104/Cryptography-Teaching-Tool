using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public AudioSource CorrectSound;

    public AudioSource WrongSound;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI ScoreText;

    public Animator BlueDino;
    public Animator RedDino;
    public Animator YellowDino;
    public Animator GreenDino;
    
    int totalQuestions = 0;
    public int score;

    void GenerateQuestion(){
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionText.text = QnA[currentQuestion].Quesiton;
            SetAnwsers();
        } 
        else 
        {
            Debug.Log("Out of question.");
            GameOver();
        }
        

    }

    public void retry()
    {
        SceneManager.LoadScene("GameScene");
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestions;
    }

    // Start is called before the first frame update
    void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        GenerateQuestion();        
    }

    public void Correct()
    {
        score+=1;
        CorrectSound.Play();
        BlueDino.SetTrigger("CorrectAns");
        RedDino.SetTrigger("CorrectAns");
        YellowDino.SetTrigger("CorrectAns");
        GreenDino.SetTrigger("CorrectAns");
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void Wrong()
    {
        WrongSound.Play();
        BlueDino.SetTrigger("WrongAns");
        RedDino.SetTrigger("WrongAns");
        YellowDino.SetTrigger("WrongAns");
        GreenDino.SetTrigger("WrongAns");
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    void SetAnwsers(){
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
