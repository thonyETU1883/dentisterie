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
public class Dent {
    int id_dent;
    int type_dent;

    public Dent() {
    }

    public Dent(int type_dent) {
        this.type_dent = type_dent;
    }

    public Dent(int id_dent, int type_dent) {
        this.id_dent = id_dent;
        this.type_dent = type_dent;
    }

    public int getId_dent() {
        return id_dent;
    }

    public void setId_dent(int id_dent) {
        this.id_dent = id_dent;
    }

    public int getType_dent() {
        return type_dent;
    }

    public void setType_dent(int type_dent) {
        this.type_dent = type_dent;
    }
    
    
}
