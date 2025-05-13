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
    public GameObject createIDPanel; // 다음 패널 연결

    private bool isPhoneValid = false;

    void Start()
    {
        nextButton.interactable = false; // 처음에는 비활성화
    }

    // 중복 확인 버튼 클릭 시 호출
    public void OnCheckButtonClick()
    {
        string phone = phoneInput.text.Trim();

        if (!IsValidPhoneNumber(phone))
        {
            ShowMessage("휴대폰 번호 형식이 올바르지 않습니다.");
            isPhoneValid = false;
            nextButton.interactable = false;
            return;
        }

        // 중복 여부 확인 (임시 처리 - 실제는 서버에서 확인)
        if (phone == "01012345678") // 예: 이미 가입된 번호
        {
            ShowMessage("이미 가입된 번호입니다.");
            isPhoneValid = false;
            nextButton.interactable = false;
        }
        else
        {
            ShowMessage("사용 가능한 번호입니다.");
            isPhoneValid = true;
            nextButton.interactable = true;
        }
    }

    // 다음 버튼 클릭 시 호출
    public void OnNextButtonClick()
    {
        if (isPhoneValid)
        {
            signUpPanel.SetActive(false);
            createIDPanel.SetActive(true);
        }
        else
        {
            ShowMessage("휴대폰 번호를 먼저 확인해주세요.");
        }
    }

    // 휴대폰 번호 유효성 검사
    bool IsValidPhoneNumber(string phone)
    {
        return phone.StartsWith("010") && phone.Length == 11;
    }

    // 메시지 출력
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
