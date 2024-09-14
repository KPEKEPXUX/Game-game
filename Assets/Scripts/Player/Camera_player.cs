using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_player : MonoBehaviour
{   
    public enum RotationAxis
    {
        MouseXY = 0,
        MouseX = 1,
        MouseY = 2,
    }
    public RotationAxis turn = RotationAxis.MouseXY;
    public float Hor = 5; 
    public float Ver = 5; 
    public float minVer = -90; 
    public float maxVer = 90; 
    private float _rotX = 0;
    void Start()
    {
        Rigidbody Physics = GetComponent<Rigidbody>();
        if (Physics != null)
        {
            Physics.freezeRotation = true;
        }
    }

    void Update()
    {
        if (turn == RotationAxis.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * Hor, 0);
        }
        else if (turn == RotationAxis.MouseY)
        {
            _rotX -=  Input.GetAxis("Mouse Y")  * Ver;
            _rotX = Mathf.Clamp(_rotX,minVer,maxVer);
            float rotY =transform.localEulerAngles.y;
            transform.localEulerAngles=new Vector3(_rotX,rotY, 0);
        }
        else
        {
            //makes Y axis_
            _rotX -= Input.GetAxis("Mouse Y")  * Ver;
            //Rounds up Y
            _rotX = Mathf.Clamp(_rotX,minVer,maxVer);
            //makes X axis
            float delta = Input.GetAxis("Mouse X")  * Hor;
            // puts coordinates of body (???)
            float rotY= transform.localEulerAngles.y + delta;
            //applies
            transform.localEulerAngles=new Vector3(_rotX,rotY, 0);
        }
    }
}
