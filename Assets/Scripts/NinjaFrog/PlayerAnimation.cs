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

    [SerializeField]
    private OnScreenButtons onScreenButtons;
    [SerializeField]
    private bool canTakeInput;

    private void OnEnable()
    {
        onScreenButtons.JumpEvent += OnJumpButtonPressed;
        onScreenButtons.Move += MovePlayer;
    }

    private void OnDisable()
    {
        onScreenButtons.JumpEvent -= OnJumpButtonPressed;
        onScreenButtons.Move -= MovePlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnJumpButtonPressed()
    {
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            //if (Input.GetKey(KeyCode.RightArrow))
            //{
            //    var newScale = new Vector3(1, 1, 1);
            //    transform.localScale = newScale;
            //    animator.SetBool("Run", true);
            //}
            //else if (Input.GetKeyUp(KeyCode.RightArrow))
            //{
            //    animator.SetBool("Run", false);
            //}

            //if(Input.GetKey(KeyCode.LeftArrow))
            //{
            //    var newScale = new Vector3(-1, 1, 1);
            //    transform.localScale = newScale;
            //    animator.SetBool("Run", true);
            //}
            //else if(Input.GetKeyUp(KeyCode.LeftArrow))
            //{
            //    animator.SetBool("Run", false);
            //}

            if (canTakeInput)
            {
                float move = Input.GetAxis("Horizontal"); //0 - 1
                MovePlayer(move);

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Jump();
                }
            }
        }
    }

    private void MovePlayer(float move)
    {
        transform.Translate(Vector3.right * move * 5 * Time.deltaTime);
        float animMoveValue = move;

        if (animMoveValue == 0)
        {
            animMoveValue = -1;
        }
        else
        {
            animMoveValue = 1;
        }

        animator.SetFloat("Move", animMoveValue);

        if (move > 0)
        {
            var newScale = new Vector3(1, 1, 1);
            transform.localScale = newScale;
        }
        else if (move < 0)
        {
            var newScale = new Vector3(-1, 1, 1);
            transform.localScale = newScale;
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rigidbody.AddForce(Vector2.up * force);
            animator.SetBool("Jump", true);
            int randJump = Random.Range(0, 2);
            animator.SetInteger("JumpId", randJump);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true;
                //animator.SetTrigger("Jump");
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
