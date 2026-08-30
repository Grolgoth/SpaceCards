using UnityEngine;

public class ShipClassButton : MonoBehaviour
{
    public int shipClass;
    public ShipInfoPanel infoPanel;
    public CharacterCarousel scroller;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SelectShip()
    {
        bool left = rectTransform.anchoredPosition.x > 0;
        infoPanel.Show(shipClass, left);
        scroller.SetButtonsActive(false);
    }
}
