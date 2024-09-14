using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMethods : MonoBehaviour
{
    GameObject _fpsDropDown,
               _resDropDown;
    
    private Storage _storage;
    private GameData _gameData;
    private void Start()
    {
        _fpsDropDown = GameObject.Find("MainCanvas").transform.GetChild(0).GetChild(3).GetChild(0).gameObject;

        _resDropDown = GameObject.Find("Resolution");
        _storage = new Storage();
        
    }
    public void ScreenResChange()
    {
        int value = _resDropDown.GetComponent<TMP_Dropdown>().value;
        _gameData = (GameData)_storage.Load(new GameData());
        switch (value)
        {
            case 0:
                Screen.SetResolution(1920, 1080, true);
                _gameData.resolution.x = 1920;
                _gameData.resolution.y = 1080;
                break;
            case 1:
                Screen.SetResolution(1440, 900, true);
                _gameData.resolution.x = 1440;
                _gameData.resolution.y = 900;
                break;
            case 2:
                Screen.SetResolution(10, 4, true);
                _gameData.resolution.x = 10;
                _gameData.resolution.y = 4;
                break;
        }
        _storage.Save(_gameData);
    }
    public void FPSChange()
    {
        int value = _fpsDropDown.GetComponent<TMP_Dropdown>().value;
        _gameData = (GameData)_storage.Load(new GameData());
        switch (value)
        {
            case 0:
                Application.targetFrameRate = 120;
                _gameData.fps = 120;
                break;
            case 1:
                Application.targetFrameRate = 90;
                _gameData.fps = 90;
                break;
            case 2:
                Application.targetFrameRate = 60;
                _gameData.fps = 60;
                break;
            case 3:
                Application.targetFrameRate = 30;
                _gameData.fps = 30;
                break;
            case 4:
                Application.targetFrameRate = 2;
                _gameData.fps = 2;
                break;
        }
        _storage.Save(_gameData);
    }

    public void FPSMeter()
    {
        //
    }
}
