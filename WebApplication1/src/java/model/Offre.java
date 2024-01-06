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
public class Offre {
    int id_offre;
    String nom;

    public Offre(int id_offre, String nom) {
        this.id_offre = id_offre;
        this.nom = nom;
    }

    public Offre(String nom) {
        this.nom = nom;
    }

    public Offre() {
    }

    public int getId_offre() {
        return id_offre;
    }

    public void setId_offre(int id_offre) {
        this.id_offre = id_offre;
    }

    public String getNom() {
        return nom;
    }

    public void setNom(String nom) {
        this.nom = nom;
    }
    
    
}
