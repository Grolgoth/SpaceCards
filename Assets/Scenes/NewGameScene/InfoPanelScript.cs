using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipInfoPanel : MonoBehaviour
{
    public GameObject ShipCarousel;
    public GameObject ShipCarouselBackground;
    public GameObject LibrarySceneBackground;

    public TextMeshProUGUI TitleText;
    public BookScript MainText;
    public CharacterCarousel scroller;
    public Button moreInfoButton;
    public bool moreInfo = false;

    private int selectedShipClass;
    private string descriptionText;
    private string detailText;

    public void Show(int shipClass, bool left)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        selectedShipClass = shipClass;

        if (left)
            rectTransform.anchoredPosition = new Vector2(-177.0f, rectTransform.anchoredPosition.y);
        else
            rectTransform.anchoredPosition = new Vector2(177.0f, rectTransform.anchoredPosition.y);

        if (shipClass == 1)
        {
            TitleText.text = "The Tank";
            descriptionText = "Heavy tank build: ...";
            detailText = "A typical armored carrier craft hailing from the Udo system. This particular model was produced by the thousands during the Udo empire's first golden age. It was the go-to option for almost any type of merchant due to their advanced storage chambers, and relative low cost. Due to the heavy armor, they proved quite resistant to occasional attacks or robbery attempts from pirates, and they could handle almost any type of planetary atmosphere or gravity levels, even being able to weather the storms of turbulent gas giants or asteroid belts. The fact that they are still used to this day is a testament to their durability.";
        }
        else if (shipClass == 2)
        {
            TitleText.text = "The Crab";
            descriptionText = "Fighter build ...";
            detailText = "An unconvential assembly of powerful engines with unusual weaponry. While built for unknown purposes, several specific features of this ship indicate that most of its use must have been tied to certain activities. All its weaponry was produced on Omer, and while pretty standard, is of the same unmatched quality as all Omer's weaponry boasts. The claw stands out especially, and while one could easily claim it is merely for scavenging purposes, it could just as easily be used to tear another ship apart. And its small size and first-class engines allow it to out-manouver and get in close on most other ships. The ship was recently salvaged from deep space, where it was drifting aimlessly and abandoned, though strangely, completely in tact.";
        }
        else if (shipClass == 3)
        {
            TitleText.text = "Black Diamond";
            descriptionText = "Knowledge build ...";
            detailText = "These mysterious alien ships have been found in several corners of inhabited space. Though never quite identical, their diamond shape is known as a staple, and tiny differences hint merely at different specialties between ships while maintaining an overall uniform design. While their creators have never been discovered and are largely believed to be long extinct, the ships have never shown any signs of wearing over the ages. The exact details on the workings of their engines and reality modulation drives are still studied extensively by scientists, and continue to baffle them to this day. In comparison to specialised human ships, they turn out to be pretty strong all round, though out-classed by some in speed, or by others in shielidng or weaponry. Seveal adjustments have to be made before they can be used by humans, such as raising the temperature by about 50 degrees from the absurd minus 30 at which their old masters seemed to have been comfortable, or widening the doors or certain corners in the hallways. Even then, no human aboard these ships will ever feel truly comfortable surrounded by so much strange geometry unknown materials.";
        }
        else if (shipClass == 4)
        {
            TitleText.text = "The Needle";
            descriptionText = "Glass cannon build ...";
            detailText = "Needles are the ships of the richest and most influential people in the Udo system. They are built for those who need to get to their destination fast while comfortably, saving no expenses. Politicians, diplomats, business magnates and interplanetary lawyers are often encountered flying these ships anywhere within inhabited space. They are some of the fastest ships humanity has ever built, and surprisingly apt at defending themselves as well, where speed doesn't serve them. During the empire's brief civil war, they were used on several occasions in battle where they went head to head with specialized war ships.";
        }

        ChooseDescription(moreInfo);
        gameObject.SetActive(true);
    }

    public void Confirm()
    {
        GameState.Instance.setShipClass(selectedShipClass);

        gameObject.SetActive(false);
        ShipCarousel.SetActive(false);
        ShipCarouselBackground.SetActive(false);
        LibrarySceneBackground.SetActive(true);
    }

    public void Back()
    {
        if (moreInfo)
            ChooseDescription(false);
        else
        {
            gameObject.SetActive(false);
            scroller.SetButtonsActive(true);
        }
    }

    public void ChooseDescription(bool detailed)
    {
        moreInfo = detailed;
        moreInfoButton.gameObject.SetActive(!detailed);
        if (detailed)
            MainText.SetText(detailText);
        else
            MainText.SetText(descriptionText);
    }

    public void MoreInformation()
    {
        ChooseDescription(true);
    }
}
