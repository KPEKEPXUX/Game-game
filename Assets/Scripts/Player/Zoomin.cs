using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomin : MonoBehaviour
{
    public Animator scoper;
    public Camera Maincam;
    Coroutine naem;

    void Update()
    {
       if (Input.GetMouseButtonDown(1))
       {
         scoper.SetBool("scope",true);
         if(naem != null)
         {
         StopCoroutine(naem);
         }
         naem = StartCoroutine(closer(Maincam, 80, 0.1f));
       }

       if (Input.GetMouseButtonUp(1))
       {
         scoper.SetBool("scope",false);
         if(naem != null)
         {
            StopCoroutine(naem);
         }
          naem = StartCoroutine(closer(Maincam, 120, 0.1f));
       }
    }

    IEnumerator closer(Camera clocam, float endFOV, float dif)
    {
      if (scoper.GetBool("reloadin") == false)
      {
        float startFOV = Maincam.fieldOfView;
        float count = 0;
        while (count < dif)
        {
          count += Time.deltaTime;
          float time = count/dif;
          clocam.fieldOfView = Mathf.Lerp(startFOV, endFOV, time);
          yield return null;
        }
      }
    }

   
}
