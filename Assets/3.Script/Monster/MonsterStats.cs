using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{

    private float curhp;
    public virtual float CurHp
    {
        get { return curhp; }
        set
        {
            curhp = value;
            if (curhp < 0)
            {
                curhp = 0;
            }

        }
    }

    private float speed;
    public virtual float Speed
    {
        get { return speed; }
        set
        {
            speed = value;
        }
    }

    protected bool isActive;
    protected bool isMove;
    protected int move;
    protected Animator animator;
    protected Movement2D moveMent2D;
    protected PlayerStats playerStats;
    protected float Delay; //방향바꾸는 최소딜레이시간
    protected bool isLeftWall;
    protected bool isRightWall;
    protected bool isUpWall;
    protected bool isDownWall;
    public virtual void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        moveMent2D = GetComponent<Movement2D>();
        animator = GetComponent<Animator>();
        speed = 2;
        isActive = false;
        Delay = 1f;
    }
    public virtual void LateUpdate()
    {
        if (isActive || isMove) //다른행동을 하지않을때 움직이기위함 , 움직이고있을때 딜레이를 주기위함
        {
            return;
        }

        if (isLeftWall)  // 왼쪽벽과 닿았을시 오른쪽으로 이동
        {
            RightMove();
            
        }
        else if (isRightWall) // 오른쪽벽과 닿았을시 왼쪽으로 이동
        {
            LeftMove();
            
        }
        else if (isUpWall) // 위쪽벽과 닿을시 아래로이동
        {
            DownMove();
            
        }
        else if (isDownWall) // 아래벽과 닿을시 위로이동
        {
            UpMove();
           
        }
        else
        {
            move = Random.Range(0, 4); //벽에 닿지않았을시 어느 방향으로갈지 랜덤으로 정함
            switch (move)
            {
                case 0:
                    {
                        UpMove();

                    }
                    break;
                case 1:
                    {

                        DownMove();

                    }
                    break;
                case 2:
                    {
                        LeftMove();


                    }
                    break;
                case 3:
                    {
                        RightMove();

                    }
                    break;
            }
        }
        ResetWallBool(); 
        isMove = true;
        Invoke(nameof(MoveDelay), 0.5f); // 0.5초마다  ismove를 false로 바꿔서 움직일수있게함
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) //벽과 닿을시 확인해주는 bool값 설정
    {
        if (collision.CompareTag("LeftWall"))
        {
            isLeftWall = true;
        }
        if (collision.CompareTag("RightWall"))
        {
            isRightWall = true;
        }
        if (collision.CompareTag("UpWall"))
        {
            isUpWall = true;
        }
        if (collision.CompareTag("DownWall"))
        {
            isDownWall = true;            
        }

    }

    public virtual void StopMove() //다음 이동전에 기존의 이동을 멈춤
    {
        animator.SetBool("UpWalk", false);
        animator.SetBool("DownWalk", false);
        animator.SetBool("LeftWalk", false);
        animator.SetBool("RightWalk", false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        moveMent2D.MoveTo(Vector3.zero);
        animator.SetBool("StopDash", false);
    }

    public void MoveDelay() // 방향 전환 딜레이를 주기위한 bool값 설정
    {
        isMove = false;
    }

    public void LeftMove() //왼쪽이동시 오른쪽이동 모션을 로테이트돌려 왼쪽모션처럼
    {
        StopMove();
        animator.SetBool("LeftWalk", true);
        moveMent2D.MoveTo(Vector3.left);
        transform.Rotate(0, 180, 0);
    }
    public void RightMove() //오른쪽이동
    {
        StopMove();
        animator.SetBool("RightWalk", true);
        moveMent2D.MoveTo(Vector3.right);
    }

    public void UpMove() // 위로이동
    {
        StopMove();
        animator.SetBool("UpWalk", true);
        moveMent2D.MoveTo(Vector3.up);
    }
    public void DownMove() //아래로이동
    {
        StopMove();
        animator.SetBool("DownWalk", true);
        moveMent2D.MoveTo(Vector3.down);
    }
    public void ResetWallBool() // 한번 이동이 끝나면 벽에닿았는지 확인하는 bool값을 리셋
    {
        isUpWall = false;
        isDownWall = false;
        isLeftWall = false;
        isRightWall = false;
    }
    /*
     
     BoomFly
     Hp = 8;
     대각선 이동 벽에닿으면 방향전환
     처치시에 폭발

     Sucker
     Hp = 10;
     플레이어 추적
     처치시 + 자 모양 공격

     Hopper
     Hp = 10;
     점프하면서 이동 , 바위나 지형 넘어다닐수잇음 플레이어인식시 플레이어에 점프
     착지시 + 자 모양 공격
     
     Charger
     Hp = 20;
     +자모양에 플레이어 인식시 돌진, 벽or 장애물에 부딪히면 멈춤
     
     KamikazeLeech 
     Hp = 25;
     상하좌우 방향으로 이동, 플레이어가 +자 안에 인식시 돌진
     사망시 터짐 ,접근데미지 1

     Host
     Hp=14;
     머리가닫혀있을때 공격x 
     플레이어가 주변범위에 들어가면 공격 / 이때 공격가능(콜라이더생성)
     폭탄에 데미지입었을시 찌그러짐 

     StoneHead
     Hp=20; (무적)
     앞으로 계속 눈물발사
     맵에 몬스터가 없을시 문닫음 비활성화
     
     Keeper
     Hp = 36;
     뛰어다니다가 (난 걸어다니게할거임) 플레이어 인식시 2갈래 방향 공격
     키퍼의 공격을 받을시 돈이 떨어짐 
     
     Floating Knight
     Hp = 20;
     날아다님 상하좌우이동 뒤통수만 콜라이더

     Monstro
     Hp=250;
     아이작의 방향으로 랜덤눈물 발사 (분출형)
     작은점프로 아이작에게 다가감
     큰점프로 아이작의 현재위치에 강하, 강하시 주변에 눈물공격
     */
}
