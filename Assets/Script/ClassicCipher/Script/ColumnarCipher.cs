using System;
using TMPro;
using UnityEngine;

public class ColumnarCipher : MonoBehaviour
{
    private static int key = 3;
    private char[,] outputArr;
    private int _col = key;
    private int _row = 0;
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI playerPlainText;
    public TextMeshProUGUI playerCipherText;
    public TextMeshProUGUI cipherText;

    // Update is called once per frame
    void Update()
    {
        keyText.text = key + "";
        playerCipherText.text = "Ciphertext(in Diagram):\n" + OutputPlayerCipherText();
        cipherText.text = "Ciphertext:\n" + OutputCipherText();
    }

    private string OutputCipherText(){
        string output= "";
        if(playerPlainText.text.Length-1 <= key){
            output = playerPlainText.text;
        } else {
            output += codeText();
        }
        
        return output;
    }

    private string OutputPlayerCipherText()
    {
        string output = "";
        string str = playerPlainText.text;
        _col = key;
        _row = str.Length-1/key;

        if((str.Length-1) <= key){
            output += str;
            return output;
        } else{
            if ((str.Length-1)%key > 0){
                _row++;
            }
            outputArr = EncryptedCharArr(str,_col,_row);
        
            for (int i = 0; i < _row;i++){
                for (int j = 0; j < _col; j++){
                    if (outputArr[i,j] == '-'){
                         output += "";
                    } else{
                        output += outputArr[i,j];
                        if(j + 1 == _col ){output += "\n";}
                    }
                }
            }
        }
        return output;
    }

    private string codeText(){
        string str = "";
        for (int c = 0; c < _col; c++){
            for (int r = 0; r < _row; r++){
                if(outputArr[r,c] == '-'){
                    str += "";
                } else {
                    str += outputArr[r,c];
                }
                
            }
        }
        return str;
    }

    private char[,] EncryptedCharArr(string str, int col, int row){
        char[,] code = new char[row,col];
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                try
                {
                    code[i,j] = str[j+key * i];
                } catch (IndexOutOfRangeException)
                {
                    
                    code[i,j] = '-';
                }
                
            }
        }

        return code;
    }

    public void IncreaseKey(){
        if(key == 6){
            key = 6;
        } else {
            key++;
        }
    }

    public void DecreaseKey(){
        if(key == 1){
            key = 1;
        } else {
            key--;
        }
    }
}
