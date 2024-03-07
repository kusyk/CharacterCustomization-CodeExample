using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[System.Serializable]
public class BodyPreset
{
    [SerializeField] private string name;
    [SerializeField, PreviewField()] private List<Sprite> avatars = new List<Sprite>();
    [SerializeField] private Genders gender;

    [SerializeField] private GameObject head;
    [SerializeField] private GameObject hands;
    [SerializeField] private GameObject handsPalm;
    [SerializeField] private GameObject handsGloves;

    public string Name { get => name; }
    public List<Sprite> Avatars { get => avatars; }
    public Genders Gender { get => gender; }
    public GameObject Head { get => head; }
    public GameObject Hands { get => hands; }
    public GameObject HandsPalm { get => handsPalm; }
    public GameObject HandsGloves { get => handsGloves; }

    public void ShowBody(HandTypes handType)
    {
        head.SetActiveOptimized(true);

        switch (handType)
        {
            case HandTypes.FULL:
                hands.SetActiveOptimized(true);
                break;
            case HandTypes.PALM:
                handsPalm.SetActiveOptimized(true);
                break;
            case HandTypes.GLOVES:
                handsGloves.SetActiveOptimized(true);
                break;
            default:
                break;
        }
    }

    [System.Serializable]
    public enum HandTypes
    {
        FULL,
        PALM,
        GLOVES
    }

    [System.Serializable]
    public enum Genders
    {
        Any,
        Male,
        Female
    }
}