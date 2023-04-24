using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // [SerializeField] private Animator animator;
    [SerializeField] private PlayerBodyControl playerBody;
    [SerializeField] private PlayerHeadControl playerHead;
    [SerializeField] private GameObject PlayerTears;
    [SerializeField] private GameObject PlayerPierceTears;
    [SerializeField] private GameObject PlayerBooms;
    [SerializeField] private CameraManager Camera;
    [SerializeField] private GameObject DeadUI;
    
    private PlayerStats playerStats;
    private HealthUI healthUI;

    private WaitForSeconds ColorDelay;
    private float clipLength;
    private Color opaque;
    private Color transparent;


    void Awake()
    {
        TryGetComponent(out playerStats);
        healthUI = FindObjectOfType<HealthUI>();
        //�ִϸ��̼��� ���̸� �������� ����
        Animator playerBodyAnimator = playerBody.GetComponent<Animator>();
        AnimationClip clip = playerBodyAnimator.GetCurrentAnimatorClipInfo(0)[0].clip;
        clipLength = clip.length;
        ColorDelay = new WaitForSeconds(0.08f);
        transparent = new Color(1, 1, 1, 0);
        opaque = new Color(1, 1, 1, 1);
        DeadUI.SetActive(false);

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoomDamage"))  // ��ź�� ������� ������
        {
            StartCoroutine(TakeDamage_co(1f));
        }

        if (collision.CompareTag("Monster")) // ���Ϳ� �ǰݽ�
        {
            StartCoroutine(TakeDamage_co(0.5f));
        }
        if (collision.CompareTag("Boss")) // ������ �ǰݽ�
        {
            StartCoroutine(TakeDamage_co(0.5f));
        }
        if (collision.CompareTag("EnemyTears")) //������ ������ �ǰݽ�
        {
            StartCoroutine(TakeDamage_co(0.5f));
        }

        if (collision.CompareTag("UpDoor"))  //���̵�
        {
            Camera.CameraUpPosition();
        }
        if (collision.CompareTag("DownDoor"))
        {
            Camera.CameraDownPosition();
        }
        if (collision.CompareTag("LeftDoor"))
        {
            Camera.CameraLeftPosition();
        }
        if (collision.CompareTag("RightDoor"))
        {
            Camera.CameraRightPosition();
        }
    }
    public void TryAttack() //���ݸ޼���
    {
        Instantiate(PlayerTears, transform.position, Quaternion.identity);
    }

    public IEnumerator TryAttack_co(Vector3 dir, int x, int y, int z) //����Ű�� �Է��� ���ݽ� �ڷ�ƾ
    {
        while (true)
        {
            GameObject obj;
            if (playerStats.Pierce == 1)
            {
                obj = Instantiate(PlayerPierceTears, transform.position, Quaternion.identity);
                obj.transform.Rotate(x, y, z);
            }
            else
            {
                obj = Instantiate(PlayerTears, transform.position, Quaternion.identity);
            }
            obj.GetComponent<Movement2D>().MoveTo(dir);
            yield return new WaitForSeconds(0.8f - playerStats.AttackSpeed);
        }
    }

    public IEnumerator TryBoom_co() // EŰ�� ���� ��ź�� ����
    {
        playerStats.Boom--;
        Instantiate(PlayerBooms, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator TakeDamage_co(float Damage)  // �������� �Ծ����� �ǰݾִϸ��̼ǰ� ü�������ϴ� �ڷ�ƾ
    {
        GetComponent<CircleCollider2D>().enabled = false; //�ǰݽ� ����
        if (playerStats.SoulHp > 0f)
        {
            playerStats.SoulHp -= Damage;
        }
        else
        {
            playerStats.curHp -= Damage;
            if (playerStats.curHp < 0)
            {
                playerStats.curHp = 0;
            }
        }
        healthUI.UpdateHeart();
        playerBody.gameObject.SetActive(false);

        if (playerStats.curHp == 0)
        {
            playerHead.animator.SetTrigger("Dead");
            yield return new WaitForSeconds(2f);
            DeadUI.SetActive(true);
        }

        playerHead.animator.SetTrigger("Hit");
        yield return new WaitForSeconds(clipLength + 0.4f);
        playerBody.gameObject.SetActive(true);
        playerHead.animator.SetBool("Hit", false);
        playerHead.GetComponent<SpriteRenderer>().color = opaque; //�ǰݽ� �����ð����� �ɸ��� ��½��
        playerBody.GetComponent<SpriteRenderer>().color = opaque;
        yield return ColorDelay;
        playerHead.GetComponent<SpriteRenderer>().color = transparent;
        playerBody.GetComponent<SpriteRenderer>().color = transparent;
        yield return ColorDelay;
        playerHead.GetComponent<SpriteRenderer>().color = opaque;
        playerBody.GetComponent<SpriteRenderer>().color = opaque;
        yield return ColorDelay;
        playerHead.GetComponent<SpriteRenderer>().color = transparent;
        playerBody.GetComponent<SpriteRenderer>().color = transparent;
        yield return ColorDelay;
        playerHead.GetComponent<SpriteRenderer>().color = opaque;
        playerBody.GetComponent<SpriteRenderer>().color = opaque;
        yield return ColorDelay;
        playerHead.GetComponent<SpriteRenderer>().color = transparent;
        playerBody.GetComponent<SpriteRenderer>().color = transparent;
        yield return ColorDelay;
        playerHead.GetComponent<SpriteRenderer>().color = opaque;
        playerBody.GetComponent<SpriteRenderer>().color = opaque;



        GetComponent<CircleCollider2D>().enabled = true; //����Ǯ��

    }

    public IEnumerator GetItem_co()  // �������� �Ծ����� �ǰݾִϸ��̼ǰ� ü�������ϴ� �ڷ�ƾ
    {



        playerBody.gameObject.SetActive(false);
        playerHead.animator.SetTrigger("GetItem");
        yield return new WaitForSeconds(clipLength + 0.4f);
        playerBody.gameObject.SetActive(true);
        playerHead.animator.SetBool("GetItem", false);


    }

}
