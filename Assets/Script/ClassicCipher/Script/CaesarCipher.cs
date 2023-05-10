using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaesarCipher : MonoBehaviour
{
    public TextMeshProUGUI plainAlphabet;
    public TextMeshProUGUI encryptedAlphabet;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI playerPlainText;
    public TextMeshProUGUI playerCipherText;
    private char[] _alphabetsArr = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
    private int key = 0;

    // Start is called before the first frame update
    void Start()
    {
        plainAlphabet.text = new string(_alphabetsArr);
        encryptedAlphabet.text = new string(_alphabetsArr);
    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = key + "";
        encryptedAlphabet.text = new string(EncryptedAlphabets());
        playerCipherText.text = "Ciphertext(Encrypted):\n" + OutputPlayerCipherText();
    }

    private string OutputPlayerCipherText(){
        string str = playerPlainText.text;
        string outStr = "";
        for (int i = 0; i<playerPlainText.text.Length; i++){
            if (!char.IsLetter(str[i])){
                outStr+=str[i];
            } else {
                char c = char.IsUpper(str[i]) ? 'A' : 'a';  
                outStr += (char)((((str[i]+key) -c) % 26)+c);
            }
        }
        return outStr;
    }

    private char[] EncryptedAlphabets(){
        char[] output = new char[26];
        for (int i = 0; i < _alphabetsArr.Length; i++){
            output[i] = _alphabetsArr[(i+key)%26];
            
        }
        return output;
    } 


    public void IncreaseKey(){
        if(key == 26){
            key = 0;
        } else {
            key++;
        }
    }

    public void DecreaseKey(){
        if(key == 0){
            key = 26;
        } else {
            key--;
        }
    }
}
