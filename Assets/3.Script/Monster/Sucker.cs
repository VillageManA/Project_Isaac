using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sucker : MonoBehaviour
{
    [SerializeField] private GameObject EnemyTears;
    private GameObject Tearsobj;
    private float curhp;
    private PlayerStats playerStats;
    private PlayerControl player;
    private AudioSource Audio;
    [SerializeField] private AudioClip Dead;

    private float DistanceObjectX;
    private float DistanceObjectY;

    public float CurHp
    {
        get { return curhp; }
        set
        {
            curhp = value;
            if (curhp < 0)
            {
                curhp = 0;
            }
        }
    }
    public void Awake()
    {
        CurHp = 10;
        playerStats = FindObjectOfType<PlayerStats>();
        player = FindObjectOfType<PlayerControl>();
        TryGetComponent(out Audio);
    }

    private void Update()
    {
       
        //플레이어의 위치를 추적해서 따라감
        DistanceObjectX = transform.position.x - player.transform.position.x;
        DistanceObjectY = transform.position.y - player.transform.position.y;

        DistanceObjectX = (DistanceObjectX > 0) ? -1 : 1;
        DistanceObjectY = (DistanceObjectY > 0) ? -1 : 1;


        transform.position += new Vector3(DistanceObjectX, DistanceObjectY, 0) * 2f * Time.deltaTime;



    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerTears")) // 플레이어의 눈물이 닿았을시
        {
            CurHp -= playerStats.Attack;
            if (CurHp <= 0) //죽을때 + 방향으로 눈물발사
            {
                Audio.PlayOneShot(Dead);
                Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
                Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.up);
                Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
                Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.down);
                Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
                Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.left);
                Tearsobj = Instantiate(EnemyTears, transform.position, Quaternion.identity);
                Tearsobj.GetComponent<Movement2D>().MoveTo(Vector3.right);
                Destroy(gameObject);
            }
        }

    }

}
