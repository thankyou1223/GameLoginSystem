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

    // Kakao �α��� ��ư Ŭ�� �� ȣ��
    void OnKakaoSignInClick()
    {
        Debug.Log("īī�� �α��� ��ư Ŭ����");

        // ���� Kakao SDK �α��� ó�� �κ� ���⿡ ���� ����
        // ex: KakaoLoginManager.Instance.SignIn();
    }
}
