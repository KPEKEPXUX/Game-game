using Eccentric;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool _panelState = false;
    public GameObject mainCharacter;
    public GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) & _panelState == false)
        {
            Debug.Log("P is pressed");
            IntoPause();
        }
        else if (Input.GetKeyDown(KeyCode.P) & _panelState == true)
        {
            Debug.Log("P is pressed");
            OutPause();
        }
    }
    public void IntoPause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        _panelState = true;
        Cursor.lockState = CursorLockMode.None;
        mainCharacter.GetComponent<Camera_player>().enabled = false;
        mainCharacter.GetComponent<Movement>().enabled = false;
        mainCharacter.GetComponentInChildren<Terminator>().enabled = false;
    }
    public void OutPause()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
        _panelState = false;
        Cursor.lockState = CursorLockMode.Locked;
        mainCharacter.GetComponent<Camera_player>().enabled = true;
        mainCharacter.GetComponent<Movement>().enabled = true;
        mainCharacter.GetComponentInChildren<Terminator>().enabled = true;
    }
    public void ExitToMainmenu()
    {
        SceneManager.LoadScene(1);
    }
}
