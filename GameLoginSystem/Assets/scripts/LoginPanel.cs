using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginPanel : MonoBehaviour
{
    public InputField idInput;
    public InputField pwInput;
    public Text messageText;

    public GameObject loginPanel;
    public GameObject gameStartPanel; // ������ ���� ���� �г�

    // �α��� ��ư Ŭ�� �� ȣ��
    public void OnLoginButtonClick()
    {
        string id = idInput.text.Trim();
        string pw = pwInput.text.Trim();

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
        {
            ShowMessage("���̵�� ��й�ȣ�� ��� �Է����ּ���.");
            return;
        }

        // �α��� ���� �� ó�� (�ӽ�, PlayFab�� ���߿� ����)
        if (id == "test" && pw == "1234")
        {
            ShowMessage("�α��� ����!");
            loginPanel.SetActive(false);
            gameStartPanel.SetActive(true);
        }
        else
        {
            ShowMessage("���̵� �Ǵ� ��й�ȣ�� �߸��Ǿ����ϴ�.");
        }
    }

    // �޽��� ���
    void ShowMessage(string msg)
    {
        messageText.text = msg;
        CancelInvoke("ClearMessage");
        Invoke("ClearMessage", 10f); // 10�� �� �޽��� ����
    }

    void ClearMessage()
    {
        messageText.text = "";
    }
}
