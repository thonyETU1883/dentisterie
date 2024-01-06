namespace dentisterie_project.Models;

public class Traitment { 
    int id_traitment;
    String nom_traitment;
    int niveau_min;
    int niveau_max;
    int apres_traitment;

    public Traitment() {
    }

    public Traitment(int id_traitment, String nom_traitment, int niveau_min, int niveau_max, int apres_traitment) {
        this.id_traitment = id_traitment;
        this.nom_traitment = nom_traitment;
        this.niveau_min = niveau_min;
        this.niveau_max = niveau_max;
        this.apres_traitment = apres_traitment;
    }

    public Traitment(String nom_traitment, int niveau_min, int niveau_max, int apres_traitment) {
        this.nom_traitment = nom_traitment;
        this.niveau_min = niveau_min;
        this.niveau_max = niveau_max;
        this.apres_traitment = apres_traitment;
    }

    public int getId_traitment() {
        return id_traitment;
    }

    public void setId_traitment(int id_traitment) {
        this.id_traitment = id_traitment;
    }

    public String getNom_traitment() {
        return nom_traitment;
    }

    public void setNom_traitment(String nom_traitment) {
        this.nom_traitment = nom_traitment;
    }

    public int getNiveau_min() {
        return niveau_min;
    }

    public void setNiveau_min(int niveau_min) {
        this.niveau_min = niveau_min;
    }

    public int getNiveau_max() {
        return niveau_max;
    }

    public void setNiveau_max(int niveau_max) {
        this.niveau_max = niveau_max;
    }

    public int getApres_traitment() {
        return apres_traitment;
    }

    public void setApres_traitment(int apres_traitment) {
        this.apres_traitment = apres_traitment;
    }
     
}