using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    #region Fields
    public FloatingJoystick js;
    public float speed;
    public Animator anim;
    public float turnspeed;
    public Rigidbody rb;
    #endregion

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        PlayerMove();
    }
    void PlayerMove()
    {

        rb.velocity = new Vector3(js.Horizontal * speed * Time.fixedDeltaTime, rb.velocity.y, js.Vertical * speed * Time.fixedDeltaTime);
        if (js.Horizontal != 0 || js.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity * Time.fixedDeltaTime);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
        
    }

}
