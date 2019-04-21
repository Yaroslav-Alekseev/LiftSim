using UnityEngine;
using UnityEngine.Events;


public class ButtonSetFloor : ButtonBase, ISelectable, IChangableText
{

    private void Awake()
    {
        UnityAction action;
        action = delegate
        {
            Select();

            int Floor = int.Parse(TextScript.text);
            LiftController.Instance.SetNextFloor(Floor, Command.FromInside);
        };

        AddOnClick(action);
    }


    public void Select()
    {
        Selection.SetActive(true);
    }

    public void DeSelect()
    {
        Selection.SetActive(false);
    }

    public void SetText(string NewText)
    {
        TextScript.text = NewText;
    }

}
