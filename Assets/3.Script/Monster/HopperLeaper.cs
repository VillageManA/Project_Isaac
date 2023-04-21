using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HopperLeaper : MonsterStats
{
    private float Distance;
    private float DistanceObjectX;
    private float DistanceObjectY;
    private PlayerControl player;
    private Vector3 playerPosition;
    private bool isCo;
    public override void Awake()
    {
        base.Awake();
        CurHp = 10;
        moveMent2D.moveSpeed = 2f;
        Speed = 4f;
        player = FindObjectOfType<PlayerControl>();
        isCo = false;
    }
    private void Update()
    {
        Distance = Vector3.Distance(transform.position, player.transform.position);
        if (isActive) // 다중행동 방지
        {
            return;
        }

        if (Distance <= 4 && !isCo) //플레이어와 거리가 가까워지면 위치를 기억후 그방향으로 움직이는 코루틴 실행
        {
            playerPosition = player.transform.position;
            isActive = true;
            isCo = true;
            StopCoroutine(Move_co());
            StartCoroutine(Move_co());
        }
        else if (Distance > 4 && isCo) // 플레이어와 거리가멀면 기존의 상속받는 움직임을행동
        {
            isActive = false;
            isCo = false;
            StopCoroutine(Move_co());
        }
    }

    public IEnumerator Move_co() //플레이어의 위치로 움직이는 코루틴
    {


        while(isCo)
        {
            Distance = Vector3.Distance(transform.position, playerPosition);
            if (Distance<=0.5f)
            {
                isCo = false;
            }
            else
            {
                transform.position += Vector3.MoveTowards(transform.position, playerPosition , Speed*Time.deltaTime);
                yield return null;
            }
        }
        isActive = false;

        yield return new WaitForSeconds(3f);
        //DistanceObjectX = transform.position.x - playerPosition.x;
        //DistanceObjectY = transform.position.y - playerPosition.y;

        //DistanceObjectX = (DistanceObjectX > 0) ? -1 : 1;
        //DistanceObjectY = (DistanceObjectY > 0) ? -1 : 1;

        //while (Vector3.Distance(transform.position, playerPosition) > 0.5f)
        //{

        //    transform.position += new Vector3(DistanceObjectX, DistanceObjectY, 0) * Speed * Time.deltaTime;

        //}
        //yield return null;
        //Distance = Vector3.Distance(transform.position, player.transform.position);
        //isActive = false;

    }

    public override void StopMove() //StopDash가 없어서 오버라이드로 덮어씌움
    {
        animator.SetBool("UpWalk", false);
        animator.SetBool("DownWalk", false);
        animator.SetBool("LeftWalk", false);
        animator.SetBool("RightWalk", false);
        moveMent2D.MoveTo(Vector3.zero);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag("PlayerTears")) // 플레이어의 눈물에 닿았을시 데미지
        {
            CurHp -= playerStats.Attack;
            if (CurHp <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("BoomDamage")) //폭탄과 닿았을시 데미지
        {
            CurHp -= 5f;
            if (CurHp <= 0)
            {
                Destroy(gameObject); 
            }
        }

    }
}
