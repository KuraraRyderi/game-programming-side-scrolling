using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Collections;

[Serializable]
public class SignUpData
{
    public string email;
    public string password;
    public string createDate;
}

public class SignUP : MonoBehaviour
{
    public TMP_InputField EmailInput;
    public TMP_InputField PasswordInput;
    public TMP_InputField PasswordAgainInput;
    public Button submitButton;

    private const string signupUrl = "https://binusgat.rf.gd/unity-api-test/api/auth/signup.php";

    private void Start()
    {
        submitButton.onClick.AddListener(OnSubmit);
    }

    void OnSubmit()
    {
        if (PasswordInput.text != PasswordAgainInput.text)
        {
            Debug.LogError("Passwords do not match!");
            return;
        }

        SignUpData data = new SignUpData
        {
            email = EmailInput.text,
            password = PasswordInput.text,

            createDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss")
        };

        string jsonData = JsonUtility.ToJson(data);
        //Debug.Log("Sending JSON:\n" + jsonData);

        StartCoroutine(SendingSignUp(jsonData));



    }

    IEnumerator SendingSignUp(string json)
    {
        UnityWebRequest request = new UnityWebRequest(signupUrl, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);


        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");



        yield return request.SendWebRequest();


    }
}
