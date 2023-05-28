using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using static Conversation;

public class QuestionGenerator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [Space]
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _socialPointsText;
    [SerializeField] private TextMeshProUGUI _politicPointsText;
    [Space]
    [SerializeField] private Conversation _startConversation;

    private List<Dialog> _conversation;
    private Dialog _currentDialog;
    private int _lastIndex = -1;

    private void Awake()
    {
        _conversation = _startConversation.dialogs;
    }

    public void GenerateQuestion()
    {
        var index = Random.Range(0, _conversation.Count);
        while (_lastIndex == index)
        {
            index = Random.Range(0, _conversation.Count);
        }
        _lastIndex = index;
        _currentDialog = _conversation[index];
        _text.text = _currentDialog.Question;
    }

    public void Accept()
    {
        AcceptAnswer(_currentDialog.PositiveConsiquence, _currentDialog.PositiveDialogs);
    }

    public void Decline()
    {
        AcceptAnswer(_currentDialog.NegativeConsiquence, _currentDialog.NegativeDialogs);
    }

    private void AcceptAnswer(List<Consiquence> consiquences, Conversation conversation)
    {
        foreach (var consiquence in consiquences)
        {
            ChangeValue(consiquence.Type, consiquence.Amount);
        }
        if (conversation != null)
        {
            _conversation.Concat(conversation.dialogs);
            _conversation.Remove(_currentDialog);
        }
        GenerateQuestion();
    }

    public void ChangeValue(Data.Type type, int value)
    {
        switch (type)
        {
            case Data.Type.SocialRating:
                Data.Instance.SocialRating += value;
                _socialPointsText.text = Data.Instance.SocialRating.ToString();
                break;
            case Data.Type.PoliticPoint:
                Data.Instance.PoliticPoint += value;
                _politicPointsText.text = Data.Instance.PoliticPoint.ToString();
                break;
            case Data.Type.Money:
                Data.Instance.Money += value;
                _moneyText.text = Data.Instance.Money.ToString();
                break;
        }
    }
}