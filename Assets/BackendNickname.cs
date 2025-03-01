using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;
using TMPro;
using I2.Loc;
public class BackendNickname : MonoBehaviour
{
    public GameObject Nickname_logoPanel;
    public TMP_InputField NicknameInput_logo;
    public Text caution;
    public Animator cauani;
    private static readonly int Show = Animator.StringToHash("show");

    private void OnDestroy()
    {
        Nickname_logoPanel = null;
        NicknameInput_logo = null;
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    //입력
    public void WriteString(string name)
    {
        NicknameInput_logo.text = name;
    }

    //닉네임 생성버튼
    public void Bt_CreateNickanme()
    {
        //닉네임이 옳바른지 체크
        if (!CheckispossibleNickname(NicknameInput_logo.text))
        {
            //caution_logo.text = TranslateManager.Instance.GetTranslate("UI/NoSpecialChar");// "닉네임은 한글, 영어, 숫자만 가능합니다.";
            return;
        }

        BackendReturnObject bro = Backend.BMember.CreateNickname(NicknameInput_logo.text);
        if (bro.IsSuccess())
        {
                //Debug.Log("인데" + bro.GetInDate());
            PlayerBackendData.Instance.nickname = NicknameInput_logo.text;
            Nickname_logoPanel.SetActive(false);
            GetComponent<BackendLogin>().Bt_SetClass();
           // PlayerBackendData.Instance.initNewPlayerData();
        }
        else
        {
            switch (bro.GetStatusCode())
            {
                case "409": //중복된 닉네임
                     caution.text = TranslateManager.Instance.GetTranslate("UI/중복닉네임");
                    break;

                case "400": //닉네임에 앞/뒤 공백이 있는 경우
                   caution.text = TranslateManager.Instance.GetTranslate("UI/빈닉네임칸");
                    break;
            }
            cauani.SetTrigger(Show);
        }
    }

    static bool CheckispossibleNickname(string nickname)
    {
        return Regex.IsMatch(nickname, "^[0-9a-zA-Z가-힣]*$");
    }

    public static bool CheckispossibleGuildName(string nickname)
    {
        return Regex.IsMatch(nickname, "^[a-zA-Z가-힣]*$");
    }
}
