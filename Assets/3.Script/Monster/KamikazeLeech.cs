using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeLeech : MonoBehaviour
{
    private Animator animator;
    private Movement2D moveMent2D;


    private bool IsRayAcitve;
    RaycastHit2D UpRayHit;
    RaycastHit2D DownRayHit;
    RaycastHit2D LeftRayHit;
    RaycastHit2D RightRayHit;
    LayerMask layerMask;
    private void Awake()
    {
        moveMent2D = GetComponent<Movement2D>();
        animator = GetComponent<Animator>();
        layerMask = LayerMask.GetMask("Player");
        IsRayAcitve = false;
    }
    private void FixedUpdate()
    {
        if (IsRayAcitve)
        {
            return;
        }
        UpRayHit = Physics2D.Raycast(transform.position, Vector3.up, 3f, layerMask);
        DownRayHit = Physics2D.Raycast(transform.position, Vector3.down, 3f, layerMask);
        LeftRayHit = Physics2D.Raycast(transform.position, Vector3.left, 3f, layerMask);
        RightRayHit = Physics2D.Raycast(transform.position, Vector3.right, 3f, layerMask);

        if (UpRayHit)
        {
            moveMent2D.MoveTo(Vector3.up);
            animator.SetTrigger("UpDash");
            IsRayAcitve = true;
        }
        if (DownRayHit)
        {
            moveMent2D.MoveTo(Vector3.down);
            animator.SetTrigger("DownDash");
            IsRayAcitve = true;
        }
        if (LeftRayHit)
        {
            transform.Rotate(0, 180, 0);
            moveMent2D.MoveTo(Vector3.left);
            animator.SetTrigger("LeftDash");
            IsRayAcitve = true;
        }
        if (RightRayHit)
        {
            moveMent2D.MoveTo(Vector3.right);
            animator.SetTrigger("RightDash");
            IsRayAcitve = true;
        }



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Wall"))
        {
            moveMent2D.MoveTo(Vector3.zero);
            animator.SetTrigger("StopDash");
            IsRayAcitve = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
