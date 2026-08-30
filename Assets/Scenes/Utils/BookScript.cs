using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BookScript : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Button PreviousButton;
    public Button NextButton;
    public int takeWordsFromEndN = 0;

    private List<string> pages = new List<string>();
    private int currentPage = 0;

    public void SetText(string fullText)
    {
        pages = CreatePages(fullText);
        currentPage = 0;

        if (pages.Count > 0)
            ShowCurrentPage();
    }

    private List<string> CreatePages(string fullText)
    {
        List<string> result = new List<string>();

        int startIndex = 0;
        int takeOffWordsCounter = takeWordsFromEndN;

        while (startIndex < fullText.Length)
        {
            text.text = fullText.Substring(startIndex);

            // Make TMP calculate the layout immediately
            text.ForceMeshUpdate();

            TMP_TextInfo textInfo = text.textInfo;

            // Find the last character that actually fits
            int lastVisibleCharacter = -1;

            for (int i = 0; i < textInfo.characterCount; i++)
            {
                TMP_CharacterInfo character = textInfo.characterInfo[i];

                if (character.isVisible)
                    lastVisibleCharacter = i;
            }

            // Everything fits on this page
            if (!text.isTextOverflowing)
            {
                result.Add(fullText.Substring(startIndex));
                break;
            }

            if (lastVisibleCharacter < 0)
            {
                Debug.LogError("Text box is too small to fit even one character.");
                break;
            }

            // Convert TMP's character index to the original string index
            int breakIndex = startIndex + lastVisibleCharacter + 1;

            // Move backwards until we find whitespace
            while (breakIndex > startIndex && (!char.IsWhiteSpace(fullText[breakIndex - 1]) || takeOffWordsCounter > 0))
            {
                breakIndex--;
                if (char.IsWhiteSpace(fullText[breakIndex - 1]))
                    takeOffWordsCounter--;
            }

            // Safety check: avoid an infinite loop if one word
            // is longer than the entire text box.
            if (breakIndex <= startIndex)
            {
                breakIndex = startIndex + lastVisibleCharacter + 1;
            }

            string page = fullText.Substring(
                startIndex,
                breakIndex - startIndex
            ).TrimEnd();

            result.Add(page);

            startIndex = breakIndex;

            // Skip whitespace at the beginning of the next page.
            while (startIndex < fullText.Length &&
                   char.IsWhiteSpace(fullText[startIndex]))
            {
                startIndex++;
            }
        }

        return result;
    }

    private void ShowCurrentPage()
    {
        text.text = pages[currentPage];

        PreviousButton.gameObject.SetActive(currentPage > 0);
        NextButton.gameObject.SetActive(currentPage < pages.Count - 1);
    }

    public void NextPage()
    {
        if (currentPage < pages.Count - 1)
        {
            currentPage++;
            ShowCurrentPage();
        }
    }

    public void PreviousPage()
    {
        if (currentPage > 0)
        {
            currentPage--;
            ShowCurrentPage();
        }
    }
}
