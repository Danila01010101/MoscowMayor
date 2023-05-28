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
        public List<Consiquence> PositiveConsiquence;
        public List<Consiquence> NegativeConsiquence;
    }

    [System.Serializable]
    public class Consiquence
    {
        public Data.Type Type;
        public int Reward;
        public Conversation Dialogs;
        public int RevardDelay;
        public int Cost;
    }
}