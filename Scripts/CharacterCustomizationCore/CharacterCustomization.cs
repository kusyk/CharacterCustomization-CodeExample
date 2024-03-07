using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public partial class CharacterCustomization : MonoBehaviour
{
    [ReadOnly, SerializeField] private int bodyType = 0;
    [ReadOnly, SerializeField] private int outfitType = 0;
    [ReadOnly, SerializeField] private int seed = 0;

    [Space]
    [SerializeField] private List<Transform> elementGroups = new List<Transform>();

    public int BodyType { get => bodyType; }
    public int OutfitType { get => outfitType; }
    public int Seed { get => seed; }

    public Sprite Avatar 
    {
        get 
        {
            List<Sprite> tempAvatars = Bodies[BodyType].Avatars;
            return tempAvatars[seed % tempAvatars.Count];
        }
    }

    public void SetupCustomization(int newBody, int newOutfit, int newSeed)
    {
        bodyType = newBody;
        bodyType.ClampInt(0, bodies.Count - 1);
        outfitType = newOutfit;
        seed = newSeed;
        Random.InitState(seed);

        HideAllElements();
        ShowOutfit(outfitType);
        ShowBody(bodyType, SelectedOutfit.HandType);
        ShowRandomElements();
    }

    public void ChangeBody(int change)
    {
        SetupCustomization(bodyType + change, outfitType, seed);
    }

    public void RandomizeSeed()
    {
        int tempSeed = Random.Range(0, 10000);
        SetupCustomization(bodyType, outfitType, tempSeed);
    }

    public void HideAllElements()
    {
        for (int g = 0; g < elementGroups.Count; g++)
        {
            for (int o = 0; o < elementGroups[g].childCount; o++)
            {
                elementGroups[g].GetChild(o).gameObject.SetActiveOptimized(false);
            }
        }
    }
}
