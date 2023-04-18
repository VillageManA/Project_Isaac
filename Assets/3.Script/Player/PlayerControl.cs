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
    private PlayerStats playerStats;
    private HealthUI healthUI;


    private float clipLength;

    void Start()
    {
        TryGetComponent(out playerStats);
        healthUI = FindObjectOfType<HealthUI>();
        //�ִϸ��̼��� ���̸� �������� ����
        Animator playerBodyAnimator = playerBody.GetComponent<Animator>();
        AnimationClip clip = playerBodyAnimator.GetCurrentAnimatorClipInfo(0)[0].clip;
        clipLength = clip.length;


    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoomDamage"))  // ��ź�� ������� ������
        {

            StartCoroutine(TakeDamage_co(1f));

        }


        if (collision.CompareTag("UpDoor"))
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

    public IEnumerator TryAttack_co(Vector3 dir, float delay, int x, int y, int z) //����Ű�� �Է��� ���ݽ� �ڷ�ƾ
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
            yield return new WaitForSeconds(delay);
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
        if (playerStats.SoulHp > 0f)
        {
            playerStats.SoulHp -= Damage; //1f�� �������� �ٲܿ���
        }
        else
        {
            playerStats.curHp -= Damage;
            if (playerStats.curHp<0)
            {
                playerStats.curHp = 0;
            }
        }
        playerBody.gameObject.SetActive(false);
        playerHead.animator.SetTrigger("Hit");
        yield return new WaitForSeconds(clipLength + 0.4f);
        playerBody.gameObject.SetActive(true);
        playerHead.animator.SetBool("Hit", false);
        healthUI.UpdateHeart();

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
