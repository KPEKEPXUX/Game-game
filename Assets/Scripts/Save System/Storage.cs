using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

public class Storage
{
    private BinaryFormatter _binaryFormatter;

    private string _filePath;
    public Storage() 
    {
        var _directory = Application.persistentDataPath + "/save";
        _filePath = Application.persistentDataPath + "/save/cool.supermegasecurityfile";
        if (!Directory.Exists(_directory))
        {
            Directory.CreateDirectory(_directory);
        }
        Translator();
    }

    private void Translator()
    {
        _binaryFormatter = new BinaryFormatter();
        var selector = new SurrogateSelector();
        var fpsSurrogate = new SettingSeriliazationInt();
        var resolutionSurrogate = new SettingSeriliazationMassive();
        //var moneySurrogate = new SettingSeriliazationMoney();
        selector.AddSurrogate(typeof(int), new StreamingContext(StreamingContextStates.All), fpsSurrogate);
        selector.AddSurrogate(typeof(Resolution), new StreamingContext(StreamingContextStates.All), resolutionSurrogate);
        //selector.AddSurrogate(typeof(int), new StreamingContext(StreamingContextStates.All), moneySurrogate);
        _binaryFormatter.SurrogateSelector = selector;
    }

    public void Save(object saveData)
    {
        var file = File.Create( _filePath );
        _binaryFormatter.Serialize( file, saveData);
        file.Close();
    }

    public object Load(object loadData)
    {
        if (!File.Exists( _filePath ))
        {
            if (loadData != null)
            {
                Save(loadData);
            }
            return loadData;
        }
        var file = File.Open(_filePath, FileMode.Open);
        var deserFile = _binaryFormatter.Deserialize(file);
        file.Close();
        return deserFile;
    }
}
