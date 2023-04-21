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
        if (collision.CompareTag("Player"))  //플레이어와 닿았을떄
        {
            StartCoroutine(TearAnimaion());
        }

        if (collision.CompareTag("Wall")) // 벽과 닿았을때
        { 
            StartCoroutine(TearAnimaion());
        }
    }

    public IEnumerator TearAnimaion() // 눈물이 물체와 닿았을시
    {
        animator.SetTrigger("Hit");
        gameObject.GetComponent<CircleCollider2D>().enabled = false; //추가피격 X
        gameObject.GetComponent<Movement2D>().enabled = false;       //눈물이 벽에닿으면 멈추게
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
