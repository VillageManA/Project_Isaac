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
    private PlayerStats playerStats;
 

    private float clipLength;

    void Start()
    {

        //애니메이션의 길이를 가져오기 위함
        Animator playerBodyAnimator = playerBody.GetComponent<Animator>();
        AnimationClip clip = playerBodyAnimator.GetCurrentAnimatorClipInfo(0)[0].clip;
        clipLength = clip.length;


    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoomDamage"))  // 폭탄에 닿았을시 데미지
        {

            StartCoroutine(TakeDamage_co());

        }
    }
    public void TryAttack() //공격메서드
    {
        Instantiate(PlayerTears, transform.position, Quaternion.identity);
    }

    public IEnumerator TryAttack_co(Vector3 dir, float delay) //방향키를 입력한 공격시 코루틴
    {
        while (true)
        {
            GameObject obj = Instantiate(PlayerTears, transform.position, Quaternion.identity);
            obj.GetComponent<Movement2D>().MoveTo(dir);
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator TryBoom_co() // E키를 눌러 폭탄을 생성
    {
        playerStats.Boom--;
        Instantiate(PlayerBooms, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
    }

    public IEnumerator TakeDamage_co()  // 데미지를 입었을시 피격애니메이션과 체력조정하는 코루틴
    {

        playerBody.gameObject.SetActive(false);
        playerHead.animator.SetTrigger("Hit");
        playerStats.curHp -= 1f;
        //yield return new WaitForSeconds(0.3f);
        yield return new WaitForSeconds(clipLength + 0.25f);
        //yield return new WaitForSeconds(0.25f);
        playerBody.gameObject.SetActive(true);
        playerHead.animator.SetBool("Hit", false);

    }
}
