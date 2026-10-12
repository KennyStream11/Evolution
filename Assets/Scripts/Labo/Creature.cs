using UnityEngine;

public class Creature
{
    public string Nom { get; private set; }
    public int Vie { get; private set; }
    private int force;
    public int Vitesse { get; private set; }
    private int resistance;
    public int VieMax { get; private set; }

    public Creature(string nomDeDepart, int vieDeDepart, int forceDeDepart, int vitesseDeDepart, int resistanceDeDepart)
    {
        if (string.IsNullOrEmpty(nomDeDepart))
        {
            Nom = "Créature inconnue";
        }
        else
        {
            Nom = nomDeDepart;
        }
        Vie = Mathf.Max(1, vieDeDepart);
        VieMax = Vie;
        force = Mathf.Max(0, forceDeDepart);
        Vitesse = Mathf.Max(0, vitesseDeDepart);
        resistance = Mathf.Max(0, resistanceDeDepart);


    }


    public void SePresenter()
    {
        Debug.Log(Nom + " a " + Vie + " HP // " + force + " Force. // " + Vitesse + " Vitesse. // " + resistance + " Resistance.");
    }


    public void Attaquer(Creature cible)
    {
        int degats = force - cible.resistance;

        if (degats <= 0)
        {
            degats = 1;
        }
        cible.SubirDegats(degats);

        Debug.Log(Nom + " attaque " + cible.Nom + " de plein fouet! Infligeant " + degats + " points de dégats. Il lui reste maintenant " + cible.Vie + " PV.");
    }

    public void SubirDegats(int degats)
    {
        if (degats <= 0)
        {
            degats = 1;
        }

        Vie -= degats;
        if (Vie < 0)
        {
            Vie = 0;
        }
    }
    public void Soigner(int quantite)
    {
        if (EstVivante)
        {
            if (VieMax > Vie + quantite)
            {
                Vie += quantite;
                Debug.Log(Nom + " s'est soigné de " + quantite);
                Debug.Log(Nom + " a maintenant " + Vie + " HP!");

            }
            else
            {
                Vie = VieMax;
                Debug.Log(Nom + " est maintenant full HP!");
            }

        }
        else
        {
            Debug.Log(Nom + " a essayé de se soigner mais malheureusement, " + Nom + " est mort.");
        }
    }

    public bool EstVivante => Vie > 0;
}