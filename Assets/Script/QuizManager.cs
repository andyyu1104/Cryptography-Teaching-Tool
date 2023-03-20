using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public string QuestionText;

    void generateQuestion(){
        currentQuestion = Random.Range(0, QnA.Count);

        QuestionText = QnA[currentQuestion].Quesiton;
    }

    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();        
    }

    void setAnwser(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
