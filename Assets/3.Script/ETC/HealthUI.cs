using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject fullHeartPreFab;
    [SerializeField] private GameObject halfHeartPreFab;
    [SerializeField] private GameObject EmptyHeartPreFab;
    [SerializeField] private GameObject fullSoulHeartPreFab;
    [SerializeField] private GameObject halfSoulHeartPreFab;
    [SerializeField] private Camera mainCamera;
    private Canvas canvas;
    private PlayerStats playerStats;
    private int Fullheart;
    private float remainHeart;
    private float Halfheart;
    private int FullSoulheart;
    private float remainSoulHeart;
    private float HalfSoulheart;
    GameObject[] heart;
    private void Awake()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        canvas = FindObjectOfType<Canvas>();
        heart = GameObject.FindGameObjectsWithTag("HP");
    }
    private void Start()
    {
        UpdateHeart();

    }

    //public void MadeHeart()
    //{

    //}
    //0~11�� 12~23 �� 24~35 Ǯ 36~47 �ݼҿ� 48~59 Ǯ�ҿ�
    public void UpdateHeart()
    {
        ClearHeart();
        //������Ʈ�� ���� ������ ��Ÿ��������
        Fullheart = (int)playerStats.curHp;
        remainHeart = playerStats.curHp - Fullheart;
        Halfheart = remainHeart * 2;
        //�ҿ���Ʈ�� ���������� ��Ÿ��������
        FullSoulheart = (int)playerStats.SoulHp;
        remainSoulHeart = playerStats.SoulHp - FullSoulheart;
        HalfSoulheart = remainSoulHeart * 2;



        //GameObject[] soulheart = new GameObject[(int)playerStats.SoulHp];

        for (int i = Fullheart + (int)Halfheart; i < Mathf.Min(playerStats.MaxHp, heart.Length); i++) //ü���� ���� ����Ʈ�� ä��
        {
            heart[i].SetActive(true);
        }


        for (int i = 0; i < Fullheart + Halfheart; i++) // ����ü�� Ǯ��Ʈ,����Ʈ�� ä��
        {

            if (i < Fullheart && i + 24 < heart.Length)
            {
                heart[i + 24].SetActive(true);
            }

            if (i < Fullheart + Halfheart && i + 12 < heart.Length)
            {

                heart[i + 12].SetActive(true);
            }
        }
        for (int i = (int)playerStats.MaxHp; i < Mathf.Min(playerStats.MaxHp + FullSoulheart, heart.Length); i++) // �ִ�ü�� ���� �ҿ���Ʈ�� UI�� ��Ÿ���°�
        {

            heart[i + 48].SetActive(true);

        }
        for (int i = (int)playerStats.MaxHp + FullSoulheart; i < Mathf.Min(playerStats.MaxHp + FullSoulheart + HalfSoulheart, heart.Length); i++) // ���ݼҿ���Ʈ Ȱ��ȭ ��Ű�°�
        {

            heart[i + 36].SetActive(true); ;

        }


    }

    public void ClearHeart()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            heart[i].SetActive(false);
        }

    }
}
