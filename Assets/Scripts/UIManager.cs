using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public GameObject fishCaught;
    public TMP_Text CommonCaughtText;
    public TMP_Text UncommonCaughtText;
    public TMP_Text RareCaughtText;


    public void ShowCommonCaught(int fish)
    {
        CommonCaughtText.text = "Common Fish: " + fish;
    }

    public void ShowUncommonCaught(int fish)
    {
        UncommonCaughtText.text = "Uncommon Fish: " + fish;
    }

    public void ShowRareCaught(int fish)
    {
        RareCaughtText.text = "Rare Fish: " + fish;
    }
}
