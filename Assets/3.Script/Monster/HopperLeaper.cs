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
    public override void Awake()
    {
        base.Awake();
        CurHp = 10;
        moveMent2D.moveSpeed = 2f;
        Speed = 4f;
        player = FindObjectOfType<PlayerControl>();
    }
    private void Update()
    {
        if (Distance > 4)
        {
            Distance = Vector3.Distance(transform.position, player.transform.position);
            playerPosition = player.transform.position;
        }
        else
        {
            StartCoroutine(Move_co());
        }
    }

    public IEnumerator Move_co()
    {
        DistanceObjectX = transform.position.x - playerPosition.x;
        DistanceObjectY = transform.position.y - playerPosition.y;

        DistanceObjectX = (DistanceObjectX > 0) ? -1 : 1;
        DistanceObjectY = (DistanceObjectY > 0) ? -1 : 1;

        transform.position += new Vector3(DistanceObjectX, DistanceObjectY, 0) * Speed * Time.deltaTime;
        yield return new WaitForSeconds(1f);
        Distance = Vector3.Distance(transform.position, player.transform.position);
        isActive = false;

    }

    public override void StopMove()
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
        if ( collision.CompareTag("PlayerTears"))
        {
            CurHp -= playerStats.Attack;
            if(CurHp<=0)
            {
                Destroy(gameObject);
            }
        }

            
            
    }
}
