using System.Collections.Generic;
using UnityEngine;

public class Labo : MonoBehaviour
{


    //nom, vie, force, vitesse, resistance



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        List<Creature> ocean = new List<Creature>();
        Creature meduse = new Creature("Méduse", 30, 1, 1, 1);
        Creature crabe = new Creature("Crabe", 45, 1, 1, 1);
        Creature requin = new Creature("Requin Puissant", 100, 1, 1, 1);
        Creature poissonglobe = new Creature("Poisson Globe", 60, 1, 1, 1);
        Creature calamar = new Creature("Calamar", 70, 1, 1, 1);
        ocean.Add(meduse);
        ocean.Add(crabe);
        ocean.Add(requin);
        ocean.Add(poissonglobe);
        ocean.Add(calamar);
        AfficherEquipe(ocean);
        ocean.RemoveAt(0);
        AfficherEquipe(ocean);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Combat(Creature a, Creature b)
    {
        Debug.Log("---------------");
        Debug.Log("UN COMBAT ECLATE");
        Debug.Log("---------------");
        Creature rapide;
        Creature lent;

        if (a.Vitesse >= b.Vitesse)
        {
            rapide = a;
            lent = b;
        }
        else
        {
            rapide = b;
            lent = a;
        }

        Debug.Log(rapide.Nom + " est plus rapide, il frappera en premier.");
        while (rapide.EstVivante && lent.EstVivante)
        {
            rapide.Attaquer(lent);
            if (lent.EstVivante)
            {
                lent.Attaquer(rapide);
            }
        }

        if (!a.EstVivante)
        {
            Debug.Log(a.Nom + " s'est fait terrasser par " + b.Nom);
        }
        else
        {
            Debug.Log(b.Nom + " s'est fait terrasser par " + a.Nom);
        }

    }

    void AfficherEquipe(List<Creature> equipe)
    {
        for (int i = 0; i < equipe.Count; i++)
        {
            Debug.Log((i + 1) + ". " + equipe[i].Nom + " (" + equipe[i].Vie + "/" + equipe[i].VieMax + ")");

        }
        Debug.Log("Equipe de " + equipe.Count + " créatures.");
    }
}



