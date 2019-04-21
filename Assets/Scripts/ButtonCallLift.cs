
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
        UnityAction action;
        action = delegate
        {
            Select();

            int Floor = int.Parse(PlayerOnFloor.text);
            LiftController.Instance.SetNextFloor(Floor, Command.FromOutside, CallDirection);
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

}
