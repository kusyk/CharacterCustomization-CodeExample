using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OutfitPreset
{
    [SerializeField] private string name;
    [SerializeField] private BodyPreset.HandTypes handType;

    [SerializeField] private List<GameObject> caps = new List<GameObject>();
    [SerializeField] private List<GameObject> shirts = new List<GameObject>();
    [SerializeField] private List<GameObject> pants = new List<GameObject>();
    [SerializeField] private List<GameObject> belts = new List<GameObject>();
    [SerializeField] private List<GameObject> boots = new List<GameObject>();

    public string Name { get => name; set => name = value; }
    public BodyPreset.HandTypes HandType { get => handType; set => handType = value; }
    public List<GameObject> Caps { get => caps; set => caps = value; }
    public List<GameObject> Shirts { get => shirts; set => shirts = value; }
    public List<GameObject> Pants { get => pants; set => pants = value; }
    public List<GameObject> Belts { get => belts; set => belts = value; }
    public List<GameObject> Boots { get => boots; set => boots = value; }

    public void ShowOutfit()
    {
        int cap = Random.Range(0, Caps.Count);
        int shirt = Random.Range(0, Shirts.Count);
        int pants = Random.Range(0, Pants.Count);
        int belt = Random.Range(0, Belts.Count);
        int boots = Random.Range(0, Boots.Count);

        Debug.Log($"cap {cap}, shirt {shirt}, pants {pants}, belt {belt}, boots {boots}");

        Caps[cap].SetActiveOptimized(true);
        Shirts[shirt].SetActiveOptimized(true);
        Pants[pants].SetActiveOptimized(true);
        Belts[belt].SetActiveOptimized(true);
        Boots[boots].SetActiveOptimized(true);
    }
}