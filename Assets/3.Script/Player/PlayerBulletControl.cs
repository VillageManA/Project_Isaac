using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletControl : MonoBehaviour
{
    private Animator animator;
    private AudioSource Audio;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        TryGetComponent(out Audio);
        Audio.Stop();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster")) //몬스터와 닿았을시
        {
            StartCoroutine(TearAnimaion());
        }

        if (collision.CompareTag("Wall")) //벽과 닿았을시
        {
            StartCoroutine(TearAnimaion());
        }

        if( collision.CompareTag("Boss")) // 보스와 닿았을시
        {
            StartCoroutine(TearAnimaion());
        }
    }

    public IEnumerator TearAnimaion() // 물체와 닿았을시 애니메이션과 눈물삭제
    {
        Audio.Play();
        animator.SetTrigger("Hit");
        gameObject.GetComponent<CircleCollider2D>().enabled = false; //추가피격 X
        gameObject.GetComponent<Movement2D>().enabled = false;       //눈물이 벽에닿으면 멈추게
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
