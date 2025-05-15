using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("패널 참조")]
    public GameObject loginPanel;
    public GameObject signUpPanel;
    public GameObject createAccountPanel;
    public GameObject startGamePanel;
    public GameObject findIDPanel;
    public GameObject findPasswordPanel;
    public GameObject roleSelectionPanel;

    [Header("메시지 출력 텍스트 (패널별 하단 위치)")]
    public Text loginMessageText;
    public Text signUpMessageText;
    public Text createAccountMessageText;
    public Text startGameMessageText;

    private void Awake()
    {
        // 싱글턴 패턴
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 유지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // 자동 로그인 여부 확인 후 처리
        if (PlayerPrefs.GetInt("AutoLogin", 0) == 1)
        {
            // 자동 로그인된 사용자라면 StartGamePanel 열기
            OpenStartGamePanel();
        }
        else
        {
            OpenLoginPanel();
        }
    }

    // 모든 패널 비활성화
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

    // 특정 패널 열기
    public void OpenPanel(GameObject panel)
    {
        CloseAllPanels();
        if (panel != null) panel.SetActive(true);
    }

    // 패널별 헬퍼 메서드
    public void OpenLoginPanel() => OpenPanel(loginPanel);
    public void OpenSignUpPanel() => OpenPanel(signUpPanel);
    public void OpenCreateAccountPanel() => OpenPanel(createAccountPanel);
    public void OpenStartGamePanel() => OpenPanel(startGamePanel);
    public void OpenFindIDPanel() => OpenPanel(findIDPanel);
    public void OpenFindPasswordPanel() => OpenPanel(findPasswordPanel);
    public void OpenRoleSelectionPanel() => OpenPanel(roleSelectionPanel);

    // 메시지 출력 공통 함수 (10초 후 사라짐)
    public void ShowMessage(Text targetText, string message)
    {
        if (targetText == null) return;

        StopAllCoroutines(); // 기존 메시지 출력 중단
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

    // 자동 로그인 저장
    public void SetAutoLogin(bool isEnabled)
    {
        PlayerPrefs.SetInt("AutoLogin", isEnabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    // 자동 로그인 해제 및 로그인 패널로 전환
    public void Logout()
    {
        SetAutoLogin(false);
        OpenLoginPanel();
    }

    // 메인 씬 전환
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene"); // MainScene으로 씬 전환
    }
}
