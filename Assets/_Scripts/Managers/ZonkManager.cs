using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZonkManager : MonoBehaviour
{
    public float PlayerOneZonkLevel = 0f;
    public float PlayerTwoZonkLevel = 0f;
    public TMP_Text zonkText;

    void Start()
    {
        PlayerOneZonkLevel = 0f;
        PlayerTwoZonkLevel = 0f;
    }

    void Update()
    {
        
    }
}