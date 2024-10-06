using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemsControl : MonoBehaviour
{   
    [SerializeField]public DropItems[] DropItems;
    
    public void DropRandomItem()
    {
        float rdValue = Random.Range(0f, 1f);
        float totalRate = 0f;
        foreach (DropItems item in DropItems)
        {
            totalRate += item.DropRate;
            if (rdValue <= totalRate)
            {
                Instantiate(item.ItemPrefab, transform.position, Quaternion.identity);
                break;
            }
        }
    }
}
