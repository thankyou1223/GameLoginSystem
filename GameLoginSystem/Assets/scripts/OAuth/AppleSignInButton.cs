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

    // Apple �α��� ��ư Ŭ�� �� ȣ��
    void OnAppleSignInClick()
    {
        Debug.Log("Apple �α��� ��ư Ŭ����");

        // ���� Apple �α��� SDK ó�� ��ġ
        // ex: AppleLoginManager.Instance.SignIn();
    }
}
