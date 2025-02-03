using UnityEngine;

public class BgMusic : MonoBehaviour
{


    public static BgMusic instance;
    void Awake() { instance = this; }
    public AudioSource src;
    public AudioClip sfx1;

    void Start()
    {
        src.clip = sfx1;
        src.Play();
    }

 

}
