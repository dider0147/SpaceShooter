using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Items/Drop Items")]
public class DropItems : ScriptableObject
{
    public GameObject ItemPrefab;
    [Range(0f, 1f)]
    public float DropRate;
}
