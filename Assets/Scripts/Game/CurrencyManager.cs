using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public Text currencyCountText;
    public int currencyAmount;
    public int defaultCurrencyAmount;

    public void Init(){
        currencyAmount = defaultCurrencyAmount;
        currencyCountText.text = currencyAmount.ToString();
    }

    public void Gain(int val){
        currencyAmount+=val;
        UpdateUI();
    }

    public bool Use(int val){
        if(EnoughCurrency(val)){
            currencyAmount -= val;
            UpdateUI();
            return true;
        }else{
            return false;
        }
    }

    public bool EnoughCurrency(int val){
        if(val <= currencyAmount){
            return true;
        }else{
            return false;
        }
    }

    void UpdateUI() {
        currencyCountText.text = currencyAmount.ToString();
    }       
}
