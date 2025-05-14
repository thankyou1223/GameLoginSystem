using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴 방지
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // ✅ 로그인
    public void Login(string id, string password, Action onSuccess, Action<string> onFailure)
    {
        var request = new LoginWithPlayFabRequest
        {
            Username = id,
            Password = password
        };

        PlayFabClientAPI.LoginWithPlayFab(request,
            result => onSuccess?.Invoke(),
            error => onFailure?.Invoke(error.ErrorMessage));
    }

    // ✅ 회원가입 (아이디/비밀번호 생성)
    public void Register(string id, string password, string phone, Action onSuccess, Action<string> onFailure)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Username = id,
            Password = password,
            RequireBothUsernameAndEmail = false,
            DisplayName = phone // 전화번호는 DisplayName에 저장 (임시 처리)
        };

        PlayFabClientAPI.RegisterPlayFabUser(request,
            result => onSuccess?.Invoke(),
            error => onFailure?.Invoke(error.ErrorMessage));
    }

    // ✅ 자동 로그인
    public void AutoLogin(Action onSuccess, Action<string> onFailure)
    {
        string savedId = PlayerPrefs.GetString("AutoLoginID", "");
        string savedPassword = PlayerPrefs.GetString("AutoLoginPW", "");

        if (!string.IsNullOrEmpty(savedId) && !string.IsNullOrEmpty(savedPassword))
        {
            Login(savedId, savedPassword, onSuccess, onFailure);
        }
        else
        {
            onFailure?.Invoke("자동 로그인 정보가 없습니다.");
        }
    }

    // ✅ 로그아웃
    public void Logout()
    {
        PlayerPrefs.DeleteKey("AutoLoginID");
        PlayerPrefs.DeleteKey("AutoLoginPW");
        PlayFabClientAPI.ForgetAllCredentials(); // 세션 정리
    }

    // ✅ 중복 아이디 확인
    public void CheckDuplicateUsername(string username, Action<bool> onCheckComplete)
    {
        var request = new GetAccountInfoRequest
        {
            Username = username
        };

        PlayFabClientAPI.GetAccountInfo(request,
            result => onCheckComplete(false),  // 이미 존재하는 아이디
            error => onCheckComplete(true));  // 사용 가능 (에러는 미존재)
    }

    // ✅ 아이디 찾기 기능 (전화번호 기준)
    public void FindIDByPhone(string phone, Action<string> onFound, Action<string> onFailure)
    {
        // PlayFab은 직접적으로 전화번호로 계정을 찾을 수 없음.
        // 서버 클라우드 스크립트 또는 DisplayName(전화번호) 기반 사용자 필터링 필요 (생략 또는 추가 개발 필요)
        onFailure?.Invoke("전화번호 기반 ID 찾기는 클라이언트에서 직접 지원되지 않습니다.");
    }

    // ✅ 비밀번호 재설정은 PlayFab에서는 이메일 기반 처리만 지원함
}
