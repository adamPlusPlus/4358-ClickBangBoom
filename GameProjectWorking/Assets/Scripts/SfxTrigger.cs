using System;
using UnityEngine;

public class SfxTrigger: MonoBehaviour {
  public AudioSource audioSource;
  public AudioClip clip;
  public float volume;

  public void OnTriggerEnter(Collider other) {
    if(other.CompareTag("Player"))
      audioSource.PlayOneShot(clip, volume);
  }
}