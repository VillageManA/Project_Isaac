using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{

    private float curhp;
    public float CurHp
    {
        get { return curhp; }
        set
        {
            curhp = value;
            if (curhp < 0)
            {
                curhp = 0;
            }
        }
    }

    private float maxhp;
    public float MaxHp
    {
        get { return maxhp; }
        set 
        {
            maxhp = value;
        }
    }


    /*
     
     BoomFly
     Hp = 8;
     대각선 이동 벽에닿으면 방향전환
     처치시에 폭발

     Sucker
     Hp = 10;
     플레이어 추적
     처치시 + 자 모양 공격

     Hopper
     Hp = 10;
     점프하면서 이동 , 바위나 지형 넘어다닐수잇음 플레이어인식시 플레이어에 점프
     착지시 + 자 모양 공격
     
     Charger
     Hp = 20;
     +자모양에 플레이어 인식시 돌진, 벽or 장애물에 부딪히면 멈춤
     
     KamikazeLeech 
     Hp = 25;
     상하좌우 방향으로 이동, 플레이어가 +자 안에 인식시 돌진
     사망시 터짐 ,접근데미지 1

     Host
     Hp=14;
     머리가닫혀있을때 공격x 
     플레이어가 주변범위에 들어가면 공격 / 이때 공격가능(콜라이더생성)
     폭탄에 데미지입었을시 찌그러짐 

     StoneHead
     Hp=20; (무적)
     앞으로 계속 눈물발사
     맵에 몬스터가 없을시 문닫음 비활성화
     
     Keeper
     Hp = 36;
     뛰어다니다가 (난 걸어다니게할거임) 플레이어 인식시 2갈래 방향 공격
     키퍼의 공격을 받을시 돈이 떨어짐 
     
     Floating Knight
     Hp = 20;
     날아다님 상하좌우이동 뒤통수만 콜라이더

     Monstro
     Hp=250;
     아이작의 방향으로 랜덤눈물 발사 (분출형)
     작은점프로 아이작에게 다가감
     큰점프로 아이작의 현재위치에 강하, 강하시 주변에 눈물공격
     */
}
