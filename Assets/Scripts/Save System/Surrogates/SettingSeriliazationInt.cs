using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class SettingSeriliazationInt : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var FPS = (int)obj;
        info.AddValue("FPS", FPS);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        var FPS = (int)obj;
        FPS = (int)info.GetValue("FPS", typeof(int));
        obj = FPS;
        return obj;
    }
}
