using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text CommonCaughtText;
    public TMP_Text UncommonCaughtText;
    public TMP_Text RareCaughtText;

    public Image caughtFishImage;

    public Sprite[] commonFishSprites;
    public Sprite[] uncommonFishSprites;
    public Sprite[] rareFishSprites;

    public Image capybaraImage;

    public Sprite startingCapybara;
    public Sprite commonCapybara;
    public Sprite uncommonCapybara;
    public Sprite rareCapybara;

    public void ShowCommonCaught(int fish)
    {
        CommonCaughtText.text = "Common Fish: " + fish;
        SetRandomSprite(commonFishSprites);
    }

    public void ShowUncommonCaught(int fish)
    {
        UncommonCaughtText.text = "Uncommon Fish: " + fish;
        SetRandomSprite(uncommonFishSprites);
    }

    public void ShowRareCaught(int fish)
    {
        RareCaughtText.text = "Rare Fish: " + fish;
        SetRandomSprite(rareFishSprites);
    }

    void SetRandomSprite(Sprite[] sprites)
    {
        if (sprites.Length == 0) return;

        int index = Random.Range(0, sprites.Length);
        caughtFishImage.sprite = sprites[index];
        caughtFishImage.enabled = true;
        caughtFishImage.SetNativeSize();
    }

    public void UpdateCapybara(int common, int uncommon, int rare)
    {
        if (rare >= 10)
        {
            capybaraImage.sprite = rareCapybara;
        }
        else if (uncommon >= 10)
        {
            capybaraImage.sprite = uncommonCapybara;
        }
        else if (common >= 10)
        {
            capybaraImage.sprite = commonCapybara;
        }
    }
}