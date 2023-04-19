using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public Button openContent;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.scoreText.text = "" + score;
        if (score>=5)
        {
            openContent.interactable = true;
        }
    }
}
