using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject loginPanel;
    public GameObject createAccountPanel;
    public GameObject startGamePanel;

    public StartGamePanel startGamePanelScript;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        createAccountPanel.SetActive(false);
        startGamePanel.SetActive(false);
    }

    public void OpenCreateAccountPanel()
    {
        loginPanel.SetActive(false);
        createAccountPanel.SetActive(true);
        startGamePanel.SetActive(false);
    }

    public void OpenStartGamePanel(string loginID)
    {
        loginPanel.SetActive(false);
        createAccountPanel.SetActive(false);
        startGamePanel.SetActive(true);

        startGamePanelScript.SetWelcomeMessage(loginID);
    }
}
