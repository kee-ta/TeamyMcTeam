using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;
    public float volume, pitch;

    public static GameAssets Instance
    {
        get{
            if(_i == null )  _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();              
                return _i;
        }
    }

    void Start()
    {
        Debug.Log("Assests Loaded");
    }

    public AudioClip oneOff;

    public SoundAudioClip[] SoundAudioClipArray;

    [System.Serializable]
    public class SoundAudioClip{
        public SoundManager.Sound sound;
        public AudioClip audioClip;
    }

    public Sprite s_HealthPotion;
    public Sprite s_Stone;
    public Sprite s_Stick;
    public Sprite s_Flower;
}
