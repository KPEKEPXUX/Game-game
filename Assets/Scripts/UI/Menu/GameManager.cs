using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Storage _storage;
    private GameData _gameData;

    private void Awake()
    {
        
        GameLoad();
    }

    private void GameLoad()
    {
        _storage = new Storage();
        _storage.Save(new GameData());
        _gameData = (GameData)_storage.Load(new GameData());

        Application.targetFrameRate = _gameData.fps;
        Screen.SetResolution(_gameData.resolution.x, _gameData.resolution.y, true);
    }
    
}
