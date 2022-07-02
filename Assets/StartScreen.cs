using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class StartScreen : MonoBehaviour
{

    //pages
    [Header("Pages")]
    public GameObject splash;
    public GameObject registration;
    public GameObject terms;

    //terms agreed checkbox and inputs
    [Header("Registration Form Input Fiels")]
    public InputField familyName;
    public InputField participants;
    public InputField email;
    public Toggle termsAgreed;

    //start button
    [Header("Start Button")]
    public Button startBtn;

    // Start is called before the first frame update
    void Start()
    {
        //check if user already entered details in previous game
        familyName.text = PlayerPrefs.GetString("familyName", "");
        participants.text = PlayerPrefs.GetString("participants", "");
        email.text = PlayerPrefs.GetString("email", "");
        termsAgreed.isOn = PlayerPrefs.HasKey("termsAgreed");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void splashStart()
    {
        splash.SetActive(false);
        registration.SetActive(true);
    }

    public void showTerms()
    {
        registration.SetActive(false);
        terms.SetActive(true);
    }

    public void backToRegistration()
    {
        registration.SetActive(true);
        terms.SetActive(false);
        termsAgreed.isOn = true;
    }

    public void setTermsAgreed(bool state)
    {
        validate();
    }

    bool isEmailVaild()
    {
        var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
        return regex.IsMatch(email.text);
    }

    public void saveDetails()
    {
        PlayerPrefs.SetString("familyName", familyName.text);
        PlayerPrefs.SetString("participants", participants.text);
        PlayerPrefs.SetString("email", email.text);
        PlayerPrefs.SetInt("termsAgreed",1);
    }

    public void validate()
    {
        if (termsAgreed.isOn &&
            familyName.text.Length > 0 &&
            participants.text.Length > 0 &&
            int.Parse(participants.text) > 0 &&
            isEmailVaild())
        {
            //regex email
            startBtn.interactable = true;
        } else
        {
            startBtn.interactable = false;
        }
    }
}
