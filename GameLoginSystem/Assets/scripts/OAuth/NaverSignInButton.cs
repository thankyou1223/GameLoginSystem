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

    // Naver �α��� ��ư Ŭ�� ��
    void OnNaverSignInClick()
    {
        Debug.Log("Naver �α��� ��ư Ŭ����");

        // ���� OAuth ���� ó�� ��ġ
        // ��: NaverLoginManager.Instance.SignIn();
    }
}
