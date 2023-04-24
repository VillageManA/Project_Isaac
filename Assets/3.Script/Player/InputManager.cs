using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject PlayerPierceTears;
    private PlayerStats playerStats;
    private PlayerControl playerControl;
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
        TryGetComponent(out playerStats);
        TryGetComponent(out playerControl);
        coroutine[0] = playerControl.TryAttack_co(moveUp, 0, 0, 90);
        coroutine[1] = playerControl.TryAttack_co(moveDown, 180, 0, 90);
        coroutine[2] = playerControl.TryAttack_co(moveLeft, 0, 0, 180);
        coroutine[3] = playerControl.TryAttack_co(moveRight, 0, 0, 0);
    }
    void Update()
    {
        // 방향키를 입력하여 움직이는곳
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + playerStats.Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - playerStats.Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.position = new Vector2(player.transform.position.x - playerStats.Speed, player.transform.position.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.position = new Vector2(player.transform.position.x + playerStats.Speed, player.transform.position.y);
        }

        // E키를 눌러 폭탄을 나오게
        if (Input.GetKey(KeyCode.E) && !isEKeyPressed)
        {
            if (playerStats.Boom > 0)
            {
                StartCoroutine(TryBoomDelay_co());
                StartCoroutine(playerControl.TryBoom_co());
            }
        }

        /*
        if (Input.GetKey(KeyCode.R))
        {
            //리셋(시간나면함)
        }
        */

        //방향키를 눌러 눈물이 나오게 공격
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
        //방향키를 뗄시에 공격이 멈추게
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

        if (Input.GetKeyDown(KeyCode.Space) && playerStats.IsDead)
        {
            playerStats.IsDead = false;
            SceneManager.LoadScene("Stage1");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && playerStats.IsDead)
        {
            playerStats.IsDead = false;
            SceneManager.LoadScene("Intro");
        }

    }

    public void StopAtt() //동시에 여러방향 공격을 막는메서드
    {
        playerControl.StopCoroutine(coroutine[0]);
        playerControl.StopCoroutine(coroutine[1]);
        playerControl.StopCoroutine(coroutine[2]);
        playerControl.StopCoroutine(coroutine[3]);
        attackFlg = false;
    }

    IEnumerator TryBoomDelay_co() //폭탄을 한번사용하고 다음 폭탄까지의 대기시간을 주는곳
    {
        isEKeyPressed = true;

        // E 키를 누를 수 없는 시간 
        float delayTime = 3.0f;

        // 5초간 기다린 후에 E 키를 다시 누를 수 있도록 상태를 false로 변경
        yield return new WaitForSeconds(delayTime);
        isEKeyPressed = false;

    }
}
