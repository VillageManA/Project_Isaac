using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosterBullet : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))  //�÷��̾�� �������
        {
            StartCoroutine(TearAnimaion());
        }

        if (collision.CompareTag("Wall")) // ���� �������
        { 
            StartCoroutine(TearAnimaion());
        }
    }

    public IEnumerator TearAnimaion() // ������ ��ü�� �������
    {
        animator.SetTrigger("Hit");
        gameObject.GetComponent<CircleCollider2D>().enabled = false; //�߰��ǰ� X
        gameObject.GetComponent<Movement2D>().enabled = false;       //������ ���������� ���߰�
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
