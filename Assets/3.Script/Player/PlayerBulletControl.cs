using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletControl : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster")) //���Ϳ� �������
        {
            StartCoroutine(TearAnimaion());
        }

        if (collision.CompareTag("Wall")) //���� �������
        {
            StartCoroutine(TearAnimaion());
        }

        if( collision.CompareTag("Boss"))
        {
            StartCoroutine(TearAnimaion());
        }
    }

    public IEnumerator TearAnimaion() // ��ü�� ������� �ִϸ��̼ǰ� ��������
    {
        animator.SetTrigger("Hit");
        gameObject.GetComponent<CircleCollider2D>().enabled = false; //�߰��ǰ� X
        gameObject.GetComponent<Movement2D>().enabled = false;       //������ ���������� ���߰�
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
