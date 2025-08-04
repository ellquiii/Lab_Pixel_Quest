using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class FinalGameUI : MonoBehaviour
{
    public Image heartImage;
    public TextMeshProUGUI coinText;
    // Start is called before the first frame update
    public void StartUI()
    {
        heartImage = GameObject.Find("HeartImage").GetComponent<Image>();
        coinText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        heartImage.fillAmount = currentHealth / maxHealth;
    }

    public void UpdateCoin(string newText)
    {
        coinText.text = newText;
    }
}