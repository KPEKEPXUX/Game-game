using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestScriot : MonoBehaviour
{
    public string savedText;

    void Start()
    {
        //
    }

    public void SaveText()
    {
        savedText = gameObject.GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("key", savedText);
        //
    }
    public void LoadText()
    {
        string _txt = PlayerPrefs.GetString("key");
        gameObject.GetComponent<TMP_InputField>().text = _txt;
    }
}
