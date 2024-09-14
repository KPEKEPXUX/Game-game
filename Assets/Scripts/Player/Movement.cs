using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eccentric
{
    public class Movement : MonoBehaviour
{
    private float SPEED = 2f;           
    private bool DJump;
    private bool isGround;
    void Start()
    {
        isGround = true;
        DJump=true;
        Cursor.lockState = CursorLockMode.Locked;
    }

   

    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && (DJump == true || isGround==true))
        {
         GetComponent<Rigidbody>().velocity = new Vector3(0,8,0);
         if (isGround==false)
         {
            DJump = false;
         }
         isGround = false;
        } 
        Move();
        // sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SPEED = 6f;
        }
        else
        {
            SPEED = 3f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Player") && other.CompareTag("Ground") )
        {
            isGround = true;
            DJump = true;
        }
    } 

    void Move()
    {
        float forward = Input.GetAxis("Vertical");
        float left = Input.GetAxis("Horizontal");
        float up = 0;
        Vector3 offset = new Vector3(left,up,forward)* SPEED *Time.unscaledDeltaTime;
        transform.Translate(offset);
    }
 

}
}