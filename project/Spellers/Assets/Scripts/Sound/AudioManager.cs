using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;

public class AudioManager : MonoBehaviour
{
    //Fuentes de recursos a través de los cuales se reproduce un sonido
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundEffectSource;

    //Listas para almacenar todos los sonidos
    [SerializeField] private List<AudioClip> musicClips;
    [SerializeField] private List<AudioClip> soundEffectClips;

    //Diccionarios para acceder alos sonidos por su nombre
    [SerializeField] private Dictionary<string, AudioClip> music;
    [SerializeField] private Dictionary<string, AudioClip> soundsEffect;

    //Inicializa los diccionarios y los llena
    public void Awake()
    {
        music = new Dictionary<string, AudioClip>();
        soundsEffect = new Dictionary<string, AudioClip>();

        foreach (AudioClip clip in musicClips)
        {
            music.Add(clip.name, clip);
        }
        foreach (AudioClip clip in soundEffectClips)
        {
            soundsEffect.Add(clip.name, clip);
        }
    }


    private void OnEnable()
    {
        Debug.Log("Sub");
        Events.OnLoadScene.AddListener(PlayMusicTheme);
    }

    private void OnDisable()
    {
        Events.OnLoadScene.RemoveListener(PlayMusicTheme);
        soundEffectSource.Stop();
    }

    private void PlayMusicTheme(int sceneIdx)
    {
        soundEffectSource.clip = musicClips[sceneIdx];
        soundEffectSource.Play();
    }

    //Método para reproducir un efecto de sonido
    public void playSoundEffect(string name)
    {
        soundEffectSource.clip = soundsEffect[name];
        soundEffectSource.Play();
    }

    //Método para reproducir música
    public void playMusic(string name)
    {
        musicSource.clip = music[name];
        musicSource.Play();
    }
}
