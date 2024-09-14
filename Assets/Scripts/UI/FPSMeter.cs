using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UIElements;

public class FPSMeter : MonoBehaviour
{
    private string _fps;
    private void Start()
    {
        StartCoroutine("Spacer");
    }
    private void Update()
    {
        _fps = "" + Time.frameCount / Time.time;
    }
    IEnumerator Spacer()
    {
        while (true)
        {
            gameObject.GetComponent<TMP_Text>().text = _fps;
            yield return new WaitForSeconds(1);
        }
    }
}
