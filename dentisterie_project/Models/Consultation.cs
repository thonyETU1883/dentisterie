namespace dentisterie_project.Models;


using Npgsql;
using System.Data;

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

    public void consultation_personne(NpgsqlConnection liaisonbase){
        List<Etat_personne> liste_etat_personne = this.getListe_etat_personne();
        double budget = this.getBudget();
        int i = 0;
        foreach(Etat_personne etat in liste_etat_personne){
            budget = etat.traitment_dent(liaisonbase,budget);
        }
        this.setBudget(budget);
    }
}