using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    private Slider BossHpBar;
    [SerializeField] private DukeOffilies Boss;

    private void Awake()
    {
        Boss = FindObjectOfType<DukeOffilies>();
        TryGetComponent(out BossHpBar);
    }
    private void Update()
    {
        BossHpBar.value = Boss.CurHp / Boss.maxHp;

    }
}
