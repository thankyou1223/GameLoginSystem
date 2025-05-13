using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGamePanel : MonoBehaviour
{
    public Text welcomeText;
    public Button startGameButton;
    public Button logoutButton;

    private string loginID;

    private void Start()
    {
        startGameButton.onClick.AddListener(OnStartGame);
        logoutButton.onClick.AddListener(OnLogout);
    }

    // �α��� �� ����� ID�� �޾� ȯ�� �޽��� ����
    public void SetWelcomeMessage(string id)
    {
        loginID = id;
        welcomeText.text = $"ȯ���մϴ�, {id}��!";
    }

    // ���� ���� ��ư Ŭ�� �� ���� ������ �̵�
    private void OnStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // �α׾ƿ� ��ư Ŭ�� ��
    private void OnLogout()
    {
        PlayerPrefs.DeleteKey("AutoLogin");
        PlayerPrefs.DeleteKey("LoginID");

        // �α��� �гη� ��ȯ
        UIManager.Instance.OpenLoginPanel();

        // ���� �г� ��Ȱ��ȭ
        gameObject.SetActive(false);
    }
}
