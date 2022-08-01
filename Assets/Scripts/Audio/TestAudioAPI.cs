using System.Text;
using UnityEngine;

public class TestAudioAPI : MonoBehaviour {

  private StringBuilder sb = new StringBuilder(300);

  public AudioSource source = null;
  private bool isPaused = false;

  private void Awake() {
    _ShowDeviceInfo();
  }

  void Start () {
    source = GetComponent<AudioSource>();
    if (source != null) { _InspectAudio(); }
    else { Debug.Log("no AudioSource attached, ignore audio playback test"); }
  }

  void Update () {
    if (source == null) return;

    if (Input.GetKeyDown(KeyCode.P)) {
      isPaused = !isPaused;
      if (isPaused) { source.UnPause(); }
      else { source.Pause();  }
    }

    if (Input.GetKeyDown(KeyCode.R)) {
      isPaused = false;
      source.Stop();
      source.Play();
    }

  }

  void _ShowDeviceInfo() {
    sb.Length = 0;
    sb.AppendLine  ("[AudioSettings]");

    AudioConfiguration config = AudioSettings.GetConfiguration();
    sb.AppendLine  ("  AudioConfiguration (Aduio Output Device):");
    sb.AppendFormat("    speakerMode: {0}\n", config.speakerMode);            // 输出设备工作模式(声道数量)
    sb.AppendFormat("    dspBufferSize: {0}\n", config.dspBufferSize);        // 输出设备DSP缓冲区大小
    sb.AppendFormat("    sampleRate: {0}\n", config.sampleRate);              // 输出设备采样率
    sb.AppendFormat("    numRealVoices: {0}\n", config.numRealVoices);        // 同时正在播放的最多声音数量
    sb.AppendFormat("    numVirtualVoices: {0}\n", config.numVirtualVoices);  // 同时管理的最多声音数量

    sb.AppendFormat("  driverCapabilities: {0}\n", AudioSettings.driverCapabilities);   // 驱动的设备能力(??
    sb.AppendFormat("  speakerMode: {0}\n", AudioSettings.speakerMode);
    sb.AppendFormat("  dspTime: {0}\n", AudioSettings.dspTime);
    sb.AppendFormat("  outputSampleRate: {0}\n", AudioSettings.outputSampleRate);   // Mixer的输出采样率
    sb.AppendFormat("  SpatializerPluginName (current): {0}\n", AudioSettings.GetSpatializerPluginName());
    sb.AppendLine  ("  SpatializerPluginNames (all available):");
    foreach (var name in AudioSettings.GetSpatializerPluginName())
      sb.AppendFormat("    {0}\n", name);

    Debug.Log(sb);
  }

  void _InspectAudio() {
    float[] buff = new float[2 ^ 8];

    // 音频片段的控制器
    //source.bypassEffects = true;
    //source.bypassReverbZones = false;
    //source.Play();
    //audio.PlayDelayed();
    //audio.PlayClipAtPoint();
    //audio.PlayOneShot();
    //source.Pause();
    //source.UnPause();
    //source.Stop();
    //source.GetSpectrumData(buff, 0, FFTWindow.Hanning);  // 获取频谱(为啥不是二维频谱图??

    sb.Length = 0;
    sb.AppendLine("[AudioSource]");
    sb.AppendFormat("  isPlaying: {0}\n", source.isPlaying);
    sb.AppendFormat("  isVirtual: {0}\n", source.isVirtual);
    sb.AppendFormat("  loop: {0}\n", source.loop);
    sb.AppendFormat("  ignoreListenerVolume: {0}\n", source.ignoreListenerVolume);
    sb.AppendFormat("  playOnAwake: {0}\n", source.playOnAwake);
    sb.AppendFormat("  ignoreListenerPause: {0}\n", source.ignoreListenerPause);
    sb.AppendFormat("  velocityUpdateMode: {0}\n", source.velocityUpdateMode);
    sb.AppendFormat("  panStereo: {0}\n", source.panStereo);
    sb.AppendFormat("  spatialBlend: {0}\n", source.spatialBlend);
    sb.AppendFormat("  spatialize: {0}\n", source.spatialize);
    sb.AppendFormat("  spatializePostEffects: {0}\n", source.spatializePostEffects);
    sb.AppendFormat("  reverbZoneMix: {0}\n", source.reverbZoneMix);
    sb.AppendFormat("  bypassEffects: {0}\n", source.bypassEffects);
    sb.AppendFormat("  bypassListenerEffects: {0}\n", source.bypassListenerEffects);
    sb.AppendFormat("  bypassReverbZones: {0}\n", source.bypassReverbZones);
    sb.AppendFormat("  dopplerLevel: {0}\n", source.dopplerLevel);
    sb.AppendFormat("  spread: {0}\n", source.spread);
    sb.AppendFormat("  priority: {0}\n", source.priority);
    sb.AppendFormat("  mute: {0}\n", source.mute);
    sb.AppendFormat("  minDistance: {0}\n", source.minDistance);
    sb.AppendFormat("  maxDistance: {0}\n", source.maxDistance);
    sb.AppendFormat("  rolloffMode: {0}\n", source.rolloffMode);
    sb.AppendFormat("  outputAudioMixerGroup: {0}\n", source.outputAudioMixerGroup);
    sb.AppendFormat("  time: {0}\n", source.time);
    sb.AppendFormat("  timeSamples: {0}\n", source.timeSamples);
    sb.AppendFormat("  volume: {0}\n", source.volume);
    sb.AppendFormat("  pitch: {0}\n", source.pitch);
    Debug.Log(sb);

    // 所封装的音频片段
    AudioClip clip = source.clip;
    //clip.LoadAudioData();   // 手动控制一些不频繁使用的资源加载, see `preloadAudioData`
    //clip.GetData(buff, 0);  // 读取出samples

    sb.Length = 0;
    sb.AppendLine("[AudioClip]");
    // NOTE: 以下部分选项须在Unity-Assets的Inspector界面里管理
    // SEE: `https://medium.com/double-shot-audio/preload-audio-data-how-unity-decides-which-audio-assets-to-load-to-a-scene-a440a654e7e2`
    sb.AppendFormat("  preloadAudioData: {0}\n", clip.preloadAudioData);
    // SEE: `https://medium.com/double-shot-audio/choosing-the-right-load-type-in-unitys-audio-import-settings-1880a61134c7`
    sb.AppendFormat("  loadType: {0}\n", clip.loadType);
    // SEE: `https://medium.com/double-shot-audio/load-in-background-optimizing-audio-load-times-in-unity-33d3cc04c47e`
    sb.AppendFormat("  loadInBackground: {0}\n", clip.loadInBackground);
    sb.AppendFormat("  loadState: {0}\n", clip.loadState);
    sb.AppendFormat("  ambisonic: {0}\n", clip.ambisonic);
    sb.AppendFormat("  frequency: {0}\n", clip.frequency);
    sb.AppendFormat("  channels: {0}\n", clip.channels);
    sb.AppendFormat("  samples: {0}\n", clip.samples);
    sb.AppendFormat("  length: {0}\n", clip.length);
    Debug.Log(sb);
  }

}
