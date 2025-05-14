using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FindIDPanel : MonoBehaviour
{
    public InputField phoneInput;        // �޴��� ��ȣ �Է� �ʵ�
    public Text foundIDText;             // ã�� ���̵� ��� �ؽ�Ʈ
    public Text messageText;             // �ϴ� �޽��� �ؽ�Ʈ
    public GameObject loginPanel;        // �α��� �г�
    public GameObject findIDPanel;       // �� �г� �ڽ�

    private Coroutine messageCoroutine;

    // ���̵� ã�� ��ư Ŭ�� ��
    public void OnClickFindID()
    {
        string phone = phoneInput.text;

        if (string.IsNullOrEmpty(phone))
        {
            ShowMessage("�޴��� ��ȣ�� �Է��ϼ���.");
            return;
        }

        // ����: ��ȣ�� "01012345678"�̸� ���̵� "User1234"�� ����
        if (phone == "01012345678")
        {
            foundIDText.text = "ã�� ���̵�: User1234";
            ShowMessage("���̵� ���������� ã�ҽ��ϴ�.");
        }
        else
        {
            foundIDText.text = "";
            ShowMessage("��ġ�ϴ� ���̵� �����ϴ�.");
        }
    }

    // ��� ����� ��ư Ŭ�� ��
    public void OnClickClear()
    {
        foundIDText.text = "";
    }

    // �ڷ� ���� ��ư Ŭ�� �� �α��� �гη�
    public void OnClickBack()
    {
        findIDPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    // �޽��� ǥ�� �Լ� (10�� �� �ڵ� ����)
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
