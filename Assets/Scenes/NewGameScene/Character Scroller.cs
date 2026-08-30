using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCarousel : MonoBehaviour
{
    public RectTransform content;

    public float spacing = 425f;
    public float startX = -210f;
    public float animationDuration = 0.3f;

    public Button leftButton;
    public Button rightButton;

    private bool isAnimating = false;

    void Start()
    {
        ArrangeCharacters();
    }

    public void MoveRight()
    {
        if (!isAnimating)
            StartCoroutine(ScrollRight());
    }

    public void MoveLeft()
    {
        if (!isAnimating)
            StartCoroutine(ScrollLeft());
    }

    void ArrangeCharacters()
    {
        for (int i = 0; i < content.childCount; i++)
        {
            RectTransform child =
                content.GetChild(i).GetComponent<RectTransform>();

            child.anchoredPosition =
                new Vector2(startX + spacing * i, child.anchoredPosition.y);
        }
    }

    IEnumerator ScrollRight()
    {
        isAnimating = true;

        Vector2 start = content.anchoredPosition;
        Vector2 end = start + new Vector2(-spacing, 0);

        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.SmoothStep(
                0f,
                1f,
                elapsed / animationDuration
            );

            content.anchoredPosition =
                Vector2.Lerp(start, end, t);

            yield return null;
        }

        // Put first character at the end
        Transform first = content.GetChild(0);
        first.SetAsLastSibling();

        // Restore content position
        content.anchoredPosition = start;

        ArrangeCharacters();

        isAnimating = false;
    }

    IEnumerator ScrollLeft()
    {
        isAnimating = true;

        // Take the last character and put it before the first
        Transform last = content.GetChild(content.childCount - 1);
        last.SetAsFirstSibling();

        // Temporarily put it one position to the left
        RectTransform lastRect =
            last.GetComponent<RectTransform>();

        lastRect.anchoredPosition =
            new Vector2(startX -spacing, lastRect.anchoredPosition.y);

        Vector2 start = content.anchoredPosition;
        Vector2 end = start + new Vector2(spacing, 0);

        float elapsed = 0f;

        while (elapsed < animationDuration)
        {
            elapsed += Time.deltaTime;

            float t = Mathf.SmoothStep(
                0f,
                1f,
                elapsed / animationDuration
            );

            content.anchoredPosition =
                Vector2.Lerp(start, end, t);

            yield return null;
        }

        content.anchoredPosition = start;

        ArrangeCharacters();

        isAnimating = false;
    }

    public void SetButtonsActive(bool active)
    {
        leftButton.gameObject.SetActive(active);
        rightButton.gameObject.SetActive(active);
    }
}