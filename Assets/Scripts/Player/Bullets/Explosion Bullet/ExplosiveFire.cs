using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveFire : Bullet
{
    public GameObject explosion;
    public Vector3 pointHit;

    void Awake()
    {
        Ray ray = GameObject.Find("Main Camera").gameObject.GetComponent<Camera>().ScreenPointToRay(GameObject.Find("scope").transform.position);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit))
        {
            pointHit = hit.point;
            Debug.Log(pointHit);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        transform.SetParent(collision.transform);
        transform.position = pointHit;
        GameObject clone = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        //clone.transform.SetParent(collision.transform);
        clone.transform.localScale = Vector3.one;
        Destroy(gameObject);
    }
}
