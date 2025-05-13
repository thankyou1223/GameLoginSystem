using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignUpPanel : MonoBehaviour
{
    public InputField phoneInput;
    public Button checkButton;
    public Button nextButton;
    public Text messageText;

    public GameObject signUpPanel;
    public GameObject createIDPanel; // ���� �г� ����

    private bool isPhoneValid = false;

    void Start()
    {
        nextButton.interactable = false; // ó������ ��Ȱ��ȭ
    }

    // �ߺ� Ȯ�� ��ư Ŭ�� �� ȣ��
    public void OnCheckButtonClick()
    {
        string phone = phoneInput.text.Trim();

        if (!IsValidPhoneNumber(phone))
        {
            ShowMessage("�޴��� ��ȣ ������ �ùٸ��� �ʽ��ϴ�.");
            isPhoneValid = false;
            nextButton.interactable = false;
            return;
        }

        // �ߺ� ���� Ȯ�� (�ӽ� ó�� - ������ �������� Ȯ��)
        if (phone == "01012345678") // ��: �̹� ���Ե� ��ȣ
        {
            ShowMessage("�̹� ���Ե� ��ȣ�Դϴ�.");
            isPhoneValid = false;
            nextButton.interactable = false;
        }
        else
        {
            ShowMessage("��� ������ ��ȣ�Դϴ�.");
            isPhoneValid = true;
            nextButton.interactable = true;
        }
    }

    // ���� ��ư Ŭ�� �� ȣ��
    public void OnNextButtonClick()
    {
        if (isPhoneValid)
        {
            signUpPanel.SetActive(false);
            createIDPanel.SetActive(true);
        }
        else
        {
            ShowMessage("�޴��� ��ȣ�� ���� Ȯ�����ּ���.");
        }
    }

    // �޴��� ��ȣ ��ȿ�� �˻�
    bool IsValidPhoneNumber(string phone)
    {
        return phone.StartsWith("010") && phone.Length == 11;
    }

    // �޽��� ���
    void ShowMessage(string msg)
    {
        messageText.text = msg;
        CancelInvoke("ClearMessage");
        Invoke("ClearMessage", 10f);
    }

    void ClearMessage()
    {
        messageText.text = "";
    }
}
