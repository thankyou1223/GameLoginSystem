using UnityEngine;
using UnityEngine.UI;

public class KakaoSignInButton : MonoBehaviour
{
    private Button kakaoButton;

    void Start()
    {
        kakaoButton = GetComponent<Button>();
        kakaoButton.onClick.AddListener(OnKakaoSignInClick);
    }

    // Kakao 로그인 버튼 클릭 시 호출
    void OnKakaoSignInClick()
    {
        Debug.Log("카카오 로그인 버튼 클릭됨");

        // 실제 Kakao SDK 로그인 처리 부분 여기에 연결 예정
        // ex: KakaoLoginManager.Instance.SignIn();
    }
}
