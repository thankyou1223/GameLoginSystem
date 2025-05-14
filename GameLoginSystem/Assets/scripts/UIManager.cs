using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    // ��� �г� ����
    public GameObject loginPanel;
    public GameObject signUpPanel;
    public GameObject createIDPanel;
    public GameObject gameStartPanel;
    public GameObject findIDPanel;
    public GameObject findPasswordPanel;

    // �޽��� ��¿� Text (�г� ����)
    public Text messageText;

    // �ڵ� �α��� ���� ���
    public Toggle autoLoginToggle;

    // �α����� ID ����
    private string loggedInID = "";

    void Start()
    {
        InitializePanels();

        // �ڵ� �α��� ó��
        if (PlayerPrefs.GetInt("AutoLogin", 0) == 1 && PlayerPrefs.HasKey("LoginID"))
        {
            loggedInID = PlayerPrefs.GetString("LoginID");
            ShowGameStartPanel();
        }
        else
        {
            ShowLoginPanel();
        }
    }

    void InitializePanels()
    {
        loginPanel.SetActive(false);
        signUpPanel.SetActive(false);
        createIDPanel.SetActive(false);
        gameStartPanel.SetActive(false);
        findIDPanel.SetActive(false);
        findPasswordPanel.SetActive(false);
    }

    public void ShowLoginPanel()
    {
        InitializePanels();
        loginPanel.SetActive(true);
    }

    public void ShowSignUpPanel()
    {
        InitializePanels();
        signUpPanel.SetActive(true);
    }

    public void ShowCreateIDPanel()
    {
        InitializePanels();
        createIDPanel.SetActive(true);
    }

    public void ShowGameStartPanel()
    {
        InitializePanels();
        gameStartPanel.SetActive(true);
        if (!string.IsNullOrEmpty(loggedInID))
            ShowMessage($"ȯ���մϴ�, {loggedInID}��!");
    }

    public void ShowFindIDPanel()
    {
        InitializePanels();
        findIDPanel.SetActive(true);
    }

    public void ShowFindPasswordPanel()
    {
        InitializePanels();
        findPasswordPanel.SetActive(true);
    }

    public void OnLoginSuccess(string loginID)
    {
        loggedInID = loginID;

        // �ڵ� �α��� ����
        if (autoLoginToggle != null && autoLoginToggle.isOn)
        {
            PlayerPrefs.SetInt("AutoLogin", 1);
            PlayerPrefs.SetString("LoginID", loggedInID);
        }
        else
        {
            PlayerPrefs.SetInt("AutoLogin", 0);
            PlayerPrefs.DeleteKey("LoginID");
        }

        ShowGameStartPanel();
    }

    public void OnLogout()
    {
        PlayerPrefs.SetInt("AutoLogin", 0);
        PlayerPrefs.DeleteKey("LoginID");
        loggedInID = "";
        ShowLoginPanel();
    }

    public void OnClickGameStart()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ShowMessage(string msg)
    {
        if (messageText == null) return;

        messageText.text = msg;
        messageText.gameObject.SetActive(true);
        StopAllCoroutines();
        StartCoroutine(HideMessageAfterSeconds(10f));
    }

    IEnumerator HideMessageAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        messageText.text = "";
        messageText.gameObject.SetActive(false);
    }
}
