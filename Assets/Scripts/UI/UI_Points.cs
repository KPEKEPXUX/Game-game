using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Data.SqlTypes;

public class UI_Points : MonoBehaviour
{
    public TMP_Text MText;
    private Storage _storage;
    private GameData _gameData;

    private void Start()
    {
        _storage = new Storage();
    }
    void Update()
    {
        _gameData = (GameData)_storage.Load(new GameData());
        MText.text= _gameData.money.ToString();
    }
}
