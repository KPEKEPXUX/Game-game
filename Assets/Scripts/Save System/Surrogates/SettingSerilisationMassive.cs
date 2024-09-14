using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class SettingSeriliazationMassive : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    { 
        var RES = (Resolution)obj;
        info.AddValue("RES", RES);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        var RES = (Resolution)obj;
        RES = (Resolution)info.GetValue("RES", typeof(Resolution));
        obj = RES;
        return obj;
    }
}
