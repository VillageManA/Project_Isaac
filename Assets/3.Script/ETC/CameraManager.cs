using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private CameraConfirm camConfirn;
    private void Awake()
    {
        camConfirn = FindObjectOfType<CameraConfirm>();
    }
    public void CameraLeftPosition()
    {
        transform.position += new Vector3(-22, 0, 0);
        player.transform.position += new Vector3(-12.3f, 0, 0);
    }
    public void CameraRightPosition()
    {
        transform.position += new Vector3(22, 0, 0);
        player.transform.position += new Vector3(12.3f, 0, 0);
    }
    public void CameraUpPosition()
    {
        transform.position += new Vector3(0, 22, 0);
        player.transform.position += new Vector3(0, 15.58f, 0);
    }
    public void CameraDownPosition()
    {
        transform.position += new Vector3(0, -22, 0);
        player.transform.position += new Vector3(0, -15.58f, 0);
    }
}
