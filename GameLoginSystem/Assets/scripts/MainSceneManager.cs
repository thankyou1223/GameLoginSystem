using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public Text welcomeText;
    public Button logoutButton;

    private void Start()
    {
        // PlayerPrefs���� �α��� ID ��������
        string loginID = PlayerPrefs.GetString("LoginID", "�����");

        // ȯ�� �޽��� ���
        welcomeText.text = $"ȯ���մϴ�, {loginID}��!";

        // �α׾ƿ� ��ư �̺�Ʈ ���
        logoutButton.onClick.AddListener(OnLogout);
    }

    private void OnLogout()
    {
        // �ڵ� �α��� ���� ����
        PlayerPrefs.DeleteKey("AutoLogin");
        PlayerPrefs.DeleteKey("LoginID");

        // LoginScene(�α��� ȭ�� ��)���� ��ȯ
        SceneManager.LoadScene("LoginScene");
    }

    private void OnStartGame()
    {
        // MainScene ���� �� ��ȯ
        SceneManager.LoadScene("MainScene");
    }

}
