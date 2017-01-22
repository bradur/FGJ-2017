using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


public enum DialogType
{
    None,
    Fail,
    Success,
    Pause,
    TheEnd
}

public class UIManager : MonoBehaviour {

    public static UIManager main;

    [SerializeField]
    private Text txtScore;

    [SerializeField]
    private Text txtSmokeMessage;

    [SerializeField]
    private List<Image> imgPuffs = new List<Image>();

    [SerializeField]
    private Dialog dialog;

    [SerializeField]
    private FloatingScore floatingScore;

    void Awake()
    {
        main = this;
    }

    public void SetScore(int newScore)
    {
        txtScore.text = newScore.ToString();
    }

    public void ShowScore(int score)
    {
        floatingScore.Show(score);
    }

    void SetSmokeMessage(string newMessage)
    {
        txtSmokeMessage.text = string.Format("\"{0}\"", newMessage);
    }

    public void SetLevel(string message, List<PuffWaveStuct> puffWaveStucts)
    {
        SetSmokeMessage(message);
        ClearPuffs();
        SetPuffs(puffWaveStucts);
    }

    void ClearPuffs()
    {
        foreach(Image image in imgPuffs)
        {
            image.sprite = null;
            image.gameObject.SetActive(false);
        }
    }

    void SetPuffs(List<PuffWaveStuct> puffWaveStucts)
    {
        for(int i = 0; i < puffWaveStucts.Count; i++)
        {
            imgPuffs[i].sprite = puffWaveStucts[i].puffSprite;
            imgPuffs[i].gameObject.SetActive(true);
        }
    }

    public void ShowDialog(DialogType dialogType)
    {
        dialog.Show(dialogType);
    }

    public void HideDialog()
    {
        dialog.Hide();
    }
}