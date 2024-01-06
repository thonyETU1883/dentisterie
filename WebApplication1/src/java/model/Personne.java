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
public class Personne {
    int id_personne;
    String nom;

    public Personne() {
    }

    public Personne(int id_personne, String nom) {
        this.id_personne = id_personne;
        this.nom = nom;
    }

    public Personne(String nom) {
        this.nom = nom;
    }

    public int getId_personne() {
        return id_personne;
    }

    public void setId_personne(int id_personne) {
        this.id_personne = id_personne;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }
    
    
}
