using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopicSelection : MonoBehaviour
{

    public void PW(){
        SceneManager.LoadScene("PasswordGame");
    }

    public void Quiz(){
        SceneManager.LoadScene("QuizScene");
    }

}