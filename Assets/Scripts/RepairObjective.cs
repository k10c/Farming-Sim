using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

// Written by Aidan

public class RepairObjective : MonoBehaviour
{
    [SerializeField]
    public Action<int> attemptToComplete;

    [SerializeField]
    private ItemInfo resource;
    [SerializeField]
    private int requiredQuantity;
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI description;
    [SerializeField]
    private GameObject completeButton;

    private int objectiveID;

    void Start()
    {
        icon.sprite = resource.itemIcon;
        description.text = "Need " + requiredQuantity.ToString();
    }

    public void onClick()
    {
        attemptToComplete.Invoke(objectiveID);
    }

    public int getRequiredQuantity()
    {
        return requiredQuantity;
    }

    public ItemInfo getResource()
    {
        return resource;
    }

    public void setID(int id)
    {
        objectiveID = id;
    }

    public void complete()
    {
        description.text = "complete";
        completeButton.SetActive(false);
    }

    public void scaleQuantity()
    {
        requiredQuantity = requiredQuantity * 2;
        description.text = "Need " + requiredQuantity.ToString();
    }
    

}
