using UnityEngine;
using UnityEngine.UI;

public class GoogleSignInButton : MonoBehaviour
{
    private Button googleButton;

    void Start()
    {
        googleButton = GetComponent<Button>();
        googleButton.onClick.AddListener(OnGoogleSignInClick);
    }

    // Google 로그인 버튼 클릭 시 호출
    void OnGoogleSignInClick()
    {
        Debug.Log("Google 로그인 버튼 클릭됨");

        // 여기에서 Google OAuth SDK 연동 기능 구현 예정
        // ex: GoogleSignInHelper.SignIn();
    }
}
