using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class MagicMissile : MonoBehaviour
{
    public Ray arcRay;
    public Transform startPoint;
    public Transform finishPoint;
    public GameObject missile;
    public float angle;

    private Vector3 _distance;
    private Vector3 _distanceXZ;
    private float _gravity = Physics.gravity.y;

    void Update()
    {
        //EyeLasers();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void EyeLasers()
    {
        RaycastHit info;
        arcRay = new Ray(startPoint.position, Vector3.forward);
        Debug.DrawRay(startPoint.position, Vector3.forward * 200, Color.red);
        if (Physics.Raycast(arcRay, out info))
        {
            info.collider.gameObject.GetComponent<Renderer>().material.color= Color.red;
            finishPoint.position = info.point;
        }
    }
    void Shoot()
    {
        startPoint.localEulerAngles = new Vector3(-angle, 0, 0);
        _distance = finishPoint.position - startPoint.position;
        //_distanceXZ = new Vector3(_distance.x, 0 , _distance.z);

        transform.rotation = Quaternion.LookRotation(_distance, Vector3.up);

        float x = _distance.magnitude;
        float y = _distance.y;
        float radiance = angle*Mathf.PI/180;
        float part1 = (_gravity*x*x) / (2 * (y-Mathf.Tan(radiance)*x)*Mathf.Pow(Mathf.Cos(radiance), 2));
        float part2 = Mathf.Sqrt(Mathf.Abs(part1));
        GameObject bullet = Instantiate(missile, startPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = startPoint.forward * part2;
        
    }
}
