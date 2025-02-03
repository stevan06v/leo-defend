using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   public void ChangeScene()
   {
       SceneManager.LoadScene(1);
   }

    public void ExitGame()
    {
        Debug.Log("exited...");
        SceneManager.LoadScene(0);
    }
}
