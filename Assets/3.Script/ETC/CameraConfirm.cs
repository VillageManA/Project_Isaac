using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConfirm : MonoBehaviour
{
    public int MonsterNum;
    public int BossNum;

    private BoxCollider2D boxCollider;

    private void Awake()
    {
        BossNum = 0;
        TryGetComponent(out boxCollider);
    }

    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);
        if (colliders.Length > 0)
        {
            MonsterNum = 2;
            foreach (Collider2D col in colliders)
            {
                if(col.CompareTag("Monster"))
                {
                    MonsterNum = 1;
                    break;
                }
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            BossNum = 1;
        }
    }

}
