using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FindPasswordPanel : MonoBehaviour
{
    public InputField idInput;           // ���̵� �Է� �ʵ�
    public InputField phoneInput;        // �޴��� ��ȣ �Է� �ʵ�
    public Text foundPasswordText;       // ã�� ��й�ȣ ǥ�� �ؽ�Ʈ
    public Text messageText;             // �ϴ� �޽��� �ؽ�Ʈ
    public GameObject loginPanel;        // �α��� �г�
    public GameObject findPasswordPanel; // �� �г� �ڽ�

    private Coroutine messageCoroutine;

    // ��й�ȣ ã�� ��ư Ŭ��
    public void OnClickFindPassword()
    {
        string id = idInput.text;
        string phone = phoneInput.text;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(phone))
        {
            ShowMessage("���̵�� �޴��� ��ȣ�� ��� �Է��ϼ���.");
            return;
        }

        // ���� ����: ���̵� "User1234"�̰� ��ȣ�� "01012345678"
        if (id == "User1234" && phone == "01012345678")
        {
            foundPasswordText.text = "ã�� ��й�ȣ: Pass5678";
            ShowMessage("��й�ȣ�� ���������� ã�ҽ��ϴ�.");
        }
        else
        {
            foundPasswordText.text = "";
            ShowMessage("��ġ�ϴ� ��й�ȣ ������ �����ϴ�.");
        }
    }

    // ��� ����� ��ư Ŭ��
    public void OnClickClear()
    {
        foundPasswordText.text = "";
    }

    // �ڷ� ���� ��ư Ŭ��
    public void OnClickBack()
    {
        findPasswordPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    // �޽��� ǥ�� �Լ�
    void ShowMessage(string message)
    {
        if (messageCoroutine != null)
        {
            StopCoroutine(messageCoroutine);
        }

        messageCoroutine = StartCoroutine(ShowMessageCoroutine(message));
    }

    IEnumerator ShowMessageCoroutine(string message)
    {
        messageText.text = message;
        yield return new WaitForSeconds(10f);
        messageText.text = "";
    }
}
