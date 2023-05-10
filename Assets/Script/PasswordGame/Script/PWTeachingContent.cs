using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PWTeachingContent : MonoBehaviour
{

    public TextMeshProUGUI outputText;
    public TMP_InputField password;
    public TMP_InputField salt;



    // Update is called once per frame
    void Update()
    {
        outputText.text = password.text+salt.text;
    }
}
