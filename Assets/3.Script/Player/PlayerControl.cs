using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerBodyControl playerBody;
    [SerializeField] private PlayerHeadControl playerHead;
    [SerializeField] private GameObject PlayerTears;
    public float speed;
    private float Attack;
    private float MaxHp;
    private float curHp;
    private float attackSpeed;
    private float range;
    /*
     시간되면 만들것
    private float Luck;
    private float ShootSpeed;
    private float AcitveGage;
     */

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out animator);
        TryGetComponent(out playerBody);
        TryGetComponent(out playerHead);

        speed = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void TryAttack()
    {
        Instantiate(PlayerTears, transform.position, Quaternion.identity);
    }

    public IEnumerator TryAttack_co(Vector3 dir)
    {
        while (true)
        {
            GameObject obj = Instantiate(PlayerTears, transform.position, Quaternion.identity);
            obj.GetComponent<Movement2D>().MoveTo(dir);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
