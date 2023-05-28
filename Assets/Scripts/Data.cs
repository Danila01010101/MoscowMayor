using UnityEngine;

public class Data : MonoBehaviour
{
    public int Money;
    public int SocialRating;
    public int PoliticPoint;
    public static Data Instance { get; private set; }

    public enum Type { Money = 0, SocialRating = 1, PoliticPoint = 2}

    private void Awake()
    {
        Instance = this;
    }
}