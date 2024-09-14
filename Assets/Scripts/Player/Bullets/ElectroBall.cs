using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ElectroBall : Bullet
{
    private Vector3 _acceleration;
    private Rigidbody _rb;
 
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _acceleration = _rb.velocity;
    }

    public void OnCollisionEnter(Collision collision)
    {
        var speed = _acceleration.magnitude;
        var direction = Vector3.Reflect(_acceleration.normalized, collision.contacts[0].normal);
        _rb.velocity = direction * speed;

        if (collision.gameObject.tag == "Enemy" /*& _damageDealing*/)
        {
            Debug.Log("collisionStarted");
            _damageDealing = false;
            Timer();
            collision.gameObject.GetComponent<EneHP>().E_toughness -= damage;
        }
    }

    IEnumerator Timer()
    {
        Debug.Log("TImerStarted");
        yield return new WaitForSeconds(0.4f);
        _damageDealing = true;
    }
}
