using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    // �г�
    public GameObject rolePanel; // ����/���� ���� �г�
    public GameObject genderPanel; // ���� ���� �г�
    public GameObject jobPanel; // ���� ���� �г�
    public GameObject detailJobPanel; // ���� ���� �г�

    // �ؽ�Ʈ ���
    public Text messageText;

    // �Ϸ� ��ư
    public Button completeButton;

    // ���� ���� ����
    private string selectedRole = "";
    private string selectedGender = "";
    private string selectedJob = "";

    void Start()
    {
        // �ʱ� ����: ����/���� ���ø� Ȱ��ȭ
        rolePanel.SetActive(true);
        genderPanel.SetActive(false);
        jobPanel.SetActive(false);
        detailJobPanel.SetActive(false);
        completeButton.gameObject.SetActive(false);

        messageText.text = "���� �Ǵ� ������ �������ּ���.";
    }

    // ���� �Ǵ� ���� ����
    public void SelectRole(string role)
    {
        selectedRole = role;
        rolePanel.SetActive(false);
        genderPanel.SetActive(true);
        messageText.text = $"{role}�� �����߽��ϴ�. ������ �������ּ���.";
    }

    // ���� ����
    public void SelectGender(string gender)
    {
        selectedGender = gender;
        genderPanel.SetActive(false);
        jobPanel.SetActive(true);
        messageText.text = $"{gender}�� �����߽��ϴ�. ������ �������ּ���.";
    }

    // ���� ���� (ȸ��, ���� ��)
    public void SelectJob(string job)
    {
        selectedJob = job;
        jobPanel.SetActive(false);
        detailJobPanel.SetActive(true);
        messageText.text = $"{job}�� �����߽��ϴ�. ���� ������ �������ּ���.";
    }

    // ���� ���� ���� (��: ���, ���� ��)
    public void SelectDetailJob(string option)
    {
        messageText.text = $"{selectedRole} - {selectedGender} - {selectedJob} - {option} ���� �Ϸ�!";
        completeButton.gameObject.SetActive(true); // �Ϸ� ��ư Ȱ��ȭ
    }

    // �Ϸ� ��ư Ŭ�� �� ����
    public void CompleteSelection()
    {
        messageText.text = "������ �Ϸ�Ǿ����ϴ�. ���� ȭ������ �̵��մϴ�.";

        // ���� ������ ��ȯ�� ���:
        // SceneManager.LoadScene("NextScene");

        // �Ǵ� ���� �г� ���� (UIManager ��� ��):
        // UIManager.Instance.OpenNextPanel();

        // �Ϸ� ��ư ��Ȱ��ȭ
        completeButton.gameObject.SetActive(false);
    }
}
