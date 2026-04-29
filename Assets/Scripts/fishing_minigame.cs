using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class fishing_minigame : MonoBehaviour
{
    public RectTransform marker;
    public RectTransform successArea;
    public float markerSpeed = 300f;

    public TMP_Text caughtText;
    public string caughtMessage = "You caught the fish!";
    public string failedMessage = "The fish got away!";

    public bool isFinished = false;
    public bool success = false;

    private bool movingUp = true;
    private float startY;
    public float range = 150f;

    void Start()
    {
        isFinished = false;
        success = false;

        startY = marker.anchoredPosition.y;

        float fishRarity = Random.value;

        if (caughtText != null)
        {
            caughtText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (isFinished) return;

        MoveMarker();

        // right click with New Input System
        if (Mouse.current != null && Mouse.current.rightButton.wasPressedThisFrame)
        {
            CheckCatch();
        }
    }

    void MoveMarker()
    {
        float move = markerSpeed * Time.deltaTime;

        if (movingUp)
            marker.anchoredPosition += new Vector2(0, move);
        else
            marker.anchoredPosition -= new Vector2(0, move);

        if (marker.anchoredPosition.y >= startY + range)
            movingUp = false;

        if (marker.anchoredPosition.y <= startY - range)
            movingUp = true;
    }

    void CheckCatch()
    {
        Debug.Log("Spawned: " + gameObject.name);

        float markerY = marker.anchoredPosition.y;

        float successMin = successArea.anchoredPosition.y - successArea.rect.height / 2;
        float successMax = successArea.anchoredPosition.y + successArea.rect.height / 2;

        isFinished = true;

        if (caughtText != null)
        {
            caughtText.gameObject.SetActive(true);

            if (markerY >= successMin && markerY <= successMax)
            {
                success = true;
                caughtText.text = caughtMessage;
                Debug.Log("Success! You caught the fish!");
            }
            else
            {
                caughtText.text = failedMessage;
                Debug.Log("Failed! The fish got away!");
            }
        }
    }
}