using UnityEngine;
using System.Collections;

public class HandlingArrays : MonoBehaviour
{
    public User[] users;

    void Start()
    {
        StartCoroutine(LoadUsers());
    }

    IEnumerator LoadUsers()
    {
        WWW www = new WWW(API.baseURL + "/users");
        yield return www;
        users = JsonHelper.FromJsonArray<User>(www.text);
        Debug.Log("Users: " + www.text);
    }
}