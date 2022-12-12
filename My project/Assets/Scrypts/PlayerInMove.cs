using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInMove : MonoBehaviour
{
    private Rigidbody2D rgdbd2d;

    [Header("Moving")]

    private float horizontalMove = 0f;
    public float moveVelocity;
    public float moveSoft;
    private Vector3 velocity = Vector3.zero;
    private bool lookingRight = true;

    [Header("Jump")]
    public float jumpForce;
    public LayerMask whatIsFloar;
    public Transform floorController;
    public Vector3 boxDimensions;
    public bool inFloor;
    private bool jump = false;

    [Header("Boing")]
    public float velocityBoing;

    private void Start()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveVelocity;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        inFloor = Physics2D.OverlapBox(floorController.position, boxDimensions, 0f, whatIsFloar);
        //Moving
        Moving(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }

    private void Moving(float moving, bool jumper) {
        Vector3 objectVelocity = new Vector2(moving, rgdbd2d.velocity.y);
        rgdbd2d.velocity = Vector3.SmoothDamp(rgdbd2d.velocity, objectVelocity, ref velocity, moveSoft);

        if (moving > 0 && !lookingRight)
        {
            //Rotate
            Rotate();
        }

        else if (moving < 0 && !lookingRight)
        {
            //Rotate\
            Rotate();
        }

        if (inFloor && jumper) { 
            inFloor = false;
            rgdbd2d.AddForce(new Vector2(0f, jumpForce));
        }
    }

    public void Boing()
    {
        rgdbd2d.velocity = new Vector2(rgdbd2d.velocity.x, velocityBoing);
    }

    private void Rotate()
    {
        lookingRight = !lookingRight;
        Vector3 scaling = transform.localScale;
        scaling.x *= -1;
        transform.localScale = scaling;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(floorController.position, boxDimensions);
    }


}
