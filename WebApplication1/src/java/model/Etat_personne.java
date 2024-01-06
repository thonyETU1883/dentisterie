/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package model;

/**
 *
 * @author thony
 */
public class Etat_personne {
    int id_etat_personne;
    int id_personne;
    int id_dent;
    int id_etat;
    int type_dent;
    String nom_etat;

    public Etat_personne() {
    }

    public Etat_personne(int id_personne, int id_dent, int id_etat, int type_dent, String nom_etat) {
        this.id_personne = id_personne;
        this.id_dent = id_dent;
        this.id_etat = id_etat;
        this.type_dent = type_dent;
        this.nom_etat = nom_etat;
    }

    public Etat_personne(int id_etat_personne, int id_personne, int id_dent, int id_etat, int type_dent, String nom_etat) {
        this.id_etat_personne = id_etat_personne;
        this.id_personne = id_personne;
        this.id_dent = id_dent;
        this.id_etat = id_etat;
        this.type_dent = type_dent;
        this.nom_etat = nom_etat;
    }

    public int getId_etat_personne() {
        return id_etat_personne;
    }

    public void setId_etat_personne(int id_etat_personne) {
        this.id_etat_personne = id_etat_personne;
    }

    public int getId_personne() {
        return id_personne;
    }

    public void setId_personne(int id_personne) {
        this.id_personne = id_personne;
    }

    public int getId_dent() {
        return id_dent;
    }

    public void setId_dent(int id_dent) {
        this.id_dent = id_dent;
    }

    public int getId_etat() {
        return id_etat;
    }

    public void setId_etat(int id_etat) {
        this.id_etat = id_etat;
    }

    public int getType_dent() {
        return type_dent;
    }

    public void setType_dent(int type_dent) {
        this.type_dent = type_dent;
    }

    public String getNom_etat() {
        return nom_etat;
    }

    public void setNom_etat(String nom_etat) {
        this.nom_etat = nom_etat;
    }
    
    
}
