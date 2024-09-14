using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;                

public class Portals : MonoBehaviour
{

    private int scene; 
    void OnCollisionEnter(Collision activator)
    {
        if(activator.gameObject.tag == "Player")
        {
            scene = SceneManager.GetActiveScene().buildIndex;

            if ((PlayerPrefs.GetInt("LevelsPassed") <= scene) || (!PlayerPrefs.HasKey("LevelsPassed")))
            {
                PlayerPrefs.SetInt("LevelsPassed", scene);
            }

            SceneManager.LoadScene(scene + 1);
        }
    }
}
