using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int health = 3;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            animator.SetBool("Die", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            if (health > 0)
            {
                animator.SetBool("Hurt", true);
            }
        }
    }

    void FinishHurt()
    {
        animator.SetBool("Hurt", false);
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
