using UnityEngine;

public class JsonHelper
{
    public static T[] FromJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        JsonArrayWrapper<T> wrapper = JsonUtility.FromJson<JsonArrayWrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class JsonArrayWrapper<T>
    {
        public T[] array;
    }
}