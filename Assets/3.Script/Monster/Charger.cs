using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonsterStats
{
   
    


    private bool IsRayAcitve;
    RaycastHit2D UpRayHit;
    RaycastHit2D DownRayHit;
    RaycastHit2D LeftRayHit;
    RaycastHit2D RightRayHit;
    LayerMask layerMask;
    public override void Awake()
    {
        base.Awake();
        layerMask = LayerMask.GetMask("Player");
        IsRayAcitve = false;
        MaxHp = 20f;
        CurHp = 20f;
    }
    public void FixedUpdate()
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
            StopMove();
            moveMent2D.MoveTo(Vector3.up);
            animator.SetTrigger("UpDash");
            moveMent2D.moveSpeed = 5f;
            IsRayAcitve = true;
            isActive = true; 
        }
        if (DownRayHit)
        {
            StopMove();
            moveMent2D.MoveTo(Vector3.down);
            moveMent2D.moveSpeed = 5f;
            animator.SetTrigger("DownDash");
            IsRayAcitve = true;
            isActive = true;
        }
        if (LeftRayHit)
        {
            StopMove();
            transform.Rotate(0, 180, 0);
            moveMent2D.MoveTo(Vector3.left);
            moveMent2D.moveSpeed = 5f;
            animator.SetTrigger("LeftDash");
            IsRayAcitve = true;
            isActive = true;
        }
        if (RightRayHit)
        {
            StopMove();
            moveMent2D.MoveTo(Vector3.right);
            moveMent2D.moveSpeed = 5f;
            animator.SetTrigger("RightDash");
            IsRayAcitve = true;
            isActive = true;
        }



    }
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("Wall"))
        {
            moveMent2D.MoveTo(Vector3.zero);
            moveMent2D.moveSpeed = 2f;
            animator.SetTrigger("StopDash");
            IsRayAcitve = false;
            isActive = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (collision.CompareTag("PlayerTears"))
        {
            CurHp -= playerStats.Attack;
            Debug.Log(CurHp);
            if (CurHp<=0)
            {
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("BoomDamage"))
        {
            CurHp -= 5;
            if (CurHp<=0)
            {
                Destroy(gameObject);
            }
        }
    }
}
