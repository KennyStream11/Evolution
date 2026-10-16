using UnityEngine;



public class GestionPhases : MonoBehaviour
{
    [SerializeField] GameObject panneauOeuf;
    [SerializeField] GameObject panneauBebe;
    [SerializeField] GameObject panneauEnfant;
    public enum Phase
    {
        Oeuf,
        Bebe,
        Enfant
    }

    [SerializeField] Phase phaseActuelle;

    void AfficherPhase()
    {
        switch (phaseActuelle)
        {
            case Phase.Oeuf:
                panneauOeuf.SetActive(true);    
                panneauBebe.SetActive(false);
                panneauEnfant.SetActive(false);
                Debug.Log("Phase Oeuf activée");
                break;
            case Phase.Bebe:
                panneauOeuf.SetActive(false);
                panneauBebe.SetActive(true);
                panneauEnfant.SetActive(false);
                Debug.Log("Phase Bebe activée");
                break;
            case Phase.Enfant:
                panneauOeuf.SetActive(false);
                panneauBebe.SetActive(false);
                panneauEnfant.SetActive(true);
                Debug.Log("Phase Enfant activée");
                break;
        }
    }
    public void ChangerPhase(Phase nouvellePhase)
    {
        phaseActuelle = nouvellePhase;
        AfficherPhase();
    }


    private void Start()
    {
        AfficherPhase();
    }
}
