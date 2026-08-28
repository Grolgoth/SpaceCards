using UnityEngine;
using TMPro;
using System;
using System.Collections;

public class Typer : MonoBehaviour
{
    public bool IsTyping { get; private set; }

    private Coroutine typingCoroutine;
    private float defaultSpeed = 0.05f;

    public void Type(TextMeshProUGUI destination, string text, float? speed = null)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        float finalSpeed = speed ?? defaultSpeed;
        typingCoroutine = StartCoroutine(TypeText(destination, text, () => finalSpeed));
    }

    public void TypeDynamic(TextMeshProUGUI destination, string text, Func<float> getSpeed)
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeText(destination, text, getSpeed));
    }

    IEnumerator TypeText(TextMeshProUGUI destination, string text, Func<float> getSpeed)
    {
        IsTyping = true;
        destination.text = "";

        foreach (char c in text)
        {
            float speed = getSpeed();
            Debug.Log("typingSpeed from typer: " + speed);
            destination.text += c;
            if (speed >= 0.1f)
                yield return new WaitForSeconds(speed);
        }

        IsTyping = false;
    }

    public void Skip(TextMeshProUGUI destination, string fullText)
    {
        if (!IsTyping)
            return;

        StopCoroutine(typingCoroutine);
        destination.text = fullText;
        IsTyping = false;
    }
}