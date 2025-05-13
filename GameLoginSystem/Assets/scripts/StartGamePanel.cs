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

    // 로그인 후 사용자 ID를 받아 환영 메시지 설정
    public void SetWelcomeMessage(string id)
    {
        loginID = id;
        welcomeText.text = $"환영합니다, {id}님!";
    }

    // 게임 시작 버튼 클릭 시 메인 씬으로 이동
    private void OnStartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    // 로그아웃 버튼 클릭 시
    private void OnLogout()
    {
        PlayerPrefs.DeleteKey("AutoLogin");
        PlayerPrefs.DeleteKey("LoginID");

        // 로그인 패널로 전환
        UIManager.Instance.OpenLoginPanel();

        // 현재 패널 비활성화
        gameObject.SetActive(false);
    }
}
