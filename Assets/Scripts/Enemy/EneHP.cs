using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EneHP : MonoBehaviour
{
    public int E_toughness = 100;
    public Slider hp_slider;
    public int PointGain = 1;
    public GameObject spawnOnDeath;
    private Storage _storage;
    private GameData _gameData;

    void Start()
    {
        _storage = new Storage();
        if (hp_slider)
        {
            hp_slider.value = E_toughness;
        }
    }

    void Update()
    {
        if (hp_slider)
        {
            hp_slider.value = E_toughness;
        }

        if (E_toughness <= 0)
        {
            _gameData = (GameData)_storage.Load(new GameData());
            if (spawnOnDeath)
            {
                Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
            }
            _gameData.money += PointGain;
            _storage.Save(_gameData);
            Destroy(gameObject);

        }
    } 

}
