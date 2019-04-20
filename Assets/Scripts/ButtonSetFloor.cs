
public class ButtonSetFloor : ButtonBase, ISelectable, IChangableText
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

    public void SetText(string NewText)
    {
        TextScript.text = NewText;
    }

}
