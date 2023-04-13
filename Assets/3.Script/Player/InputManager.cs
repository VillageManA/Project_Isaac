using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };

    [SerializeField] private GameObject player;
    private PlayerControl playerControl;
    [SerializeField] private GameObject PlayerBullet;
    private Movement2D moveMent2D;
    Vector3 moveUp = new Vector3(0, 1, 0);
    Vector3 moveDown = new Vector3(0, -1, 0);
    Vector3 moveLeft = new Vector3(-1, 0, 0);
    Vector3 moveRight = new Vector3(1, 0, 0);
    private bool isEKeyPressed = false;
    private bool attackFlg = false;

    private IEnumerator[] coroutine = new IEnumerator[4];
    private void Awake()
    {
        TryGetComponent(out playerControl);
        /*        this.moveUp = moveUp;
                this.moveDown = moveDown;
                this.moveLeft = moveLeft;
                this.moveRight = moveRight;*/
        coroutine[0] = playerControl.TryAttack_co(moveUp, 0.2f);
        coroutine[1] = playerControl.TryAttack_co(moveDown, 0.2f);
        coroutine[2] = playerControl.TryAttack_co(moveLeft, 0.2f);
        coroutine[3] = playerControl.TryAttack_co(moveRight, 0.2f);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + playerControl.speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - playerControl.speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position = new Vector2(player.transform.position.x - playerControl.speed, player.transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position = new Vector2(player.transform.position.x + playerControl.speed, player.transform.position.y);
        }
        if (Input.GetKey(KeyCode.E)&& !isEKeyPressed)
        {
            if (playerControl.Boom > 0)
            {
                StartCoroutine(TryBoomDelay_co());
                StartCoroutine(playerControl.TryBoom_co());
            }
            //폭탄
        }
        /*
        if (Input.GetKey(KeyCode.R))
        {
            //리셋(시간나면함)
        }
        */
        if (Input.GetKey(KeyCode.UpArrow) && attackFlg == false)
        {
            attackFlg = true;
            playerControl.StartCoroutine(coroutine[0]);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && attackFlg == false)
        {
            attackFlg = true;
            playerControl.StartCoroutine(coroutine[1]);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && attackFlg == false)
        {
            attackFlg = true;
            playerControl.StartCoroutine(coroutine[2]);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && attackFlg == false)
        {
            attackFlg = true;
            playerControl.StartCoroutine(coroutine[3]);
        }


        //-----------------------------------//

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            StopAtt();
            
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopAtt();
         
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StopAtt();
            
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StopAtt();
          
        }



    }

    public void StopAtt()
    {
        playerControl.StopCoroutine(coroutine[0]);
        playerControl.StopCoroutine(coroutine[1]);
        playerControl.StopCoroutine(coroutine[2]);
        playerControl.StopCoroutine(coroutine[3]);
        attackFlg = false;
    }

    IEnumerator TryBoomDelay_co()
    {
        isEKeyPressed = true;

        // E 키를 누를 수 없는 시간 
        float delayTime = 3.0f;

        // 5초간 기다린 후에 E 키를 다시 누를 수 있도록 상태를 false로 변경
        yield return new WaitForSeconds(delayTime);
        isEKeyPressed = false;

    }
}
