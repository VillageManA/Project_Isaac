using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyControl : MonoBehaviour
{
    [SerializeField] private Animator animator;


    void Update()
    {
        // W,A,S,D 를이용해 방향으로 움직이는 부분
        // 머리방향과 몸방향,몸의 움직임을 담당함
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

        // 에셋이 위쪽과 왼쪽밖에 없어서 로테이트값을 줘서 아래와 오른쪽을 갈땐 에셋을 돌려서 사용
        // 키다운을 떼면 다시 로테이트값을 360도로 원상복귀시켜서 위쪽과 왼쪽을갈때 정상적으로 작동하게 하였음.
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.Rotate(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            gameObject.transform.Rotate(0, 180, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.Rotate(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            gameObject.transform.Rotate(0, 180, 0);
        }


    }
}
