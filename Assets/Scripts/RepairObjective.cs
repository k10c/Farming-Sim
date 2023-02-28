using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

// Aidan

public class RepairObjective : MonoBehaviour
{
    [SerializeField]
    private ItemSO resource;
    [SerializeField]
    private int requiredQuantity;
    [SerializeField]
    public Action onObjectiveComplete;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI description;

    void Start()
    {
        icon.sprite = resource.image;
        description.text = "Need " + requiredQuantity.ToString();
    }

    private void completeObjective()
    {
        onObjectiveComplete.Invoke();
    }

}
