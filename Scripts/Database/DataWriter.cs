using System.Collections;
using System.Collections.Generic;
using AdvancedFirebase.Encryption;
using Firebase.Database;
using UnityEngine;

namespace AdvancedFirebase.Database.Write
{
    public class DataWriter
        {
               #region Write Default Value
            
                    //It takes a string value and asks if it should be encrypted.
                    //Path takes the place to save.
                    public void WriteData(string value, string path, bool needEncrypt)
                    {
                        var reference = FirebaseDatabase.DefaultInstance.RootReference;
                        if (needEncrypt)
                        {
                            AESCrypt crypt = new AESCrypt();
                            var cryptedValue = crypt.Encrypt(value);
                           
                            
                            
                            //Connect and write
                            reference.Child(path).SetValueAsync(cryptedValue);
                            return;
                        }
                        else
                        {
                            reference.Child(path).SetValueAsync(value);
                        }
                    }
                    //It takes a string value and asks if it should be encrypted.
                    //Path takes the place to save.
                    public void WriteData(string value, DatabaseReference path, bool needEncrypt)
                    {
                        if (needEncrypt)
                        {
                            AESCrypt crypt = new AESCrypt();
                            var cryptedValue = crypt.Encrypt(value);
                            path.SetValueAsync(cryptedValue);
                            return;
                        }
                        else
                        {
                            path.SetValueAsync(value);
                        }
                    }
            
                    #endregion
               #region Write Json Format
            
                    //It takes a string value and asks if it should be encrypted.
                    //Path takes the place to save.
                    public void WriteJsonData(string value, string path)
                    {
                        var reference = FirebaseDatabase.DefaultInstance.RootReference;
                        //Connect and write
                        reference.Child(path).SetRawJsonValueAsync(value);
            
                    }
                    //It takes a string value and asks if it should be encrypted.
                    //Path takes the place to save.
                    public void WriteJsonData(string value, DatabaseReference path)
                    {
                        //Connect and write
                        path.SetRawJsonValueAsync(value);
            
                    }
                    
            
                    #endregion
        } 
}

