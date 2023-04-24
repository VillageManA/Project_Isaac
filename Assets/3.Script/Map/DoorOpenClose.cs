using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenClose : MonoBehaviour
{
    private CameraConfirm camConfirm;

    [SerializeField] private GameObject OpenDoor;
    [SerializeField] private GameObject CloseDoor;

    private void Awake()
    {
        camConfirm = FindObjectOfType<CameraConfirm>();
    }
    private void Update()
    {
        if (camConfirm.MonsterNum == 0)
        {
            return;
        }
        else if (camConfirm.MonsterNum == 1)
        {
            OpenDoor.SetActive(false);
            CloseDoor.SetActive(true);
        }
        else if (camConfirm.MonsterNum == 2)
        {
            
            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
        }
    }
}
