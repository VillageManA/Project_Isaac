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

    private bool attackFlg = false;

    private IEnumerator[] coroutine = new IEnumerator[4];
    private void Awake()
    {
        TryGetComponent(out playerControl);
        /*        this.moveUp = moveUp;
                this.moveDown = moveDown;
                this.moveLeft = moveLeft;
                this.moveRight = moveRight;*/
        coroutine[0] = playerControl.TryAttack_co(moveUp);
        coroutine[1] = playerControl.TryAttack_co(moveDown);
        coroutine[2] = playerControl.TryAttack_co(moveLeft);
        coroutine[3] = playerControl.TryAttack_co(moveRight);
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
        if (Input.GetKey(KeyCode.E))
        {
            //ÆøÅº
        }
        /*
        if (Input.GetKey(KeyCode.R))
        {
            //¸®¼Â(½Ã°£³ª¸éÇÔ)
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
            playerControl.StopCoroutine(coroutine[0]);
            attackFlg = false;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            playerControl.StopCoroutine(coroutine[1]);
            attackFlg = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            playerControl.StopCoroutine(coroutine[2]);
            attackFlg = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerControl.StopCoroutine(coroutine[3]);
            attackFlg = false;
        }



    }
}
