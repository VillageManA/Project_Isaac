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
        if (isActive) // �����ൿ ����
        {
            return;
        }

        if (Distance <= 4 && !isCo) //�÷��̾�� �Ÿ��� ��������� ��ġ�� ����� �׹������� �����̴� �ڷ�ƾ ����
        {
            playerPosition = player.transform.position;
            isActive = true;
            isCo = true;
            StopCoroutine(Move_co());
            StartCoroutine(Move_co());
        }
        else if (Distance > 4 && isCo) // �÷��̾�� �Ÿ����ָ� ������ ��ӹ޴� ���������ൿ
        {
            isActive = false;
            isCo = false;
            StopCoroutine(Move_co());
        }
    }

    public IEnumerator Move_co() //�÷��̾��� ��ġ�� �����̴� �ڷ�ƾ
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

    public override void StopMove() //StopDash�� ��� �������̵�� �����
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
        if (collision.CompareTag("PlayerTears")) // �÷��̾��� ������ ������� ������
        {
            CurHp -= playerStats.Attack;
            if (CurHp <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("BoomDamage")) //��ź�� ������� ������
        {
            CurHp -= 5f;
            if (CurHp <= 0)
            {
                Destroy(gameObject); 
            }
        }

    }
}
