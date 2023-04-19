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
     �밢�� �̵� ���������� ������ȯ
     óġ�ÿ� ����

     Sucker
     Hp = 10;
     �÷��̾� ����
     óġ�� + �� ��� ����

     Hopper
     Hp = 10;
     �����ϸ鼭 �̵� , ������ ���� �Ѿ�ٴҼ����� �÷��̾��νĽ� �÷��̾ ����
     ������ + �� ��� ����
     
     Charger
     Hp = 20;
     +�ڸ�翡 �÷��̾� �νĽ� ����, ��or ��ֹ��� �ε����� ����
     
     KamikazeLeech 
     Hp = 25;
     �����¿� �������� �̵�, �÷��̾ +�� �ȿ� �νĽ� ����
     ����� ���� ,���ٵ����� 1

     Host
     Hp=14;
     �Ӹ������������� ����x 
     �÷��̾ �ֺ������� ���� ���� / �̶� ���ݰ���(�ݶ��̴�����)
     ��ź�� �������Ծ����� ��׷��� 

     StoneHead
     Hp=20; (����)
     ������ ��� �����߻�
     �ʿ� ���Ͱ� ������ ������ ��Ȱ��ȭ
     
     Keeper
     Hp = 36;
     �پ�ٴϴٰ� (�� �ɾ�ٴϰ��Ұ���) �÷��̾� �νĽ� 2���� ���� ����
     Ű���� ������ ������ ���� ������ 
     
     Floating Knight
     Hp = 20;
     ���ƴٴ� �����¿��̵� ������� �ݶ��̴�

     Monstro
     Hp=250;
     �������� �������� �������� �߻� (������)
     ���������� �����ۿ��� �ٰ���
     ū������ �������� ������ġ�� ����, ���Ͻ� �ֺ��� ��������
     */
}
