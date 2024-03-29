using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadControl : MonoBehaviour
{
    [SerializeField] public Animator animator;
    // Update is called once per frame
    void Update()
    {
        // W,A,S,D 를 이용하여 머리의 움직임만 이용할수있는부분
        float MoveX = Input.GetAxisRaw("MoveX");
        float MoveY = Input.GetAxisRaw("MoveY");

        if (MoveX == 0 && MoveY == 0)
        {
            animator.SetBool("Move", false);
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            animator.SetBool("Move", true);
            animator.SetFloat("MoveX", MoveX);
            animator.SetFloat("MoveY", MoveY);
        }

        // 방향키를 사용하여 머리에서 공격이 나갈타이밍에 애니메이션을 나가도록하는부분
        // 추후 딜레이랑 이런건 코루틴을 사용해서 변경예정
        float AttackX = Input.GetAxisRaw("Horizontal");
        float AttackY = Input.GetAxisRaw("Vertical");

        if (AttackX == 0 && AttackY == 0)
        {
            animator.SetBool("Attack", false);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
        }
        else
        {
            animator.SetBool("Attack", true);
            animator.SetFloat("Horizontal", AttackX);
            animator.SetFloat("Vertical", AttackY);
        }
    }
}
