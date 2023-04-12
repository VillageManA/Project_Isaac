using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        
    }
    public void MoveTo(Vector3 direciton)
    {
        moveDirection = direciton;

    }
}
