using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

// Json配置文件通用读写
public class JsonUtil
{
  public static T Load<T>(string filePath)
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
      try { sw.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented)); }
      catch (Exception e) { Debug.LogError(e); }
    }
  }
}