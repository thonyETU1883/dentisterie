using dentisterie_project.Models;

namespace dentisterie_project.Models;


using Npgsql;
using System.Data;

public class Offre {
    int id_offre;
    String nom;

    public Offre(int id_offre, String nom) {
        this.id_offre = id_offre;
        this.nom = nom;
    }

    public Offre(int id_offre) {
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


    public void get_offre_by_id(NpgsqlConnection liaisonbase){
        String sql = "SELECT * FROM offre WHERE id_offre = @id_offre";
        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            cmd.Parameters.AddWithValue("@id_offre",this.getId_offre());
            
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read()){
                this.setNom(reader.GetString(1));
            }

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }
    }

    public List<Offre> get_all_offre(NpgsqlConnection liaisonbase){
        String sql = "SELECT * FROM offre";

        List<Offre> liste_offre = new List<Offre>();
        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            cmd.Parameters.AddWithValue("@id_offre",this.getId_offre());
            
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read()){
                Offre offre = new Offre();
                offre.setId_offre(reader.GetInt32(0));
                offre.setNom(reader.GetString(1));
                liste_offre.Add(offre);
            }

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }
        return liste_offre;
    }
    
}
