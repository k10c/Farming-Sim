using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Aidan

public class RepairObjective : MonoBehaviour
{
    [SerializeField]
    private ItemSO.ItemType material;
    [SerializeField]
    private int requiredQuantity;
    [SerializeField]
    public Action onObjectiveComplete;

    void Start()
    {
        
    }

    private void completeObjective()
    {
        onObjectiveComplete.Invoke();
    }

}
