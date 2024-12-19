using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float force;

    [SerializeField]
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                var newScale = new Vector3(1, 1, 1);
                transform.localScale = newScale;
                animator.SetBool("Run", true);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                animator.SetBool("Run", false);
            }

            if(Input.GetKey(KeyCode.LeftArrow))
            {
                var newScale = new Vector3(-1, 1, 1);
                transform.localScale = newScale;
                animator.SetBool("Run", true);
            }
            else if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                animator.SetBool("Run", false);
            }

            if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rigidbody.AddForce(Vector2.up * force);
                animator.SetBool("Jump", true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                animator.SetBool("Jump", false);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false;
            }
        }
    }
}
