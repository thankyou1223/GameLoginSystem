using UnityEngine;
using UnityEngine.UI;

public class AppleSignInButton : MonoBehaviour
{
    private Button appleButton;

    void Start()
    {
        appleButton = GetComponent<Button>();
        appleButton.onClick.AddListener(OnAppleSignInClick);
    }

    // Apple 로그인 버튼 클릭 시 호출
    void OnAppleSignInClick()
    {
        Debug.Log("Apple 로그인 버튼 클릭됨");

        // 실제 Apple 로그인 SDK 처리 위치
        // ex: AppleLoginManager.Instance.SignIn();
    }
}
