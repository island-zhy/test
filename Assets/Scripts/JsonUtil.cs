using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

// Json配置文件通用读写
public class JsonUtil<T>
{
  public static T Load(string filePath)
  {
    using (StreamReader sr = new StreamReader(filePath))
    {
      try { return JsonConvert.DeserializeObject<T>(sr.ReadToEnd()); }
      catch (Exception e) { Debug.LogError(e); }
    }
    return default(T);  // should never reach
  }
  public static void Save(string filePath, object data)
  {
    using (StreamWriter sw = new StreamWriter(filePath))
    {
      try { sw.WriteLine(JsonConvert.SerializeObject(data)); }
      catch (Exception e) { Debug.LogError(e); }
    }
  }
}