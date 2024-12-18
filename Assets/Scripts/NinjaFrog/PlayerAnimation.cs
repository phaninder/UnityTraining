using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator != null)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                animator.SetBool("Run", true);
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                animator.SetBool("Run", false);
            }

        }
    }
}
