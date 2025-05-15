using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    // 패널
    public GameObject rolePanel; // 유저/빌런 선택 패널
    public GameObject genderPanel; // 성별 선택 패널
    public GameObject jobPanel; // 직업 선택 패널
    public GameObject detailJobPanel; // 세부 직업 패널

    // 텍스트 출력
    public Text messageText;

    // 완료 버튼
    public Button completeButton;

    // 선택 정보 저장
    private string selectedRole = "";
    private string selectedGender = "";
    private string selectedJob = "";

    void Start()
    {
        // 초기 설정: 유저/빌런 선택만 활성화
        rolePanel.SetActive(true);
        genderPanel.SetActive(false);
        jobPanel.SetActive(false);
        detailJobPanel.SetActive(false);
        completeButton.gameObject.SetActive(false);

        messageText.text = "유저 또는 빌런을 선택해주세요.";
    }

    // 유저 또는 빌런 선택
    public void SelectRole(string role)
    {
        selectedRole = role;
        rolePanel.SetActive(false);
        genderPanel.SetActive(true);
        messageText.text = $"{role}를 선택했습니다. 성별을 선택해주세요.";
    }

    // 성별 선택
    public void SelectGender(string gender)
    {
        selectedGender = gender;
        genderPanel.SetActive(false);
        jobPanel.SetActive(true);
        messageText.text = $"{gender}를 선택했습니다. 직업을 선택해주세요.";
    }

    // 직업 선택 (회사, 연인 등)
    public void SelectJob(string job)
    {
        selectedJob = job;
        jobPanel.SetActive(false);
        detailJobPanel.SetActive(true);
        messageText.text = $"{job}를 선택했습니다. 세부 직급을 선택해주세요.";
    }

    // 세부 직업 선택 (예: 사원, 주임 등)
    public void SelectDetailJob(string option)
    {
        messageText.text = $"{selectedRole} - {selectedGender} - {selectedJob} - {option} 선택 완료!";
        completeButton.gameObject.SetActive(true); // 완료 버튼 활성화
    }

    // 완료 버튼 클릭 시 실행
    public void CompleteSelection()
    {
        messageText.text = "선택이 완료되었습니다. 다음 화면으로 이동합니다.";

        // 다음 씬으로 전환할 경우:
        // SceneManager.LoadScene("NextScene");

        // 또는 다음 패널 오픈 (UIManager 사용 시):
        // UIManager.Instance.OpenNextPanel();

        // 완료 버튼 비활성화
        completeButton.gameObject.SetActive(false);
    }
}
