using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FindIDPanel : MonoBehaviour
{
    public InputField phoneInput;        // 휴대폰 번호 입력 필드
    public Text foundIDText;             // 찾은 아이디 출력 텍스트
    public Text messageText;             // 하단 메시지 텍스트
    public GameObject loginPanel;        // 로그인 패널
    public GameObject findIDPanel;       // 이 패널 자신

    private Coroutine messageCoroutine;

    // 아이디 찾기 버튼 클릭 시
    public void OnClickFindID()
    {
        string phone = phoneInput.text;

        if (string.IsNullOrEmpty(phone))
        {
            ShowMessage("휴대폰 번호를 입력하세요.");
            return;
        }

        // 예시: 번호가 "01012345678"이면 아이디 "User1234"로 고정
        if (phone == "01012345678")
        {
            foundIDText.text = "찾은 아이디: User1234";
            ShowMessage("아이디를 성공적으로 찾았습니다.");
        }
        else
        {
            foundIDText.text = "";
            ShowMessage("일치하는 아이디가 없습니다.");
        }
    }

    // 결과 지우기 버튼 클릭 시
    public void OnClickClear()
    {
        foundIDText.text = "";
    }

    // 뒤로 가기 버튼 클릭 시 로그인 패널로
    public void OnClickBack()
    {
        findIDPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    // 메시지 표시 함수 (10초 후 자동 삭제)
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
