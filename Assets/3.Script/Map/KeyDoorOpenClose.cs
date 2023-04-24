using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoorOpenClose : MonoBehaviour
{
    private CameraConfirm camConfirm;

    [SerializeField] private GameObject OpenDoor;
    [SerializeField] private GameObject CloseDoor;
    private PlayerStats playerStats;
    private bool isOpenDoor;
    private void Awake()
    {
        camConfirm = FindObjectOfType<CameraConfirm>();
        playerStats = FindObjectOfType<PlayerStats>();
        isOpenDoor = false;
    }
    private void Update()
    {
        if(camConfirm.MonsterNum!=2)
        {
            return;
        }
        if (camConfirm.MonsterNum == 2 && isOpenDoor)
        {
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.CompareTag("Player") && playerStats.Key>0 && !isOpenDoor)
        {
            playerStats.Key -= 1;
            isOpenDoor = true;
        }
    }
}
