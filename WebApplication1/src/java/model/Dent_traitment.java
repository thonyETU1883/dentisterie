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
public class Dent_traitment {
    int id_dent_traitment;
    int id_dent;
    int id_traitment;
    double prix;

    public Dent_traitment(int id_dent_traitment, int id_dent, int id_traitment, double prix) {
        this.id_dent_traitment = id_dent_traitment;
        this.id_dent = id_dent;
        this.id_traitment = id_traitment;
        this.prix = prix;
    }

    public Dent_traitment() {
    }

    public Dent_traitment(int id_dent, int id_traitment, double prix) {
        this.id_dent = id_dent;
        this.id_traitment = id_traitment;
        this.prix = prix;
    }

    public int getId_dent_traitment() {
        return id_dent_traitment;
    }

    public void setId_dent_traitment(int id_dent_traitment) {
        this.id_dent_traitment = id_dent_traitment;
    }

    public int getId_dent() {
        return id_dent;
    }

    public void setId_dent(int id_dent) {
        this.id_dent = id_dent;
    }

    public int getId_traitment() {
        return id_traitment;
    }

    public void setId_traitment(int id_traitment) {
        this.id_traitment = id_traitment;
    }

    public double getPrix() {
        return prix;
    }

    public void setPrix(double prix) {
        this.prix = prix;
    }
    
    
}
