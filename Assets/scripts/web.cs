using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web : MonoBehaviour
{
    string URL = "http://www.fben.colexio-karbo.com/20-21/juegoMazmorra/puntos.php";
    public string[] usersData;
    IEnumerator Start()
    {
        WWW user = new WWW(URL);
        yield return user;
        string usersDataString = user.text;
        usersData = usersDataString.Split(';');
        print(GetValueData(usersData[0], "nombre:"));
    }
    string GetValueData(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }


        return value;
    }


}
