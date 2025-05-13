using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreateAccountPanel : MonoBehaviour
{
    public InputField idInputField;
    public Button checkIDButton;
    public InputField passwordInputField;
    public Button confirmButton;
    public Text messageText;

    private void Start()
    {
        checkIDButton.onClick.AddListener(OnCheckID);
        confirmButton.onClick.AddListener(OnConfirm);
    }

    // ���̵� �ߺ� Ȯ�� ��ư Ŭ�� ��
    private void OnCheckID()
    {
        string id = idInputField.text.Trim();

        if (string.IsNullOrEmpty(id))
        {
            ShowMessage("���̵� �Է����ּ���.");
            return;
        }

        // ���⼭ �����δ� PlayFab DisplayName �ߺ� üũ �� ���� ȣ��
        if (id == "test123") // ���÷� �̹� �����ϴ� ���̵�� ����
        {
            ShowMessage("�̹� �����ϴ� ���̵��Դϴ�.");
        }
        else
        {
            ShowMessage("��� ������ ���̵��Դϴ�.");
        }
    }

    // Ȯ�� ��ư Ŭ�� ��
    private void OnConfirm()
    {
        string id = idInputField.text.Trim();
        string pw = passwordInputField.text.Trim();

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
        {
            ShowMessage("���̵�� ��й�ȣ�� ��� �Է����ּ���.");
            return;
        }

        // TODO: PlayFab�� CustomID + ��й�ȣ ���� ����
        Debug.Log("���̵� ���� �Ϸ�: " + id);
        ShowMessage("���̵� ���� �Ϸ�!");

        // ���� �α��� �г� Ȱ��ȭ, �� �г� ��Ȱ��ȭ ó�� �ʿ�
        // UIManager.Instance.OpenLoginPanel();
    }

    // �޽��� ǥ�� �� 10�� �� �����
    private void ShowMessage(string message)
    {
        StopAllCoroutines();
        messageText.text = message;
        StartCoroutine(HideMessageAfterSeconds(10f));
    }

    private IEnumerator HideMessageAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        messageText.text = "";
    }
}
