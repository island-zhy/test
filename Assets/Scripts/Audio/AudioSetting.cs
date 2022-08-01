using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// 玩家通过UI可控的音频设置
/// </summary>
public class AudioSetting : MonoBehaviour {

  public AudioMixer mixer;

  public void SetBGMVolume(float value)
  {
    mixer.SetFloat("VolumeBGM", value);
  }

  public void SetSFXVolume(float value)
  {
    mixer.SetFloat("VolumeSFX", value);
  }

}
