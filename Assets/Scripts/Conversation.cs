using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Conversation", menuName = "ScriptableObjects/NewConversation", order = 1)]
public class Conversation : ScriptableObject
{
    public List<Dialog> dialogs = new List<Dialog>();

    [System.Serializable]
    public class Dialog
    {
        public bool IsUnique = false;
        public Sprite Image;
        public Sprite BackBround;
        public string Question;
        public Data.Type PositiveConsequenceType;
        public int PositiveConsequenceReward;
        public Conversation PositiveConsequenceDialogs;
        public Data.Type NegaiveConsequenceType;
        public int NegaiveConsequenceReward;
        public Conversation NegativeConsequenceDialogs;
    }
}