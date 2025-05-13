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

    // 아이디 중복 확인 버튼 클릭 시
    private void OnCheckID()
    {
        string id = idInputField.text.Trim();

        if (string.IsNullOrEmpty(id))
        {
            ShowMessage("아이디를 입력해주세요.");
            return;
        }

        // 여기서 실제로는 PlayFab DisplayName 중복 체크 등 서버 호출
        if (id == "test123") // 예시로 이미 존재하는 아이디라 가정
        {
            ShowMessage("이미 존재하는 아이디입니다.");
        }
        else
        {
            ShowMessage("사용 가능한 아이디입니다.");
        }
    }

    // 확인 버튼 클릭 시
    private void OnConfirm()
    {
        string id = idInputField.text.Trim();
        string pw = passwordInputField.text.Trim();

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
        {
            ShowMessage("아이디와 비밀번호를 모두 입력해주세요.");
            return;
        }

        // TODO: PlayFab에 CustomID + 비밀번호 저장 연동
        Debug.Log("아이디 생성 완료: " + id);
        ShowMessage("아이디 생성 완료!");

        // 이후 로그인 패널 활성화, 본 패널 비활성화 처리 필요
        // UIManager.Instance.OpenLoginPanel();
    }

    // 메시지 표시 및 10초 후 사라짐
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
