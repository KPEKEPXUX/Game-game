using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float radius = 3,
                 knockback = 1000,
                 lift = 1;
    public int damage = 40;

    public void Kaboom()
    {
        Collider[] foundEnemies = Physics.OverlapSphere(transform.position, radius);
        for (int i = 0; i < foundEnemies.Length; i++)
        {
            Rigidbody currentObject = foundEnemies[i].attachedRigidbody;
            EneHP currentScript = foundEnemies[i].gameObject.GetComponent<EneHP>();
            if (currentObject)
            {
                currentObject.AddExplosionForce(knockback, transform.position, radius, lift);
                if (currentScript)
                {
                    currentObject.gameObject.GetComponent<EneHP>().E_toughness -= damage;
                }
            }
        }
    }
    private void Start()
    {
        Kaboom();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
