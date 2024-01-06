/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

import java.util.List;

/**
 *
 * @author thony
 */
public class Consultation {
    List<Etat_personne> liste_etat_personne;
    double budget;
    Offre offre;

    public Consultation() {
    }

    public Consultation(List<Etat_personne> liste_etat_personne, double budget, Offre offre) {
        this.liste_etat_personne = liste_etat_personne;
        this.budget = budget;
        this.offre = offre;
    }

    public List<Etat_personne> getListe_etat_personne() {
        return liste_etat_personne;
    }

    public void setListe_etat_personne(List<Etat_personne> liste_etat_personne) {
        this.liste_etat_personne = liste_etat_personne;
    }

    public double getBudget() {
        return budget;
    }

    public void setBudget(double budget) {
        this.budget = budget;
    }

    public Offre getOffre() {
        return offre;
    }

    public void setOffre(Offre offre) {
        this.offre = offre;
    }
    
    
    
}
