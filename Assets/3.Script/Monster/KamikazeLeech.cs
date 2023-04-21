using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeLeech : MonsterStats
{
    private bool IsRayAcitve;
    RaycastHit2D UpRayHit;
    RaycastHit2D DownRayHit;
    RaycastHit2D LeftRayHit;
    RaycastHit2D RightRayHit;
    LayerMask layerMask;
    [SerializeField] GameObject BoomDamage;
    [SerializeField] GameObject BoomEffects;
    public override void Awake()
    {
        base.Awake();
        layerMask = LayerMask.GetMask("Player");
        IsRayAcitve = false;
        BoomDamage.SetActive(false);
        BoomEffects.SetActive(false);
        CurHp = 25f;

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

        if (UpRayHit) // 위쪽에 플레이어 감지
        {
            StopMove();
            moveMent2D.MoveTo(Vector3.up);
            animator.SetTrigger("UpDash");
            moveMent2D.moveSpeed = 7f;
            IsRayAcitve = true;
            isActive = true;
        }
        if (DownRayHit) // 아래쪽 플레이어 감지
        {
            StopMove();
            moveMent2D.MoveTo(Vector3.down);
            animator.SetTrigger("DownDash");
            moveMent2D.moveSpeed = 7f;
            IsRayAcitve = true;
            isActive = true;
        }
        if (LeftRayHit) // 왼쪽 플레이어 감지
        {
            StopMove();
            transform.Rotate(0, 180, 0);
            moveMent2D.MoveTo(Vector3.left);
            animator.SetTrigger("LeftDash");
            moveMent2D.moveSpeed = 7f;
            IsRayAcitve = true;
            isActive = true;
        }
        if (RightRayHit) // 오른쪽 플레이어 감지
        {
            StopMove();
            moveMent2D.MoveTo(Vector3.right);
            animator.SetTrigger("RightDash");
            moveMent2D.moveSpeed = 7f;
            IsRayAcitve = true;
            isActive = true;
        }



    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        
        if (collision.CompareTag("Wall"))  // 벽과 닿았을시 대시를 멈춤
        {
            moveMent2D.MoveTo(Vector3.zero);
            moveMent2D.moveSpeed = 2f;
            animator.SetBool("StopDash", true);
            IsRayAcitve = false;
            isActive = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (collision.CompareTag("PlayerTears")) //플레이어의 눈물과 닿았을시 데미지

        {
            CurHp -= playerStats.Attack;
            if (CurHp <= 0)
            {
                moveMent2D.MoveTo(Vector3.zero);
                StartCoroutine(DeadBoom_co());
            }
        }
        if (collision.CompareTag("BoomDamage")) //폭탄과 닿았을시 데미지
        {
            CurHp -= 5f;
            if (CurHp <= 0)
            {
                moveMent2D.MoveTo(Vector3.zero);
                StartCoroutine(DeadBoom_co());
            }
        }
    }
    public IEnumerator DeadBoom_co() // 죽을때 폭탄데미지,이펙트 생성
    {
        WaitForSeconds wfs = new WaitForSeconds(0.1f);

        
        BoomDamage.SetActive(true);
        BoomEffects.SetActive(true);
        yield return wfs;
        BoomDamage.SetActive(false);
        yield return wfs;
        Destroy(gameObject);
    }
}
