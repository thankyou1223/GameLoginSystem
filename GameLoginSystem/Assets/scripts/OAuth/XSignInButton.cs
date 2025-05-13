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

    // X �α��� ��ư Ŭ�� ��
    void OnXSignInClick()
    {
        Debug.Log("X (Twitter) �α��� ��ư Ŭ����");

        // ���� OAuth ���� ó�� ��ġ
        // ��: XLoginManager.Instance.SignIn();
    }
}
