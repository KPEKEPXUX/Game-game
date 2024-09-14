using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPbar : MonoBehaviour
{
    public float HP = 0f;
    public Image health_bar;
    void Start()
    {
        
    }

    void Update()
    {
       HP = health_bar.fillAmount;
       if (HP == 1)
       {
           SceneManager.LoadScene("over");
       } 
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health_bar.fillAmount += 0.05f;
            transform.position = transform.position - new Vector3(0,0,0);
           
           
        }   
    }
}
