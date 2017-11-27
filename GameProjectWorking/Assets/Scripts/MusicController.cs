using System;
using UnityEngine;

public class MusicController: MonoBehaviour {
  public AudioSource audioSource;
  public AudioClip currentMusic;
  public float initialVolume;
  public float volume;
  public bool loop;

  public int fadeState;
  public float fadeSpeed = 0.01f;
  public float postFadeDelay = 0.5f;

  private float delay;


  public void FixedUpdate() {
    switch(fadeState) {
      case 0:  // idle, just update volume
        audioSource.volume = volume;
        break;
      case 1:  // fading out
        if(audioSource.volume > 0)
          audioSource.volume -= fadeSpeed;
        else {
          audioSource.Stop();
          fadeState = 2;
        }
        break;
      case 2: // play new music
        audioSource.volume = volume = initialVolume;
        audioSource.loop = loop;
        if(audioSource.clip = currentMusic)
          audioSource.PlayDelayed(delay);
        fadeState = 0;
        break;
    }
  }

  public void PlayMusic(AudioClip music, float volume = 1.0f, bool loop = true, bool fadeout = false) {
    currentMusic = music;
    initialVolume = volume;
    this.loop = loop;
    if(fadeout && audioSource.isPlaying) {// if music currently playing, fade it out first
      delay = postFadeDelay;
      fadeState = 1;
    }
    else {
      delay = 0.0f;
      fadeState = 2;
    }
  }
}
