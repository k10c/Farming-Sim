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
    public Action<int> attemptToComplete;

    [SerializeField]
    private ItemSO resource;
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
        icon.sprite = resource.image;
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

    public void setID(int id)
    {
        objectiveID = id;
    }

    public void complete()
    {
        description.text = "complete";
        completeButton.SetActive(false);
    }

    

}
