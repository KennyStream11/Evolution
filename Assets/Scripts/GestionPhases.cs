using UnityEngine;

public class GestionPhases : MonoBehaviour
{
    public enum Phase
    {
        Oeuf,
        Bebe,
        Enfant
    }

    [SerializeField] Phase phaseActuelle;
}
