using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{
    public Text lifeCountText;
    public int healthAmount;
    public int defaultHealthAmount;

    public void Init(){
        healthAmount = defaultHealthAmount;
        lifeCountText.text = healthAmount.ToString();
    }

    public void LoseHealth(){

        if(healthAmount < 1) return;
        healthAmount--;
        lifeCountText.text = healthAmount.ToString();


        CheckHealthAmount();
    }

    public void CheckHealthAmount(){
        if(healthAmount < 1){
            Debug.Log("You have Lost!");
        } else{
            Debug.Log("You are still in keep going!");
        }
    }

}
