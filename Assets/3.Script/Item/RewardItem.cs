using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardItem : MonoBehaviour
{
    private float randomItem;
    private CameraConfirm camConfirm;

    [SerializeField] private GameObject MagicMushRoom;
    [SerializeField] private GameObject SadOnion;
    [SerializeField] private GameObject WireCoatHanger;
    [SerializeField] private GameObject MiniMush;
    [SerializeField] private GameObject MoneyEqualPower;
    [SerializeField] private GameObject Sqeezuy;
    [SerializeField] private GameObject ToothPicks;
    [SerializeField] private GameObject Pyro;
    [SerializeField] private GameObject Empty;

    private Vector3 emptyVector;
  

    private void Awake()
    {
        camConfirm = FindObjectOfType<CameraConfirm>();
        emptyVector = new Vector3(transform.position.x, transform.position.y - 1.32f);
    }

    private void Update()
    {
        if (camConfirm.BossNum != 2)
        {
            return;
        }
        else
        {
            ItemCreate();
            camConfirm.BossNum = 3;
        }

    }


    public void ItemCreate()
    {
        randomItem = Random.Range(0, 8);

        switch (randomItem)
        {
            case 0:
                {
                    Instantiate(MagicMushRoom, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;
            case 1:
                {
                    Instantiate(SadOnion, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;
            case 2:
                {
                    Instantiate(WireCoatHanger, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;
            case 3:
                {
                    Instantiate(MiniMush, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;
            case 4:
                {
                    Instantiate(MoneyEqualPower, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;
            case 5:
                {
                    Instantiate(Sqeezuy, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;
            case 6:
                {
                    Instantiate(ToothPicks, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;
            case 7:
                {
                    Instantiate(Pyro, transform.position, Quaternion.identity);
                    Instantiate(Empty, emptyVector, Quaternion.identity);
                }
                break;

        }
    }

}
