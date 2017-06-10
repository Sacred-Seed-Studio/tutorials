using System.Collections;
using UnityEngine;

public class SimpleExample : MonoBehaviour
{
    public User user;
    public Post post;

    void Start()
    {
        StartCoroutine(LoadPost());
        StartCoroutine(LoadUser());
    }

    IEnumerator LoadPost()
    {
        WWW www = new WWW(API.baseURL + "/posts/1");
        yield return www;
        post = JsonUtility.FromJson<Post>(www.text);
        Debug.Log("Post: " + www.text);
    }

    IEnumerator LoadUser()
    {
        WWW www = new WWW(API.baseURL + "/users/1");
        yield return www;
        user = JsonUtility.FromJson<User>(www.text);
        Debug.Log("User: " + www.text);
    }
}