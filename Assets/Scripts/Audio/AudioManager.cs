using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// 音频管理器
/// </summary>
public class AudioManager : MonoBehaviour {

  /// <summary>
  /// 可通过 Unity Inspector 管理的音频信息 (实际为 AudioSource 的一个必要子集)
  /// </summary>
  [Serializable]
  public class AudioInfo
  {
    public AudioClip clip;

    public AudioMixerGroup group;

    [Range(0, 1)]
    public float volume = 1.0f;

    public bool isAutoPlay;

    public bool isLoop;
  }

  /// <summary>
  /// 音频管理器的单例实例
  /// </summary>
  private static AudioManager INSTANCE;

  /// <summary>
  /// 管理中的音频信息列表
  /// </summary>
  public List<AudioInfo> audioInfoList;

  /// <summary>
  /// 用于挂载所有AudioSource的虚拟根对象
  /// </summary>
  private GameObject audioHolder;

  /// <summary>
  /// 音频文件名到音频源的映射表
  /// </summary>
  private Dictionary<string, AudioSource> audioPool;

  void Awake()
  {
    INSTANCE = this;

    audioHolder = new GameObject("AudioHolder");
    audioHolder.transform.SetParent(transform);   // holder和manager在空间上绑在一起
    audioPool = new Dictionary<string, AudioSource>();
  }

  void Start () {
    // 将所有已注册的音频挂载到audioHolder对象上
    foreach (var info in audioInfoList)
    {
      AudioSource source = audioHolder.AddComponent<AudioSource>();
      source.clip = info.clip;
      source.outputAudioMixerGroup = info.group;
      source.volume = info.volume;
      source.playOnAwake = info.isAutoPlay;
      source.loop = info.isLoop;

      audioPool.Add(info.clip.name, source);

      if (info.isAutoPlay) { source.Play(); }
    }
  }

  /// <summary>
  /// 播放指定音频
  /// </summary>
  /// <param name="audioName">音频文件名</param>
  /// <param name="allowMultiple">是否允许同一段音频同时多次播放</param>
  public static void Play(string audioName, bool allowMultiple=false)
  {
    if (!INSTANCE.audioPool.ContainsKey(audioName)) { Debug.LogWarningFormat("Missing audio {0}", audioName); return; }

    AudioSource source = INSTANCE.audioPool[audioName];
    if (!allowMultiple && source.isPlaying) { return; }
    source.Play();
  }

  /// <summary>
  /// 停止播放指定音频
  /// </summary>
  /// <param name="audioName">音频文件名</param>
  public static void Stop(string audioName)
  {
    if (!INSTANCE.audioPool.ContainsKey(audioName)) { Debug.LogWarningFormat("Missing audio {0}", audioName); return; }

    AudioSource source = INSTANCE.audioPool[audioName];
    if (!source.isPlaying) { return; }
    source.Stop();
  }

  /// <summary>
  /// 暂停播放指定音频
  /// </summary>
  /// <param name="audioName">音频文件名</param>
  public static void Pause(string audioName)
  {
    if (!INSTANCE.audioPool.ContainsKey(audioName)) { Debug.LogWarningFormat("Missing audio {0}", audioName); return; }

    AudioSource source = INSTANCE.audioPool[audioName];
    if (!source.isPlaying) { return; }
    source.Pause();
  }

  /// <summary>
  /// 继续播放已暂停的指定音频
  /// </summary>
  /// <param name="audioName">音频文件名</param>
  public static void Continue(string audioName)
  {
    if (!INSTANCE.audioPool.ContainsKey(audioName)) { Debug.LogWarningFormat("Missing audio {0}", audioName); return; }

    AudioSource source = INSTANCE.audioPool[audioName];
    if (!source.isPlaying) { return; }
    source.UnPause();
  }

}
