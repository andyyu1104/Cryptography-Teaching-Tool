/**
* Methods EncryptTextToMemory and DecryptTextFromMemory are copied from microsoft.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System;
using System.IO;
using System.Text;
using TMPro;

public class DESCipher : MonoBehaviour
{

    public TextMeshProUGUI modeText;
    public TextMeshProUGUI playerPlainText;
    public TextMeshProUGUI playerCipherText;
    public TextMeshProUGUI decryptedText;


    private int _times = 1;
    private DES _usingDes = DES.Create();
    private TripleDES _usingTriDes = TripleDES.Create();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseTime(){
        if(_times == 3){
            _times = 1;
        } else {
            _times++;
        }
    }

    public void DecreaseTime(){
        if(_times == 1){
            _times = 3;
        } else {
            _times--;
        }
    }

    public void SwitchMode(){
        if(_times != 1){
            _times = 1;
            modeText.text = "Single";
        } else {
            _times = 3;
            modeText.text = "Triple";
        }
    }


    private byte[] EncryptTextToMemory1D(string text, byte[] key, byte[] iv)
    {
        try
        {
            // Create a MemoryStream.
            using (MemoryStream mStream = new MemoryStream())
            {
                
                // Create a new DES object.
                using(DES des = DES.Create())
                // Create a DES encryptor from the key and IV
                using (ICryptoTransform encryptor = des.CreateEncryptor(key, iv))
                // Create a CryptoStream using the MemoryStream and encryptor
                using (var cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                {
                    // Convert the provided string to a byte array.
                    byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                    // Write the byte array to the crypto stream and flush it.
                    cStream.Write(toEncrypt, 0, toEncrypt.Length);

                    // Ending the using statement for the CryptoStream completes the encryption.
                }

                // Get an array of bytes from the MemoryStream that holds the encrypted data.
                byte[] ret = mStream.ToArray();

                // Return the encrypted buffer.
                return ret;
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }

    private string DecryptTextFromMemory1D(byte[] encrypted, byte[] key, byte[] iv)
    {
        try
        {
            // Create a buffer to hold the decrypted data.
            // DES-encrypted data will always be slightly bigger than the decrypted data.
            byte[] decrypted = new byte[encrypted.Length];
            int offset = 0;

            // Create a new MemoryStream using the provided array of encrypted data.
            using (MemoryStream mStream = new MemoryStream(encrypted))
            {
                // Create a new DES object.
                using (DES des = DES.Create())
                // Create a DES decryptor from the key and IV
                using (ICryptoTransform decryptor = des.CreateDecryptor(key, iv))
                // Create a CryptoStream using the MemoryStream and decryptor
                using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                {
                    // Keep reading from the CryptoStream until it finishes (returns 0).
                    int read = 1;

                    while (read > 0)
                    {
                        read = cStream.Read(decrypted, offset, decrypted.Length - offset);
                        offset += read;
                    }
                }
            }

            // Convert the buffer into a string and return it.
            return Encoding.UTF8.GetString(decrypted, 0, offset);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }

    private byte[] EncryptTextToMemory3D(string text, byte[] key, byte[] iv)
    {
        try
        {
            
            using (MemoryStream mStream = new MemoryStream())
            {
                // Create a new TripleDES object.
                using (TripleDES tripleDes = TripleDES.Create())
                // Create a TripleDES encryptor from the key and IV
                using (ICryptoTransform encryptor = tripleDes.CreateEncryptor(key, iv))
                // Create a CryptoStream using the FileStream and encryptor
                using (var cStream = new CryptoStream(mStream, encryptor, CryptoStreamMode.Write))
                {
                    // Convert the provided string to a byte array.
                    byte[] toEncrypt = Encoding.UTF8.GetBytes(text);

                    // Write the byte array to the crypto stream.
                    cStream.Write(toEncrypt, 0, toEncrypt.Length);
                }

                // Get an array of bytes from the MemoryStream that holds the encrypted data.
                byte[] ret = mStream.ToArray();

                // Return the encrypted buffer.
                return ret;
            }
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }

    private string DecryptTextFromMemory3D(byte[] encrypted, byte[] key, byte[] iv)
    {
        try
        {
            // Create a buffer to hold the decrypted data.
            // DES-encrypted data will always be slightly bigger than the decrypted data.
            byte[] decrypted = new byte[encrypted.Length];
            int offset = 0;

            // Create a new MemoryStream using the provided array of encrypted data.
            using (MemoryStream mStream = new MemoryStream(encrypted))
            {
                // Create a new DES object.
                using (TripleDES triDes = TripleDES.Create())
                // Create a DES decryptor from the key and IV
                using (ICryptoTransform decryptor = triDes.CreateDecryptor(key, iv))
                // Create a CryptoStream using the MemoryStream and decryptor
                using (var cStream = new CryptoStream(mStream, decryptor, CryptoStreamMode.Read))
                {
                    // Keep reading from the CryptoStream until it finishes (returns 0).
                    int read = 1;

                    while (read > 0)
                    {
                        read = cStream.Read(decrypted, offset, decrypted.Length - offset);
                        offset += read;
                    }
                }
            }

            // Convert the buffer into a string and return it.
            return Encoding.UTF8.GetString(decrypted, 0, offset);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine("A Cryptographic error occurred: {0}", e.Message);
            throw;
        }
    }



    public void EncryptText(){
        switch (_times)
        {
            case 1:
                byte[] encryptedData = EncryptTextToMemory1D(playerPlainText.text, _usingDes.Key, _usingDes.IV);
                playerCipherText.text = BitConverter.ToString(encryptedData);
                decryptedText.text = DecryptTextFromMemory1D(encryptedData, _usingDes.Key, _usingDes.IV);
                break;
            case 3:
                byte[] encryptedData3D = EncryptTextToMemory3D(playerPlainText.text, _usingTriDes.Key, _usingTriDes.IV);
                playerCipherText.text = BitConverter.ToString(encryptedData3D);
                decryptedText.text = DecryptTextFromMemory3D(encryptedData3D, _usingTriDes.Key, _usingTriDes.IV);
                break;
            default:
                Debug.Log("Error Times");
                break;
        }
        
    }

}
