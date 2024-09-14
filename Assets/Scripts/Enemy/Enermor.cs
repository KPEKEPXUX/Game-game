using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermor : MonoBehaviour
{
    public int E_toughness = 100;
    public int dmg = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            E_toughness -= dmg;
            Debug.Log("Armor hit!");
            collision.gameObject.tag = "Untagged";
        }
    }
    
    void Update()
    {
        if (E_toughness <= 0)
        {
            Destroy(gameObject);
        }
    }
}
