using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_sp : MonoBehaviour
{
    public GameObject enemy;
    ///
    void Start()
    {
        StartCoroutine(spawn());
    }
    ///
    IEnumerator spawn()
    {
        while(true)
        {
            for (int i=0; i < 3; i++)
            {
                Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(10);
        }
    }
}
