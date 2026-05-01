using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;

    public GameObject fishGame;

    public fishing_minigame fishingMinigame;

    private bool resultProcessed = false;

    public int commonFish = 0;
    public int uncommonFish = 0;
    public int rareFish = 0;

    public bool isCatching = true;
    public bool isOnLine = false;

    public float random = 0f;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        random = Random.value;

        if (isCatching)
        {
            if (random < 0.01f)
            {
                Catch();
            }
        }

        if (fishingMinigame != null)
        {
            Debug.Log("Finished = " + fishingMinigame.isFinished);
        }

        if (fishingMinigame != null && fishingMinigame.isFinished && !resultProcessed)
        {
            resultProcessed = true;
            HandleResult();
        }
    }

    void Catch()
    {
        isCatching = false;
        isOnLine = true;
        resultProcessed = false;

        GameObject instance = Instantiate(fishGame);
        instance.SetActive(true);
        Debug.Log("Spawned: " + instance.name);

        fishingMinigame = instance.GetComponentInChildren<fishing_minigame>();
        //fishingMinigame.markerSpeed = 450f;
    }

    void HandleResult()
    {
        bool success = fishingMinigame.success;
        if (success)
        {
            float fishRarity = Random.value;
            if (fishRarity < 0.05f)
            {
                commonFish++;
                uiManager.ShowCommonCaught(commonFish);
            }
            else if (fishRarity < 0.1f)
            {
                uncommonFish++;
                uiManager.ShowUncommonCaught(uncommonFish);
            }
            else
            {
                rareFish++;
                uiManager.ShowRareCaught(rareFish);
            }
            uiManager.UpdateCapybara(commonFish, uncommonFish, rareFish);
        }
        Destroy(fishingMinigame.transform.root.gameObject);
        fishingMinigame = null;

        isCatching = true;
        isOnLine = false;
    }
}