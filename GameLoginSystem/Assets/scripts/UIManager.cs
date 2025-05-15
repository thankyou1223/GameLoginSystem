using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("�г� ����")]
    public GameObject loginPanel;
    public GameObject signUpPanel;
    public GameObject createAccountPanel;
    public GameObject startGamePanel;
    public GameObject findIDPanel;
    public GameObject findPasswordPanel;
    public GameObject roleSelectionPanel;

    [Header("�޽��� ��� �ؽ�Ʈ (�гκ� �ϴ� ��ġ)")]
    public Text loginMessageText;
    public Text signUpMessageText;
    public Text createAccountMessageText;
    public Text startGameMessageText;

    private void Awake()
    {
        // �̱��� ����
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // �ڵ� �α��� ���� Ȯ�� �� ó��
        if (PlayerPrefs.GetInt("AutoLogin", 0) == 1)
        {
            // �ڵ� �α��ε� ����ڶ�� StartGamePanel ����
            OpenStartGamePanel();
        }
        else
        {
            OpenLoginPanel();
        }
    }

    // ��� �г� ��Ȱ��ȭ
    public void CloseAllPanels()
    {
        loginPanel?.SetActive(false);
        signUpPanel?.SetActive(false);
        createAccountPanel?.SetActive(false);
        startGamePanel?.SetActive(false);
        findIDPanel?.SetActive(false);
        findPasswordPanel?.SetActive(false);
        roleSelectionPanel?.SetActive(false);
    }

    // Ư�� �г� ����
    public void OpenPanel(GameObject panel)
    {
        CloseAllPanels();
        if (panel != null) panel.SetActive(true);
    }

    // �гκ� ���� �޼���
    public void OpenLoginPanel() => OpenPanel(loginPanel);
    public void OpenSignUpPanel() => OpenPanel(signUpPanel);
    public void OpenCreateAccountPanel() => OpenPanel(createAccountPanel);
    public void OpenStartGamePanel() => OpenPanel(startGamePanel);
    public void OpenFindIDPanel() => OpenPanel(findIDPanel);
    public void OpenFindPasswordPanel() => OpenPanel(findPasswordPanel);
    public void OpenRoleSelectionPanel() => OpenPanel(roleSelectionPanel);

    // �޽��� ��� ���� �Լ� (10�� �� �����)
    public void ShowMessage(Text targetText, string message)
    {
        if (targetText == null) return;

        StopAllCoroutines(); // ���� �޽��� ��� �ߴ�
        targetText.text = message;
        targetText.gameObject.SetActive(true);
        StartCoroutine(HideMessageAfterDelay(targetText, 10f));
    }

    private IEnumerator HideMessageAfterDelay(Text targetText, float delay)
    {
        yield return new WaitForSeconds(delay);
        targetText.text = "";
        targetText.gameObject.SetActive(false);
    }

    // �ڵ� �α��� ����
    public void SetAutoLogin(bool isEnabled)
    {
        PlayerPrefs.SetInt("AutoLogin", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    // �ڵ� �α��� ���� �� �α��� �гη� ��ȯ
    public void Logout()
    {
        SetAutoLogin(false);
        OpenLoginPanel();
    }

    // ���� �� ��ȯ
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene"); // MainScene���� �� ��ȯ
    }
}
