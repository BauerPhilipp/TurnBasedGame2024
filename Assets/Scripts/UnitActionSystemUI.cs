using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnitActionSystemUI : MonoBehaviour
{

    [SerializeField] private Transform actionButtonPrefab;
    [SerializeField] private Transform actionButtonContainerTransform;

    private void Start()
    {
        CreateUnitActionButtons();
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;
    }


    private void CreateUnitActionButtons()
    {

        foreach(Transform buttonTransform in actionButtonContainerTransform) 
        {
            Destroy(buttonTransform.gameObject);
        }

        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();

        foreach(BaseAction baseAction in selectedUnit.GetBaseActionArray())
        {
            Transform actionButtonTransform = Instantiate(actionButtonPrefab, actionButtonContainerTransform);
            actionButtonTransform.GetComponent<ActionButtonUI>().SetBaseAction(baseAction);
        }
    }

    private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs e)
    {
        CreateUnitActionButtons();
    }
}
