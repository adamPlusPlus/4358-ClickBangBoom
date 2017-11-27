using System;
using UnityEngine;

public class MusicTrigger: MonoBehaviour {
  public MusicController musicController; 
  public AudioClip musicClip;

  public void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player") && musicController.currentMusic != musicClip) {
      musicController.PlayMusic(musicClip, 1.0f, true, true);
    }
  }
}
