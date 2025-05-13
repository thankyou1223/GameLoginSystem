using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public Text welcomeText;
    public Button logoutButton;

    private void Start()
    {
        // PlayerPrefs에서 로그인 ID 가져오기
        string loginID = PlayerPrefs.GetString("LoginID", "사용자");

        // 환영 메시지 출력
        welcomeText.text = $"환영합니다, {loginID}님!";

        // 로그아웃 버튼 이벤트 등록
        logoutButton.onClick.AddListener(OnLogout);
    }

    private void OnLogout()
    {
        // 자동 로그인 정보 삭제
        PlayerPrefs.DeleteKey("AutoLogin");
        PlayerPrefs.DeleteKey("LoginID");

        // LoginScene(로그인 화면 씬)으로 전환
        SceneManager.LoadScene("LoginScene");
    }

    private void OnStartGame()
    {
        // MainScene 으로 씬 전환
        SceneManager.LoadScene("MainScene");
    }

}
