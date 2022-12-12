using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float velocity;
    public Transform floorControl;
    public float distance;
    public bool moveRight;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D floorInformation = Physics2D.Raycast(floorControl.position, Vector2.down, distance);

        rb.velocity = new Vector2(velocity, rb.velocity.y);

        if (floorInformation == false)
        {
            //Spining
            Spining();
        }
    }

    private void Spining()
    {
        moveRight = !moveRight;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocity *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(floorControl.transform.position, floorControl.transform.position + Vector3.down * distance);
    }
}
