using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera _mainCamera;
    private Transform _gunPoint;
    public int spread,
               damage = 10;
    public float velocity=1,
                 lifetime=10,
                 manaRequirement=10;
    protected bool _damageDealing = true;


    private void Start()
    {
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        _gunPoint = GameObject.Find("Bullet point").transform;
        if (_mainCamera.gameObject.GetComponent<Terminator>().currentMana < manaRequirement)
        {
            Destroy(gameObject);
        }
        else
        {
            _mainCamera.gameObject.GetComponent<Terminator>().currentMana -= manaRequirement;
        }
        Destroy(gameObject, lifetime);
        Shoot();
    }
    
    void Shoot()
    {
        Ray bullet = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit shot;
        Vector3 cords;

        if (Physics.Raycast(bullet, out shot))
        {
            cords = shot.point;
        }
        else
        {
            cords = bullet.GetPoint(75);
        }
        Vector3 dir = cords - _gunPoint.position;
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 axis = dir + new Vector3(x, y, 0);


        transform.right = axis.normalized;
        GetComponent<Rigidbody>().AddForce(axis.normalized * velocity, ForceMode.Impulse);
    }
  
}
