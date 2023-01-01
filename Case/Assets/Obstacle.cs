using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Mode mode;
    [SerializeField] private int value;
    [SerializeField] private TextMeshPro textMeshPro;

    private bool _isUsed;
    
    public enum Mode
    {
        Multiplication,
        Addition
    }

    private void Start()
    {
        SetText();

        if (mode == Mode.Multiplication && value < 1)
        {
            Debug.Log("Value can't be negative in multiplication mode!!!");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isUsed) return;
        
        Transform playerTf = other.transform.parent.parent; 
        if (!playerTf.CompareTag("Player")) return;
        
        playerTf.GetComponent<PlayerManager>().OnTriggered(mode,value);
        _isUsed = true;
    }
    
    private void SetText()
    {
        string displayString = "";
        if (mode == Mode.Addition)
        {
            if (value > 0)
            {
                displayString += "+";
            }
        }
        else if (mode == Mode.Multiplication)
        {
            if (value > 1)
            {
                displayString += "X ";
            }
            
        }
        
        displayString += value;
        textMeshPro.text = displayString;
    }
}
