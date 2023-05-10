using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    private static int _score = 0;
    public TextMeshProUGUI scoreText;
    public Button openContent;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.text = "" + _score;

        if (_score>=5)
        {
            openContent.interactable = true;
        }
    }


    public static void GetScore(){
        _score++;
    }

    public static void LoseScore(){
        if (_score>0)
        {
            _score--;
        }
        
    }
    
}
