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

    private float maxhp;
    public virtual float MaxHp
    {
        get { return maxhp; }
        set
        {
            maxhp = value;
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
    protected float Delay; //����ٲٴ� �ּҵ����̽ð�
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
        if (isActive || isMove) //�ٸ��ൿ�� ���������� �����̱����� , �����̰������� �����̸� �ֱ�����
        {
            return;
        }

        if (isLeftWall) 
        {
            RightMove();
            
        }
        else if (isRightWall)
        {
            LeftMove();
            
        }
        else if (isUpWall)
        {
            DownMove();
            
        }
        else if (isDownWall)
        {
            UpMove();
           
        }
        else
        {
            move = Random.Range(0, 4); //���� �����ʾ����� ��� �������ΰ��� �������� ����
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
        Invoke(nameof(MoveDelay), 0.5f); // 0.5�ʸ���  ismove�� false�� �ٲ㼭 �����ϼ��ְ���
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftWall"))
        {
            isLeftWall = true;
            Debug.Log(isLeftWall);
        }
        if (collision.CompareTag("RightWall"))
        {
            isRightWall = true;
            Debug.Log(isRightWall);
        }
        if (collision.CompareTag("UpWall"))
        {
            isUpWall = true;
            Debug.Log(isUpWall);
        }
        if (collision.CompareTag("DownWall"))
        {
            isDownWall = true;
            Debug.Log(isDownWall);
        }

    }

    public virtual void StopMove()
    {
        animator.SetBool("UpWalk", false);
        animator.SetBool("DownWalk", false);
        animator.SetBool("LeftWalk", false);
        animator.SetBool("RightWalk", false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        moveMent2D.MoveTo(Vector3.zero);
        animator.SetBool("StopDash", false);
    }

    public void MoveDelay()
    {
        isMove = false;
    }

    public void LeftMove()
    {
        StopMove();
        animator.SetBool("LeftWalk", true);
        moveMent2D.MoveTo(Vector3.left);
        transform.Rotate(0, 180, 0);
    }
    public void RightMove()
    {
        StopMove();
        animator.SetBool("RightWalk", true);
        moveMent2D.MoveTo(Vector3.right);
    }

    public void UpMove()
    {
        StopMove();
        animator.SetBool("UpWalk", true);
        moveMent2D.MoveTo(Vector3.up);
    }
    public void DownMove()
    {
        StopMove();
        animator.SetBool("DownWalk", true);
        moveMent2D.MoveTo(Vector3.down);
    }
    public void ResetWallBool()
    {
        isUpWall = false;
        isDownWall = false;
        isLeftWall = false;
        isRightWall = false;
    }
    /*
     
     BoomFly
     Hp = 8;
     �밢�� �̵� ���������� ������ȯ
     óġ�ÿ� ����

     Sucker
     Hp = 10;
     �÷��̾� ����
     óġ�� + �� ��� ����

     Hopper
     Hp = 10;
     �����ϸ鼭 �̵� , ������ ���� �Ѿ�ٴҼ����� �÷��̾��νĽ� �÷��̾ ����
     ������ + �� ��� ����
     
     Charger
     Hp = 20;
     +�ڸ�翡 �÷��̾� �νĽ� ����, ��or ��ֹ��� �ε����� ����
     
     KamikazeLeech 
     Hp = 25;
     �����¿� �������� �̵�, �÷��̾ +�� �ȿ� �νĽ� ����
     ����� ���� ,���ٵ����� 1

     Host
     Hp=14;
     �Ӹ������������� ����x 
     �÷��̾ �ֺ������� ���� ���� / �̶� ���ݰ���(�ݶ��̴�����)
     ��ź�� �������Ծ����� ��׷��� 

     StoneHead
     Hp=20; (����)
     ������ ��� �����߻�
     �ʿ� ���Ͱ� ������ ������ ��Ȱ��ȭ
     
     Keeper
     Hp = 36;
     �پ�ٴϴٰ� (�� �ɾ�ٴϰ��Ұ���) �÷��̾� �νĽ� 2���� ���� ����
     Ű���� ������ ������ ���� ������ 
     
     Floating Knight
     Hp = 20;
     ���ƴٴ� �����¿��̵� ������� �ݶ��̴�

     Monstro
     Hp=250;
     �������� �������� �������� �߻� (������)
     ���������� �����ۿ��� �ٰ���
     ū������ �������� ������ġ�� ����, ���Ͻ� �ֺ��� ��������
     */
}
