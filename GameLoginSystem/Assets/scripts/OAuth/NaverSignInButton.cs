using UnityEngine;
using UnityEngine.UI;

public class NaverSignInButton : MonoBehaviour
{
    private Button naverButton;

    void Start()
    {
        naverButton = GetComponent<Button>();
        naverButton.onClick.AddListener(OnNaverSignInClick);
    }

    // Naver 로그인 버튼 클릭 시
    void OnNaverSignInClick()
    {
        Debug.Log("Naver 로그인 버튼 클릭됨");

        // 실제 OAuth 연동 처리 위치
        // 예: NaverLoginManager.Instance.SignIn();
    }
}
