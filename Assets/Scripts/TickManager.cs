using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    //public int caughtFish = 0;
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
            if (random < 0.1f)
            {
                Catch();
            }
        }
    }

    void Catch()
    {
        isCatching = false;
        isOnLine = true;

        float randomFish = Random.value;

        if (randomFish < 0.7)
        {
            commonFish++;
            uiManager.ShowCommonCaught(commonFish);
            isCatching = true;
            isOnLine = false;
            return;
        }
        else if (randomFish < 0.95)
        {
            uncommonFish++;
            uiManager.ShowUncommonCaught(uncommonFish);
            isCatching = true;
            isOnLine = false;
            return;
        }
        else
        {
            rareFish++;
            uiManager.ShowRareCaught(rareFish);
            isCatching = true;
            isOnLine = false;
            return;
        }
    }
}