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
        public Conversation PositiveDialogs;
        public List<Consiquence> NegativeConsiquence;
        public Conversation NegativeDialogs;
    }

    [System.Serializable]
    public class Consiquence
    {
        public Data.Type Type;
        public int Amount;
        public int RevardDelay;
    }
}