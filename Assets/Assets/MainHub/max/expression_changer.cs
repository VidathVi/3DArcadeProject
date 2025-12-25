using UnityEngine;

public class expression_changer : MonoBehaviour
{
    public GameObject maxPrefab;
    public Material standard;
    public Material blinking;
    public Material eyebrow;
    public Material side;
    public Material smirk;
    public Material sweat;
    public Material stare;

    void Start()
    {
        
    }

    void Update()
    {
        SetBlinking();
    }

    void SetBlinking()
    {

        var materialsCopy = maxPrefab.GetComponent<Renderer>().sharedMaterials;
        materialsCopy[1] = standard;
        maxPrefab.GetComponent<Renderer>().sharedMaterials = materialsCopy;
    }
}
