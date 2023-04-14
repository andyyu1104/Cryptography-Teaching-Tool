using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void PlayGame(){
        SceneManager.LoadScene("TopicSelection");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("StartingMenuScene");
    }

}
