using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FindPasswordPanel : MonoBehaviour
{
    public InputField idInput;           // 아이디 입력 필드
    public InputField phoneInput;        // 휴대폰 번호 입력 필드
    public Text foundPasswordText;       // 찾은 비밀번호 표시 텍스트
    public Text messageText;             // 하단 메시지 텍스트
    public GameObject loginPanel;        // 로그인 패널
    public GameObject findPasswordPanel; // 이 패널 자신

    private Coroutine messageCoroutine;

    // 비밀번호 찾기 버튼 클릭
    public void OnClickFindPassword()
    {
        string id = idInput.text;
        string phone = phoneInput.text;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(phone))
        {
            ShowMessage("아이디와 휴대폰 번호를 모두 입력하세요.");
            return;
        }

        // 예시 조건: 아이디가 "User1234"이고 번호가 "01012345678"
        if (id == "User1234" && phone == "01012345678")
        {
            foundPasswordText.text = "찾은 비밀번호: Pass5678";
            ShowMessage("비밀번호를 성공적으로 찾았습니다.");
        }
        else
        {
            foundPasswordText.text = "";
            ShowMessage("일치하는 비밀번호 정보가 없습니다.");
        }
    }

    // 결과 지우기 버튼 클릭
    public void OnClickClear()
    {
        foundPasswordText.text = "";
    }

    // 뒤로 가기 버튼 클릭
    public void OnClickBack()
    {
        findPasswordPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    // 메시지 표시 함수
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
