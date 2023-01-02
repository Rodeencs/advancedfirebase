using System.Collections;
using System.Collections.Generic;
using AdvancedFirebase.Encryption;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

namespace AdvancedFirebase.Database.Read
{
    public class DataReader
        {
            #region Read Normal


            public string Read(string path)
            {
                var reference = FirebaseDatabase.DefaultInstance.RootReference;

                var decryptedValue = "";
                
                //Read value from database
                reference.Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed" + task.Exception);
                        return;
                    }   
                    //Done
                    DataSnapshot snapshot = task.Result;
                    var value = snapshot.Value.ToString();
                    AESCrypt crypt = new AESCrypt();
                    decryptedValue = crypt.Decrypt(value);
                    decryptedValue = value;

                });

                return decryptedValue;
            }

            public string Read(DatabaseReference reference)
            {
                

                var decryptedValue = "";
                
                //Read value from database
                reference.GetValueAsync().ContinueWithOnMainThread(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed" + task.Exception);
                        return;
                    }   
                    //Done
                    DataSnapshot snapshot = task.Result;
                    var value = snapshot.Value.ToString();
                    AESCrypt crypt = new AESCrypt();
                    decryptedValue = crypt.Decrypt(value);
                    decryptedValue = value;

                });

                return decryptedValue; 
            }
            

            #endregion

            #region Read Json

            public string ReadJson(string path)
            {
                var strJson = "";

                var reference = FirebaseDatabase.DefaultInstance.RootReference;

                //Get value from database
                reference.Child(path).GetValueAsync().ContinueWithOnMainThread(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed " + task.Exception );
                        return;
                    }
                    //Done
                    DataSnapshot snapshot = task.Result;
                    var jsonFormat = snapshot.GetRawJsonValue();
                    strJson = jsonFormat;

                });
                return strJson;
            }
            public string ReadJson(DatabaseReference reference)
            {
                var strJson = "";

               

                //Get value from database
                reference.GetValueAsync().ContinueWithOnMainThread(task =>
                {
                    if (task.IsFaulted)
                    {
                        Debug.LogError("Failed " + task.Exception );
                        return;
                    }
                    //Done
                    DataSnapshot snapshot = task.Result;
                    var jsonFormat = snapshot.GetRawJsonValue();
                    strJson = jsonFormat;

                });
                return strJson;
            }

            #endregion
        }
}

