﻿
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ButtonCallLift : ButtonBase, ISelectable
{

    [Space]
    public InputField PlayerOnFloor;
    public Direction CallDirection;


    private void Awake()
    {
        AddToSelectablesList();

        UnityAction action;
        action = delegate
        {
            Select();

            int Floor = int.Parse(PlayerOnFloor.text);
            LiftController.Instance.SetNextFloor(Floor, Command.FromOutside, CallDirection);
        };

        AddOnClick(action);
    }

    private void OnDestroy()
    {
        RemoveFromSelectablesList();
    }


    public void Select()
    {
        SelectionController.SelectArrowButton(this);
    }

    public void DeSelect()
    {
        Selection.SetActive(false);
    }

    public void AddToSelectablesList()
    {
        SelectionController.AddArrowButton(this);
    }

    public void RemoveFromSelectablesList()
    {
        SelectionController.RemoveArrowButton(this);
    }
}