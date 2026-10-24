using TMPro;
using UnityEngine;

public class Enfant : MonoBehaviour
{


    // ========== IDENTITE ==========
    [SerializeField] EspeceCreature espece;
    [SerializeField] TMP_Text texteNomEnfant;
    [SerializeField] GestionPhases gestionPhases;
    [SerializeField] Oeuf oeuf;
    [SerializeField] Bebe bebe;

    public void MettreAJourEnfant(EspeceCreature nouvelleEspece)
    {
        espece = nouvelleEspece;
        texteNomEnfant.text = espece.Nom;
    }

    public void RetourOeuf()
    {
        oeuf.PreparerNouvelOeuf();
        bebe.ResetBebe();
        bebe.ResetDeroulementHUDBebe();
        gestionPhases.ChangerPhase(GestionPhases.Phase.Oeuf);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
