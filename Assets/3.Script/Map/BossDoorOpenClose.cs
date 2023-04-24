using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDoorOpenClose : MonoBehaviour
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
        if (camConfirm.BossNum == 0)
        {
            return;
        }
        else if (camConfirm.BossNum == 1)
        {
            OpenDoor.SetActive(false);
            CloseDoor.SetActive(true);
        }
        else if (camConfirm.BossNum == 3)
        {

            OpenDoor.SetActive(true);
            CloseDoor.SetActive(false);
        }
    }
}
