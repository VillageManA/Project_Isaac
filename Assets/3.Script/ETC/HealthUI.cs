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
    //0~11빔 12~23 반 24~35 풀 36~47 반소울 48~59 풀소울
    public void UpdateHeart()
    {
        ClearHeart();
        //빨간하트의 남은 갯수를 나타내기위함
        Fullheart = (int)playerStats.curHp;
        remainHeart = playerStats.curHp - Fullheart;
        Halfheart = remainHeart * 2;
        //소울하트의 남은갯수를 나타내기위함
        FullSoulheart = (int)playerStats.SoulHp;
        remainSoulHeart = playerStats.SoulHp - FullSoulheart;
        HalfSoulheart = remainSoulHeart * 2;



        //GameObject[] soulheart = new GameObject[(int)playerStats.SoulHp];

        for (int i = Fullheart + (int)Halfheart; i < Mathf.Min(playerStats.MaxHp, heart.Length); i++) //체력이 없는 빈하트를 채움
        {
            heart[i].SetActive(true);
        }


        for (int i = 0; i < Fullheart + Halfheart; i++) // 현재체력 풀하트,반하트를 채움
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
        for (int i = (int)playerStats.MaxHp; i < Mathf.Min(playerStats.MaxHp + FullSoulheart, heart.Length); i++) // 최대체력 이후 소울하트의 UI를 나타내는곳
        {

            heart[i + 48].SetActive(true);

        }
        for (int i = (int)playerStats.MaxHp + FullSoulheart; i < Mathf.Min(playerStats.MaxHp + FullSoulheart + HalfSoulheart, heart.Length); i++) // 절반소울하트 활성화 시키는곳
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
