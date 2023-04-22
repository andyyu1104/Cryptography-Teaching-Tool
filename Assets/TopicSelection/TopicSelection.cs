using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopicSelection : MonoBehaviour
{
    public void Main(){
        SceneManager.LoadScene("StartingMenuScene");
    }

    public void PW(){
        SceneManager.LoadScene("PasswordGame");
    }

    public void OA(){
        SceneManager.LoadScene("OnlineAttack");
    }

    public void CC(){
        SceneManager.LoadScene("ClassicCipher");
    }

    public void Quiz(){
        SceneManager.LoadScene("QuizScene");
    }

}
