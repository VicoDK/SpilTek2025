using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

public class Counter : MonoBehaviour
{
    private PointsManager pointsManager;
    public TMP_Text CountText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCountText();  
    }

    private void SetCountText()
    {
        CountText.text = pointsManager.counter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
