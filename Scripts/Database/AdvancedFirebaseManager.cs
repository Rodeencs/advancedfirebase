using System;
using System.Collections;
using System.Collections.Generic;
using AdvancedFirebase.Database;
using UnityEditor;
using UnityEngine;

public class AdvancedFirebaseManager : MonoBehaviour
{
    private AESSettings AesSettings;
    public string Password;

    private bool isAlreadyInited;
    #region Singleton

    private static AdvancedFirebaseManager instance;
    

    public static AdvancedFirebaseManager Instance
    {
        get
        {
            if (AdvancedFirebaseManager.Instance == null)
            {
                GameObject newObj = new GameObject();
                newObj.AddComponent<AdvancedFirebaseManager>();
            }
            
            return AdvancedFirebaseManager.Instance;
        }
    }
    
    


    #endregion

    

    public void Initialize()
    {
        
        if (isAlreadyInited) return;
        AesSettings = AssetDatabase.LoadAssetAtPath<AESSettings>("Assets/Advanced Firebase/ScriptableObjects/AES.asset");
        Password = AesSettings.Password;
        
        Debug.Log("Initialized");
        isAlreadyInited = true;
    }
}
