using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{

    public static SoundEffectPlayer instance;
    void Awake() { instance = this; }
    public AudioSource src;
    public AudioClip sfx1, sfx2, sfx3;

    public void playShoot(){
        Debug.Log("SHOOTTT");
        src.clip = sfx1;
        src.Play();
   }
    public void playCollect(){
        src.clip = sfx2;
        src.Play();
   }
    public void playBackgroundMusic(){
        src.clip = sfx3;
        src.Play();
   }
   
}
