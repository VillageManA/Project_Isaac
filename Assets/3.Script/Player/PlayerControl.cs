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
    [SerializeField] private GameObject PlayerBooms;
    private PlayerStats playerStats;
 

    private float clipLength;

    void Start()
    {

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

            StartCoroutine(TakeDamage_co());

        }
    }
    public void TryAttack() //���ݸ޼���
    {
        Instantiate(PlayerTears, transform.position, Quaternion.identity);
    }

    public IEnumerator TryAttack_co(Vector3 dir, float delay) //����Ű�� �Է��� ���ݽ� �ڷ�ƾ
    {
        while (true)
        {
            GameObject obj = Instantiate(PlayerTears, transform.position, Quaternion.identity);
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

    public IEnumerator TakeDamage_co()  // �������� �Ծ����� �ǰݾִϸ��̼ǰ� ü�������ϴ� �ڷ�ƾ
    {

        playerBody.gameObject.SetActive(false);
        playerHead.animator.SetTrigger("Hit");
        playerStats.curHp -= 1f;
        //yield return new WaitForSeconds(0.3f);
        yield return new WaitForSeconds(clipLength + 0.25f);
        //yield return new WaitForSeconds(0.25f);
        playerBody.gameObject.SetActive(true);
        playerHead.animator.SetBool("Hit", false);

    }
}
