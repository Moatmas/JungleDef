    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using PlayFab;
    using PlayFab.ClientModels;
    using System;
    using UnityEngine.SceneManagement;

    public class AuthenticationManager : MonoBehaviour
    {
        public GameObject loginPanel;
        public GameObject menuPanel;
        public GameObject gamePanel;

        public GameObject signupPanel;
        public GameObject forgetPasswordPanel;
        public GameObject notificationPanel;
        public GameObject optionPanel;

        public TMP_InputField loginEmailField;
        public TMP_InputField loginPasswordField;
        public TMP_InputField signupEmailField;
        public TMP_InputField signupPasswordField;
        public TMP_InputField confirmPasswordField;
        public TMP_InputField signupUserNameField;
        public TMP_InputField forgetEmailField;

        public TextMeshProUGUI notifTitleText;
        public TextMeshProUGUI notifMessageText;

        public Toggle rememberMeToggle;

        private void Start()
        {
            // Initialize PlayFab SDK
            PlayFabSettings.TitleId = "D2E7B";
        }

        public void OpenLoginPanel()
        {
            loginPanel.SetActive(true);
            signupPanel.SetActive(false);
            forgetPasswordPanel.SetActive(false);
            menuPanel.SetActive(false);
            gamePanel.SetActive(false);
            optionPanel.SetActive(false);
            ResetInputFields();

        }
        public void OpenSettingPanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(false);
            forgetPasswordPanel.SetActive(false);
            menuPanel.SetActive(true);
            gamePanel.SetActive(false);
            optionPanel.SetActive(true);
            ResetInputFields();

        }
        public void OpenGamePanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(false);
            forgetPasswordPanel.SetActive(false);
            menuPanel.SetActive(false);
            gamePanel.SetActive(true);
            ResetInputFields();
        }
        public void OpenMenuPanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(false);
            forgetPasswordPanel.SetActive(false);
            menuPanel.SetActive(true);
            gamePanel.SetActive(false);
            optionPanel.SetActive(false);
            ResetInputFields();
        }

        public void OpenSignupPanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(true);
            forgetPasswordPanel.SetActive(false);
            menuPanel.SetActive(false);
            gamePanel.SetActive(false);
            ResetInputFields();

        }

        public void OpenForgetPasswordPanel()
        {
            loginPanel.SetActive(false);
            signupPanel.SetActive(false);
            forgetPasswordPanel.SetActive(true);
            menuPanel.SetActive(false);
            gamePanel.SetActive(false);
            ResetInputFields();

        }

       public void LoginUser()
{
    string email = loginEmailField.text.Trim();
    string password = loginPasswordField.text.Trim();

    if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
    {
        ShowNotification("Erreur", "Champs vides! Veuillez saisir tous les détails");
        return;
    }

    if (!IsValidEmail(email))
    {
        ShowNotification("Erreur", "Format d'email invalide! Veuillez saisir une adresse email valide.");
        return;
    }

    var request = new LoginWithEmailAddressRequest { Email = email, Password = password };
    PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
}

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Utilisateur connecté avec succès : " + result.PlayFabId);
        OpenMenuPanel(); // Open the menu panel upon successful login
        ResetInputFields();
        SceneManager.LoadSceneAsync("MenuPreGame");
    }

   private void OnLoginFailure(PlayFabError error)
{
    if (error.Error == PlayFabErrorCode.AccountNotFound)
    {
        ShowNotification("Erreur", "Utilisateur non trouvé. Veuillez vérifier votre email et votre mot de passe.");
        ResetInputFields();
    }
    else if (error.ErrorMessage == "Invalid email address or password")
    {
        ShowNotification("Erreur", "Adresse email ou mot de passe incorrect.");
        ResetInputFields();
    }
    else
    {
        string errorMessage = "Erreur de connexion : " + error.ErrorMessage;
        Debug.LogError(errorMessage);
        ShowNotification("Erreur", "Erreur de connexion. Veuillez réessayer.");
        ResetInputFields();
    }
}

private void ResetInputFields()
    {
        // Réinitialiser tous les champs d'entrée à une chaîne vide
        loginEmailField.text = "";
        loginPasswordField.text = "";
        signupEmailField.text = "";
        signupPasswordField.text = "";
        confirmPasswordField.text = "";
        signupUserNameField.text = "";
        forgetEmailField.text = "";
    }


    public void SignupUser()
    {
        string email = signupEmailField.text.Trim();
        string password = signupPasswordField.text.Trim();
        string confirmPassword = confirmPasswordField.text.Trim();
        string userName = signupUserNameField.text.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(userName))
        {
            ShowNotification("Erreur", "Champs vides! Veuillez saisir tous les détails");
            return;
        }
        if (!IsValidEmail(email))
        {
            ShowNotification("Error", "Invalid email format! Please enter a valid email address");
            return;
        }

        if (password.Length < 6)
        {
            ShowNotification("Erreur", "Le mot de passe doit faire au moins 6 caractères !");
            return;
        }

        if (password.Length > 100)
        {
            ShowNotification("Erreur", "Le mot de passe ne peut pas dépasser 100 caractères !");
            return;
        }

        if (password != confirmPassword)
        {
            ShowNotification("Erreur", "Les mots de passe ne correspondent pas !");
            return;
        }

        Debug.Log("Adresse email : " + email);
        Debug.Log("Mot de passe : " + password);
        Debug.Log("Nom d'utilisateur : " + userName);

        // Proceed with registration
        var registerRequest = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = password,
            Username = userName
        };

        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnSignupSuccess, OnSignupFailure);
    }


    private void OnError(PlayFabError error)
    {
        Debug.LogError("Une erreur s'est produite : " + error.ErrorMessage);
    }


        private void OnSignupSuccess(RegisterPlayFabUserResult result)
        {
            Debug.Log("Utilisateur enregistré avec succès : " + result.PlayFabId);
            OpenLoginPanel();
            ShowNotification("Succès", "L'enregistrement de l'utilisateur a été effectué avec succès!");
        }

        private void OnSignupFailure(PlayFabError error)
{
    if (error.Error == PlayFabErrorCode.EmailAddressNotAvailable)
    {
        ShowNotification("Erreur", "L'adresse email est déjà associée à un compte. Veuillez en choisir une autre.");
    }
    else if (error.Error == PlayFabErrorCode.UsernameNotAvailable)
    {
        ShowNotification("Erreur", "Ce nom d'utilisateur est déjà pris. Veuillez en choisir un autre.");
    }
    else
    {
        Debug.LogError("Erreur d'inscription : " + error.ErrorMessage);
        ShowNotification("Erreur", "Erreur d'inscription. Veuillez réessayer.");
    }
}


        public void ForgetPassword()
        {
            string email = forgetEmailField.text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                ShowNotification("Erreur", "Email oublié vide");
                return;
            }

            var request = new SendAccountRecoveryEmailRequest { Email = email, TitleId = PlayFabSettings.TitleId };
            PlayFabClientAPI.SendAccountRecoveryEmail(request, OnForgetPasswordSuccess, OnForgetPasswordFailure);
        }

        private void OnForgetPasswordSuccess(SendAccountRecoveryEmailResult result)
        {
            Debug.Log("Email de récupération de mot de passe envoyé avec succès");
            ShowNotification("Succès", "Un email de récupération de mot de passe a été envoyé à votre adresse email.");
        }

        private void OnForgetPasswordFailure(PlayFabError error)
        {
            Debug.LogError("Erreur lors de l'envoi de l'email de récupération de mot de passe : " + error.ErrorMessage);
            ShowNotification("Erreur", "Erreur lors de l'envoi de l'email de récupération de mot de passe. Veuillez réessayer.");
        }

        private void ShowNotification(string title, string message)
        {
            notifTitleText.text = title;
            notifMessageText.text = message;
            notificationPanel.SetActive(true);
        }

        public void CloseNotificationPanel()
        {
            notifTitleText.text = "";
            notifMessageText.text = "";
            notificationPanel.SetActive(false);
        }
        private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    
    }
