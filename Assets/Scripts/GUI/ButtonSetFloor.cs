using UnityEngine;
using UnityEngine.Events;


public class ButtonSetFloor : ButtonBase, ISelectable, IChangableText
{

    private void Awake()
    {
        AddToSelectablesList();

        UnityAction action;
        action = delegate
        {
            Select();

            int Floor = int.Parse(TextScript.text);
            LiftController.Instance.SetNextFloor(Floor, Command.FromInside);
        };

        AddOnClick(action);
    }

    private void OnDestroy()
    {
        RemoveFromSelectablesList();
    }


    public void Select()
    {
        SelectionController.SelectFloorButton(this);
    }

    public void DeSelect()
    {
        Selection.SetActive(false);
    }

    public void SetText(string NewText)
    {
        TextScript.text = NewText;
    }

    public void AddToSelectablesList()
    {
        SelectionController.AddFloorButton(this);
    }

    public void RemoveFromSelectablesList()
    {
        SelectionController.RemoveFloorButton(this);
    }

}
