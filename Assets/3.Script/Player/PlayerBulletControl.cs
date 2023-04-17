using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletControl : MonoBehaviour
{
    private PlayerStats playerStats;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Enemy"))
        //{
        //    //적의체력 -1;

        //    if(playerStats.Pierce==1)
        //    {

        //    }
        //    else
        //    {
        //        animator.SetBool("Hit", true);
        //        Destroy(gameObject);
        //    }


        //}

        if (collision.CompareTag("Wall"))
        {
            StartCoroutine(TearAnimaion());
        }
    }

    public IEnumerator TearAnimaion()
    {
        animator.SetTrigger("Hit");
        gameObject.GetComponent<CircleCollider2D>().enabled = false; //추가피격 X
        gameObject.GetComponent<Movement2D>().enabled = false;       //눈물이 벽에닿으면 멈추게
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

    }
}
