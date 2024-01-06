namespace dentisterie_project.Models;

using Npgsql;
using System.Data;


public class Personne
{
    int id_personne;
    String nom;
    List<Etat_personne> liste_etat_personne;

    public Personne() {}

    public Personne(int id_personne, String nom,List<Etat_personne> liste_etat_personne) {
        this.id_personne = id_personne;
        this.nom = nom;
        this.liste_etat_personne = liste_etat_personne;
    }

    public Personne(int id_personne) {
        this.id_personne = id_personne;
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

    public List<Etat_personne> getListe_etat_personne(){
        return this.liste_etat_personne;
    }

    public void setListe_etat_personne(List<Etat_personne> liste_etat_personne){
        this.liste_etat_personne = liste_etat_personne;
    }


    public List<Personne> get_all_personne(NpgsqlConnection liaisonbase){
        List<Personne> liste_personne = new List<Personne>();
        String sql = "SELECT * FROM personne";

        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                Personne personne = new Personne();
                personne.setId_personne(reader.GetInt32(0));
                personne.setNom(reader.GetString(1));
                liste_personne.Add(personne);
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }

        return liste_personne;
    }

    public DateTime get_max_date (NpgsqlConnection liaisonbase){
        DateTime date = new DateTime();
        String sql = "SELECT * FROM etat_personne WHERE id_personne = @id_personne ORDER BY date DESC LIMIT 1";

        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            cmd.Parameters.AddWithValue("@id_personne",this.getId_personne());

            NpgsqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read()){
                return reader.GetDateTime(reader.GetOrdinal("date"));
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }

        return date;
    }


    /*
id_etat_personne |        date         | id_personne | id_dent | etat | type_dent
------------------+---------------------+-------------+---------+------+-----------
                1 | 2023-12-30 00:00:00 |           1 |       1 |    3 |         1
                2 | 2023-12-30 00:00:00 |           1 |       2 |    3 |         1
                3 | 2023-12-30 00:00:00 |           1 |       3 |    3 |         1
                4 | 2023-12-30 00:00:00 |           1 |       4 |    3 |         1
                5 | 2023-12-30 00:00:00 |           1 |       5 |    3 |         2
                6 | 2023-12-30 00:00:00 |           1 |       6 |    3 |         2
                7 | 2023-12-30 00:00:00 |           1 |       7 |    3 |         3
                8 | 2023-12-30 00:00:00 |           1 |       8 |    3 |         3
                9 | 2023-12-30 00:00:00 |           1 |       9 |    3 |         3
               10 | 2023-12-30 00:00:00 |           1 |      10 |    3 |         3
               11 | 2023-12-30 00:00:00 |           1 |      11 |    3 |         4
               12 | 2023-12-30 00:00:00 |           1 |      12 |    3 |         4
               13 | 2023-12-30 00:00:00 |           1 |      13 |    3 |         4
               14 | 2023-12-30 00:00:00 |           1 |      14 |    3 |         4
               15 | 2023-12-30 00:00:00 |           1 |      15 |    3 |         4
               16 | 2023-12-30 00:00:00 |           1 |      16 |    3 |         4
               17 | 2023-12-30 00:00:00 |           1 |      21 |    3 |         1
               18 | 2023-12-30 00:00:00 |           1 |      22 |    3 |         1
               19 | 2023-12-30 00:00:00 |           1 |      23 |    3 |         1
               20 | 2023-12-30 00:00:00 |           1 |      24 |    3 |         1
               21 | 2023-12-30 00:00:00 |           1 |      25 |    3 |         2
               22 | 2023-12-30 00:00:00 |           1 |      26 |    3 |         2
               23 | 2023-12-30 00:00:00 |           1 |      27 |    3 |         3
               24 | 2023-12-30 00:00:00 |           1 |      28 |    3 |         3
               25 | 2023-12-30 00:00:00 |           1 |      29 |    3 |         3
               26 | 2023-12-30 00:00:00 |           1 |      30 |    3 |         3
               27 | 2023-12-30 00:00:00 |           1 |      31 |    3 |         4
               28 | 2023-12-30 00:00:00 |           1 |      32 |    3 |         4
               29 | 2023-12-30 00:00:00 |           1 |      33 |    3 |         4
               30 | 2023-12-30 00:00:00 |           1 |      34 |    3 |         4
               31 | 2023-12-30 00:00:00 |           1 |      35 |    3 |         4
               32 | 2023-12-30 00:00:00 |           1 |      36 |    3 |         4
    */
    public void get_last_etat_personne(NpgsqlConnection liaisonbase,Offre offre){
        List<Etat_personne> liste_etat_Personne = new List<Etat_personne>();
        this.setListe_etat_personne(liste_etat_Personne);

        String sql = "SELECT * FROM etat_personne_view WHERE id_personne = @id_personne AND date = @date ORDER BY type_dent ASC";
        if(offre.getId_offre() == 1){
            sql = "SELECT * FROM etat_personne_view WHERE id_personne = @id_personne AND date = @date ORDER BY type_dent ASC";
        }else if(offre.getId_offre() == 2){
            sql = "SELECT * FROM etat_personne_view WHERE id_personne = @id_personne AND date = @date ORDER BY type_dent DESC";
        }
    
        DateTime date = this.get_max_date(liaisonbase);

        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            cmd.Parameters.AddWithValue("@id_personne",this.getId_personne());
            cmd.Parameters.AddWithValue("@date",date);
            
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                Etat_personne etat_personne = new Etat_personne();
                etat_personne.setId_etat_personne(reader.GetInt32(0));
                etat_personne.setDate(reader.GetDateTime(reader.GetOrdinal("date")));
                etat_personne.setId_personne(reader.GetInt32(2));
                etat_personne.setId_dent(reader.GetInt32(3));
                etat_personne.setEtat(reader.GetInt32(4));
                etat_personne.setType_dent(reader.GetInt32(5));
                liste_etat_Personne.Add(etat_personne);
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }
    
    }

    public Consultation to_do_traitement(NpgsqlConnection liaisonbase,Offre offre,double budget){
        this.get_last_etat_personne(liaisonbase,offre);
        Consultation consultation = new Consultation(this.getListe_etat_personne(),budget,offre);
        consultation.consultation_personne(liaisonbase);
        return consultation;
    }
}