using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginPanel : MonoBehaviour
{
    public InputField idInput;
    public InputField pwInput;
    public Text messageText;

    public GameObject loginPanel;
    public GameObject gameStartPanel; // 연결할 게임 시작 패널

    // 로그인 버튼 클릭 시 호출
    public void OnLoginButtonClick()
    {
        string id = idInput.text.Trim();
        string pw = pwInput.text.Trim();

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(pw))
        {
            ShowMessage("아이디와 비밀번호를 모두 입력해주세요.");
            return;
        }

        // 로그인 성공 시 처리 (임시, PlayFab은 나중에 연동)
        if (id == "test" && pw == "1234")
        {
            ShowMessage("로그인 성공!");
            loginPanel.SetActive(false);
            gameStartPanel.SetActive(true);
        }
        else
        {
            ShowMessage("아이디 또는 비밀번호가 잘못되었습니다.");
        }
    }

    // 메시지 출력
    void ShowMessage(string msg)
    {
        messageText.text = msg;
        CancelInvoke("ClearMessage");
        Invoke("ClearMessage", 10f); // 10초 후 메시지 삭제
    }

    void ClearMessage()
    {
        messageText.text = "";
    }
}
