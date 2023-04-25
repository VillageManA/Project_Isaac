using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DukeOffilies : MonoBehaviour
{
    [SerializeField] private GameObject Sucker;
    [SerializeField] private GameObject EnemyTears;
    [SerializeField] private AudioSource Audio;
    [SerializeField] private AudioClip Attack1;
    [SerializeField] private AudioClip Attack2;
    [SerializeField] private AudioClip Attack3;
    [SerializeField] private AudioClip SummonStart;
    [SerializeField] private AudioClip SummonEnd;
    [SerializeField] private AudioSource Main;
    [SerializeField] private AudioClip BossEnd;
    [SerializeField] private AudioClip BaseMent;

    private GameObject Tearsobj;
    private Animator animator;
    private PlayerControl player;
    private Movement2D moveMent2D;
    private PlayerStats playerStats;
    private CameraConfirm camConfirm;


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
    private float curhp;
    public float CurHp
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
    public float maxHp;
    private void Awake()
    {
        wfs = new WaitForSeconds(1f);
        TearDelay = new WaitForSeconds(0.1f);
        isAttack = false;
        summon = new Vector3(0, -0.5f, 0);
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerControl>();
        playerStats = FindObjectOfType<PlayerStats>();
        moveMent2D = GetComponent<Movement2D>();
        camConfirm = FindObjectOfType<CameraConfirm>();
        isMove = false;
        isLeftWall = false;
        isRightWall = false;
        isUpWall = false;
        isDownWall = false;
        LeftUp = new Vector3(-1, 1, 0);
        LeftDown = new Vector3(-1, -1, 0);
        RightUp = new Vector3(1, 1, 0);
        RightDown = new Vector3(1, -1, 0);
        CurHp = 110f;
        maxHp = 110f;
        gameObject.SetActive(false);
        LeftDownMove();

    }

    private void FixedUpdate()
    {

        Movedealy += Time.deltaTime;
        if (isLeftWall)
        {
            RightDownMove();
            ResetBool();

        }
        else if (isRightWall)
        {
            LeftUpMove();
            ResetBool();
        }
        else if (isDownWall)
        {
            RightUpMove();
            ResetBool();
        }
        else if (isUpWall)
        {
            LeftDownMove();
            ResetBool();
        }

        if (isMove || Movedealy < 3f)
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
        animator.SetTrigger("3Attack");
        yield return wfs;
        Audio.PlayOneShot(Attack1);
        Attack();
        yield return wfs;
        Audio.PlayOneShot(Attack2);
        DiagonalAttack();
        yield return wfs;
        Audio.PlayOneShot(Attack3);
        Attack();
        yield return wfs;
        yield return wfs;

        isAttack = false;
    }
    private IEnumerator Summon_co()
    {
        animator.SetTrigger("Summon");
        yield return wfs;
        Audio.PlayOneShot(SummonStart);
        Instantiate(Sucker, transform.position + summon, Quaternion.identity);
        Audio.PlayOneShot(SummonEnd);
        yield return wfs;
        isAttack = false;
    }
    private IEnumerator AttackToplayer_co()
    {
        animator.SetTrigger("Attack");
        Audio.PlayOneShot(Attack3);
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(playerPosition - transform.position);
        Tearsobj.GetComponent<Movement2D>().moveSpeed = 1f;
        yield return TearDelay;
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(playerPosition - transform.position);
        Tearsobj.GetComponent<Movement2D>().moveSpeed = 1f;
        yield return TearDelay;
        Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
        Tearsobj.GetComponent<Movement2D>().MoveTo(playerPosition - transform.position);
        Tearsobj.GetComponent<Movement2D>().moveSpeed = 1f;

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
    public void Dead()
    {
        Main.clip = BaseMent;
        Main.PlayOneShot(BossEnd);
        camConfirm.BossNum = 2;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) //벽과 닿을시 확인해주는 bool값 설정
    {
        if (collision.CompareTag("LeftWall") || collision.CompareTag("Door"))
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

        if (collision.CompareTag("PlayerTears"))
        {
            CurHp -= playerStats.Attack;
            if (curhp == 0)
            {

                Dead();
            }
        }
        if (collision.CompareTag("BoomDamage"))
        {
            CurHp -= 5f;
            if (curhp == 0)
            {

                Dead();
            }

        }
    }

   

}
