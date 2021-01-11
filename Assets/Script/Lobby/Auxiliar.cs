using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Auxiliar : MonoBehaviour
{
    public static Auxiliar instance = null;
    // private List<string> listNames = new List<string>();
    private void Start() {
        if(instance==null)
        {
            instance = this;
        }
    }

    [SerializeField] private NetworkManagerLobby networkManager;
    [SerializeField] InputField inputField;
    [SerializeField] Text Display;
    public static string playerName;


    public void List(string str)
    {
        Display.text = str;
    }

    public void Host()
    {
        if (string.IsNullOrEmpty(inputField.text)) return;
        playerName = inputField.text;
        networkManager.StartHost();
    }

    public void Join()
    {
        if (string.IsNullOrEmpty(inputField.text)) return;
        playerName = inputField.text;
        networkManager.networkAddress = "localhost";
        networkManager.StartClient();
    }
}