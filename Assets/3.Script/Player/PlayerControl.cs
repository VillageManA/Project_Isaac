using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Animator animator;
    public bool Attack = false;
    public bool Move = false;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out animator);
    }

    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxisRaw("Mouse X");
        float MoveY = Input.GetAxisRaw("Mouse Y");

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

        float AttackX =Input.GetAxisRaw("Horizontal");
        float AttackY =Input.GetAxisRaw("Vertical");

        if (AttackX == 0 && AttackY ==0)
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
