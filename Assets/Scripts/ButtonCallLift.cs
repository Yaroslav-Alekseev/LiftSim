
public class ButtonCallLift : ButtonBase, ISelectable
{

    private void Awake()
    {
        AddOnClick(action: Select);
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
