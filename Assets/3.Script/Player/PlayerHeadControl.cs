using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadControl : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxisRaw("MoveX");
        float MoveY = Input.GetAxisRaw("MoveY");

        if (MoveX == 0 && MoveY == 0)
        {
            animator.SetBool("Move", false);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetBool("Move", true);
            animator.SetFloat("MoveX", MoveX);
            animator.SetFloat("MoveY", MoveY);
        }


        float AttackX = Input.GetAxisRaw("Horizontal");
        float AttackY = Input.GetAxisRaw("Vertical");

        if (AttackX == 0 && AttackY == 0)
        {
            animator.SetBool("Attack", false);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
        else
        {
            animator.SetBool("Attack", true);
            animator.SetFloat("Horizontal", AttackX);
            animator.SetFloat("Vertical", AttackY);
        }
    }
}
