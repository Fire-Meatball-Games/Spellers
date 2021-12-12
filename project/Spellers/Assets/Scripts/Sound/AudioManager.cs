using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomEventSystem;
using Utils;

namespace Sound
{
    public class AudioManager : MonoBehaviour
    {
        //Fuentes de recursos a través de los cuales se reproduce un sonido
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource soundEffectSource;

        //Listas para almacenar todos los sonidos
        [SerializeField] private AudioClip musicClip;
        [SerializeField] private List<AudioClip> soundEffectClips;

        //Diccionarios para acceder alos sonidos por su nombre
        [SerializeField] private Dictionary<string, AudioClip> soundsEffect;

        //Inicializa los diccionarios y los llena
        public void Awake() {

            soundsEffect = new Dictionary<string, AudioClip>();

            foreach (AudioClip clip in soundEffectClips)
            {
                soundsEffect.Add(clip.name, clip);
            }
            PlayMusicTheme();
        }


        private void OnEnable()
        {
            Events.OnHitkey.AddListener(PlayRuneEffect);
        }

        private void PlayRuneEffect()
        {
            playSoundEffect("Runa");
        }
        private void OnDisable()
        {
            Events.OnHitkey.RemoveListener(PlayRuneEffect);
            musicSource.Stop();
        }

        private void PlayMusicTheme()
        {
            musicSource.clip = musicClip;
            musicSource.Play();
        }

        //Método para reproducir un efecto de sonido
        public void playSoundEffect(string name)
        {
            soundEffectSource.clip = soundsEffect[name];
            soundEffectSource.Play();
        }
    }
  
}

