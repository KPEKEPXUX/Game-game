using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenResolution : MonoBehaviour
{
    public void ScreenResChange()
    {
        Debug.Log("Yep it works");
        Screen.SetResolution(1920, 1080, true);
    }
    
}
