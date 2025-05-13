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

    // Google �α��� ��ư Ŭ�� �� ȣ��
    void OnGoogleSignInClick()
    {
        Debug.Log("Google �α��� ��ư Ŭ����");

        // ���⿡�� Google OAuth SDK ���� ��� ���� ����
        // ex: GoogleSignInHelper.SignIn();
    }
}
