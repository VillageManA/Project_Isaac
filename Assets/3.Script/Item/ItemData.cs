using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "Data/ItemData")]
public class ItemData : ScriptableObject
{

    [SerializeField] private Sprite sprite;

    public UnityEvent itemeffect;
}

