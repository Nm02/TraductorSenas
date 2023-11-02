using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Key : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] Text KeyText;
    private char key;

    [Header(" Settings ")]
    [SerializeField] bool isBackSpace;

    public void SetKey(char key)
    {
        this.key = key;
        KeyText.text = key.ToString();
    }

    public Button GetButton()
    {
        return GetComponent<Button>();  
    }

    public bool IsBackSpace()
    {
        return isBackSpace;
    }
}
