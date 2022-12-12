using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject efect;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

                if (other.GetContact(0).normal.y <= -0.9)
                {
                    animator.SetTrigger("Hit");
                    other.gameObject.GetComponent<PlayerInMove>().Boing();
                }

                
            
        }
    }

    public void Hit()
    {
        Instantiate(efect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
