using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void PlayGame(){
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame(){
        Application.Quit();
        Debug.Log("Quit!");
    }

    public void BackToMainMenu(){
        SceneManager.LoadScene("StartingMenuScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
