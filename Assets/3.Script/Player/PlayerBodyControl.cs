using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyControl : MonoBehaviour
{
    [SerializeField] private Animator animator;


    void Update()
    {
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
