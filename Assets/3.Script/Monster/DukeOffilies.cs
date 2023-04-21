using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeOffilies : MonoBehaviour
{
    [SerializeField] private GameObject Sucker;
    [SerializeField] private GameObject EnemyTears;
    private GameObject Tearsobj;
    private Animator animator;
    private PlayerControl player;
    private Movement2D moveMent2D;

    private WaitForSeconds wfs;
    private WaitForSeconds TearDelay;
    private Vector3 playerPosition;
    private Vector3 summon;

    private Vector3 LeftUp;
    private Vector3 LeftDown;
    private Vector3 RightUp;
    private Vector3 RightDown;
    private bool isAttack;
    private bool isMove;
    private int randomAttack;
    private int randomMove;
    private bool isLeftWall;
    private bool isRightWall;
    private bool isUpWall;
    private bool isDownWall;
    private float Movedealy;
    private void Awake()
    {
        wfs = new WaitForSeconds(1f);
        TearDelay = new WaitForSeconds(0.1f);
        isAttack = false;
        summon = new Vector3(0, -0.5f, 0);
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerControl>();
        moveMent2D = GetComponent<Movement2D>();
        isMove = false;
        isLeftWall = false;
        isRightWall = false;
        isUpWall = false;
        isDownWall = false;
        LeftUp = new Vector3(-1, 1, 0);
        LeftDown = new Vector3(-1, -1, 0);
        RightUp = new Vector3(1, 1, 0);
        RightDown = new Vector3(1, -1, 0);
    }

    private void FixedUpdate()
    {
        
        Movedealy += Time.deltaTime;
        if (isLeftWall)
        {
            randomMove = Random.Range(0, 1);
            switch (randomMove)
            {
                case 0:
                    {
                        RightUpMove();
                        ResetBool();
                    }
                    break;
                case 1:
                    {
                        RightDownMove();
                        ResetBool();
                    }
                    break;
            }
            
        }
        else if (isRightWall)
        {
            randomMove = Random.Range(0, 1);
            switch (randomMove)
            {
                case 0:
                    {
                        LeftUpMove();
                        ResetBool();
                    }
                    break;
                case 1:
                    {
                        LeftDownMove();
                        ResetBool();
                    }
                    break;
            }
        }
        else if (isDownWall)
        {
            randomMove = Random.Range(0, 1);
            switch (randomMove)
            {
                case 0:
                    {
                        LeftUpMove();
                        ResetBool();
                    }
                    break;
                case 1:
                    {
                        RightUpMove();
                        ResetBool();
                    }
                    break;
            }
        }
        else if (isUpWall)
        {
            randomMove = Random.Range(0, 1);
            switch (randomMove)
            {
                case 0:
                    {
                        LeftDownMove();
                        ResetBool();
                    }
                    break;
                case 1:
                    {
                        RightDownMove();
                        ResetBool();
                    }
                    break;
            }
        }

        if (isMove || Movedealy<3f)
        {
            return;
        }
        else
        {
            randomMove = Random.Range(0, 3);
            switch (randomMove)
            {
                case 0:
                    {
                        LeftUpMove();
                    }
                    break;
                case 1:
                    {
                        LeftDownMove();
                    }
                    break;
                case 2:
                    {
                        RightUpMove();
                    }
                    break;
                case 3:
                    {
                        RightDownMove();
                    }
                    break;
            }
        }
        ResetBool();
        Movedealy = 0;
    }
    private void Update()
    {
        if (isAttack)
        {
            return;
        }

        randomAttack = Random.Range(0, 3);
        {
            switch (randomAttack)
            {
                case 0:
                    {
                        playerPosition = player.transform.position;
                        isAttack = true;
                        StartCoroutine(AttackToplayer_co());
                    }
                    break;
                case 1:
                    {
                        isAttack = true;
                        StartCoroutine(Attack_co());
                    }
                    break;
                case 2:
                    {
                        isAttack = true;
                        StartCoroutine(Summon_co());
                    }
                    break;
            }
        }
    }
    private void Attack()
    {
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.up);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.down);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.left);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.right);
    }
    private void DiagonalAttack()
    {
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(LeftUp);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(LeftDown);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(RightUp);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(RightDown);
    }
    private IEnumerator Attack_co()
    {
        Debug.Log("알아서쏨");
        Attack();
        yield return wfs;
        DiagonalAttack();
        yield return wfs;
        Attack();
        yield return wfs;
        isAttack = false;
    }
    private IEnumerator Summon_co()
    {
        Debug.Log("소환함");
        //animator.SetTrigger("Summon");
        Instantiate(Sucker, transform.position + summon, Quaternion.identity);
        yield return wfs;
        isAttack = false;
    }
    private IEnumerator AttackToplayer_co()
    {
        Debug.Log("눈물쏨");
        Debug.Log(playerPosition);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(playerPosition - transform.position);
        Tearsobj.GetComponent<Movement2D>().moveSpeed = 2f;
        yield return TearDelay;
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(playerPosition - transform.position);
        Tearsobj.GetComponent<Movement2D>().moveSpeed = 2f;
        yield return TearDelay;
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(playerPosition - transform.position);
        Tearsobj.GetComponent<Movement2D>().moveSpeed = 2f;

        yield return wfs;

        isAttack = false;
    }

    public void ResetBool()
    {
        isUpWall = false;
        isDownWall = false;
        isLeftWall = false;
        isRightWall = false;
    }
    public void LeftUpMove()
    {
        moveMent2D.MoveTo(LeftUp);
    }
    public void LeftDownMove()
    {
        moveMent2D.MoveTo(LeftDown);

    }
    public void RightUpMove()
    {
        moveMent2D.MoveTo(RightUp);
    }
    public void RightDownMove()
    {
        moveMent2D.MoveTo(RightDown);
    }
    private void OnTriggerEnter2D(Collider2D collision) //벽과 닿을시 확인해주는 bool값 설정
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

}
