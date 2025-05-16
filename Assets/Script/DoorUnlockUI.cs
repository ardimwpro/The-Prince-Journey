using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorUnlockUI : MonoBehaviour
{
    public Text messageText;
    public float messageDuration = 2f;

    private Coroutine currentCoroutine;

    public void ShowMessage(string message)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        messageText.text = message;
        gameObject.SetActive(true);
        currentCoroutine = StartCoroutine(HideMessageAfterDelay());
    }

    private IEnumerator HideMessageAfterDelay()
    {
        yield return new WaitForSeconds(messageDuration);
        gameObject.SetActive(false);
    }
}
