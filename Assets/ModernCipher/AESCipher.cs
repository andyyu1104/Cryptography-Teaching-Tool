/**
*   Methods EncryptStringToBytes_Aes and DecryptStringFromBytes_Aes are copied from microsoft.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System;
using System.IO;

public class AESCipher : MonoBehaviour
{
    public TextMeshProUGUI keyText;
    public TextMeshProUGUI playerPlainText;
    public TextMeshProUGUI playerCipherText;
    public TextMeshProUGUI decryptedText;


    private int[] _key = {128,192,256}; //AES key size
    private int _keyPos = 0;
    private Aes _usingAes = Aes.Create();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _usingAes.KeySize = _key[_keyPos];
        keyText.text = _key[_keyPos] + "";
    }

    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV){
        // Check arguments.
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException("plainText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");
        byte[] encrypted;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create()){
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream()){
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)){
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)){
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
    }

    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        // Check arguments.
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException("Key");
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException("IV");

        // Declare the string used to hold
        // the decrypted text.
        string plaintext = null;

        // Create an Aes object
        // with the specified key and IV.
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }

    public void IncreaseKey(){
        if(_keyPos == 2){
            _keyPos = 0;
        } else {
            _keyPos++;
        }
    }

    public void DecreaseKey(){
        if(_keyPos == 0){
            _keyPos = 2;
        } else {
            _keyPos--;
        }
    }



    public void EncryptText(){
        byte[] encryptedData = EncryptStringToBytes_Aes(playerPlainText.text, _usingAes.Key, _usingAes.IV);
        playerCipherText.text = BitConverter.ToString(encryptedData);
        decryptedText.text = DecryptStringFromBytes_Aes(encryptedData, _usingAes.Key, _usingAes.IV);
    }
}
