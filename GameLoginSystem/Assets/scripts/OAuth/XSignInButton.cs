using UnityEngine;
using UnityEngine.UI;

public class XSignInButton : MonoBehaviour
{
    private Button xButton;

    void Start()
    {
        xButton = GetComponent<Button>();
        xButton.onClick.AddListener(OnXSignInClick);
    }

    // X 로그인 버튼 클릭 시
    void OnXSignInClick()
    {
        Debug.Log("X (Twitter) 로그인 버튼 클릭됨");

        // 실제 OAuth 연동 처리 위치
        // 예: XLoginManager.Instance.SignIn();
    }
}
