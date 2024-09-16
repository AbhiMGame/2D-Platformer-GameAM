using UnityEngine;
using System;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }
    public SoundType[] sounds;
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
           if(clip!=null)
        {
            soundEffect.PlayOneShot(clip);
        }
           else
        {
            Debug.LogError("Clip not found for sound type: " + sound);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
      SoundType item= Array.Find(sounds, i => i.soundType == sound);
        if(item!=null)
        {
            return item.soundClip;
        }
        return null;
    }

    [Serializable]
    public class SoundType
    {
        public Sounds soundType;
        public AudioClip soundClip;
    }

    public enum Sounds
    {
        ButtonClick,
        PlayerMove,
        PlayerDeath,
        EnemyDeath,
    }


}


