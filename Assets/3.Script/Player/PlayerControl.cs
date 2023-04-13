using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // [SerializeField] private Animator animator;
    [SerializeField] private PlayerBodyControl playerBody;
    [SerializeField] private PlayerHeadControl playerHead;
    [SerializeField] private GameObject PlayerTears;
    [SerializeField] private GameObject PlayerBooms;
    public float speed;
    public float Attack;
    public float MaxHp;
    public float curHp;
    //public float attackSpeed;
    public float range;
    public int Money;
    public int Boom;
    public int Key;

    private bool isDamaged = false;

    /*
     시간되면 만들것
    private float Luck;
    private float ShootSpeed;
    private float AcitveGage;
     */

    // Start is called before the first frame update
    void Start()
    {
/*        TryGetComponent(out animator);
        TryGetComponent(out playerBody);
        TryGetComponent(out playerHead);*/

        speed = 0.02f;
        Attack = 0f;
        MaxHp = 3f;
        curHp = 3f;
        range = 4f;
        Money = 0;
        Boom = 50;
        Key = 0;
        //attackSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isDamaged);
        if(isDamaged==true)
        {
            Debug.Log(playerBody.animator);

            playerBody.animator.SetTrigger("Hit");
            playerHead.gameObject.SetActive(false);
            curHp -= 1f;    
            StartCoroutine(EndDamageMotion_co());
            isDamaged = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoomDamage"))
        {
            isDamaged = true;
           
        }
    }
    public void TryAttack()
    {
        Instantiate(PlayerTears, transform.position, Quaternion.identity);
    }

    public IEnumerator TryAttack_co(Vector3 dir, float delay)
    {
        while (true)
        {
            GameObject obj = Instantiate(PlayerTears, transform.position, Quaternion.identity);
            obj.GetComponent<Movement2D>().MoveTo(dir);
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator TryBoom_co()
    {
        Boom--;
        Instantiate(PlayerBooms, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator EndDamageMotion_co()
    {
        yield return new WaitForSeconds(0.4f);
        playerBody.animator.SetBool("Hit", false);
        playerHead.gameObject.SetActive(true);
        
    }
}
