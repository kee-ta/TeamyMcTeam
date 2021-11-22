using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image s_HealthPotion;
    public Image s_Stone;
    public Image s_Stick;
    public Image s_Flower;
}
