using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class ExportingData : MonoBehaviour
{
    public Post post;

    void Start()
    {
        StartCoroutine(CreatePost());
    }

    IEnumerator CreatePost()
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        headers.Add("Content-Type", "application/json");

        byte[] postData = Encoding.ASCII.GetBytes(JsonUtility.ToJson(post));

        WWW www = new WWW(API.baseURL + "/posts", postData, headers);

        yield return www;

        Debug.Log("Created a Post: " + www.text);
        post = JsonUtility.FromJson<Post>(www.text);
    }
}