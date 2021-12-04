using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class SoundManager 
{
    public enum Sound{
        PlayerWalkGrass,
        PlayerWalkStone

    }

    

    private static Dictionary<Sound, float> soundTimerDict;
    public static void Initialize(){
        soundTimerDict = new Dictionary<Sound, float>();
        soundTimerDict[Sound.PlayerWalkGrass]=0f;
    }

    public static void PlayOneOff(){
        GameObject sGameobject = new GameObject("Sound");
        AudioSource aSource = sGameobject.AddComponent<AudioSource>();
        aSource.PlayOneShot(GameAssets.Instance.oneOff);
    }
    
    //Call this to play oneoffs
    //Takes no inputs returns no outputs
    public static void PlayClip(Sound sound){
        if(AllowSoundPlay(sound)){
        GameObject soundObject = new GameObject("Sound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = GetAudioClip(sound);
        audioSource.volume = 0.2f;
        audioSource.Play();
        Object.Destroy(soundObject, audioSource.clip.length);
        }
    }

    private static AudioClip GetAudioClip(Sound sound){
        foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.Instance.SoundAudioClipArray){
            if(soundAudioClip.sound == sound){
                Debug.Log("got a clip");
                return soundAudioClip.audioClip;
            }
        }
        Debug.Log("A sound was not found! " + sound);
        return null;
    }

    private static bool AllowSoundPlay(Sound sound){
        switch(sound){
            default:
                return true;
            case Sound.PlayerWalkGrass:
                if(soundTimerDict.ContainsKey(sound))
                {
                    float lastPlayed = soundTimerDict[sound];
                    float timerMax = .5f;

                    if(lastPlayed + timerMax < Time.time)
                    {
                        soundTimerDict[sound] = Time.time;
                        return true;
                    }
                    else{ return false; }
                } else{ return true;}
            case Sound.PlayerWalkStone:    
                if(soundTimerDict.ContainsKey(sound))
                {
                    float lastPlayed = soundTimerDict[sound];
                    float timerMax = .5f;

                    if(lastPlayed + timerMax < Time.time)
                    {
                        soundTimerDict[sound] = Time.time;
                        return true;
                    }
                    else{ return false; }
                } else{ return true;}
        }
    }

    
}
