namespace dentisterie_project.Models;

using Npgsql;
using System.Data;

public class Etat_personne
{    int id_etat_personne;
    DateTime date;
    int id_personne;
    int id_dent;
    int etat;
    int type_dent;


    public Etat_personne() {
    }

    public Etat_personne(int id_personne,DateTime date ,int id_dent, int etat, int type_dent) {
        this.id_personne = id_personne;
        this.date = date;
        this.id_dent = id_dent;
        this.etat = etat;
        this.type_dent = type_dent;
    }

    public Etat_personne(int id_etat_personne,DateTime date ,int id_personne, int id_dent, int etat, int type_dent) {
        this.id_etat_personne = id_etat_personne;
        this.date = date;
        this.id_personne = id_personne;
        this.id_dent = id_dent;
        this.etat = etat;
        this.type_dent = type_dent;
    }


    public Etat_personne(DateTime date ,int id_personne, int id_dent, int etat) {
        this.id_etat_personne = id_etat_personne;
        this.date = date;
        this.id_personne = id_personne;
        this.id_dent = id_dent;
        this.etat = etat;
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

    public int getEtat() {
        return etat;
    }

    public void setEtat(int etat) {
        this.etat = etat;
    }

    public int getType_dent() {
        return type_dent;
    }

    public void setType_dent(int type_dent) {
        this.type_dent = type_dent;
    }

    public DateTime getDate(){
        return this.date;
    }

    public void setDate(DateTime date){
        this.date = date;
    }

    public void insertion_etat_personne(NpgsqlConnection liaisonbase){
        String sql = "INSERT INTO etat_personne(date,id_personne,id_dent,etat) VALUES (@date,@id_personne,@id_dent,@etat)"; 
        
        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{

            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            cmd.Parameters.AddWithValue("@date",this.getDate());
            cmd.Parameters.AddWithValue("@id_personne", this.getId_personne());
            cmd.Parameters.AddWithValue("@id_dent", this.getId_dent());
            cmd.Parameters.AddWithValue("@etat", this.getEtat());
            cmd.ExecuteScalar();
            
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }

    }   

    public Traitment get_traitment_dent(NpgsqlConnection liaisonbase){
        Traitment traitment = new Traitment();
        String sql = "SELECT * FROM traitment WHERE niveau_min <= @etat AND niveau_max >= @etat";
        
        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            cmd.Parameters.AddWithValue("@etat",this.getEtat());
            
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read()){
                traitment.setId_traitment(reader.GetInt32(0));
                traitment.setNom_traitment(reader.GetString(1));
                traitment.setNiveau_min(reader.GetInt32(2));
                traitment.setNiveau_max(reader.GetInt32(3));
                traitment.setApres_traitment(reader.GetInt32(4));
            }

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }
        
        return traitment;
    }

   public Dent_traitment get_prix_traitment(NpgsqlConnection liaisonbase){
        Traitment traitment = this.get_traitment_dent(liaisonbase);
        Dent_traitment dent_traitment = new Dent_traitment(); 
        String sql = "SELECT * FROM dent_traitment WHERE id_traitment = @id_traitment AND id_dent = @id_dent";

        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }


        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            cmd.Parameters.AddWithValue("@etat",this.getEtat());
            
            NpgsqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read()){
                dent_traitment.setId_dent_traitment(reader.GetInt32(0));
                dent_traitment.setId_dent(reader.GetInt32(1));
                dent_traitment.setId_traitment(reader.GetInt32(2));
                dent_traitment.setPrix(reader.GetDouble(3));
            }

        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }

        return dent_traitment;
    }

    public double traitment_dent(NpgsqlConnection liaisonbase,double budget){
        int etat = this.getEtat();

         if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        double etat_budget = budget;
        while(etat != 10 && etat_budget > 0){
            Dent_traitment dent_Traitment = this.get_prix_traitment(liaisonbase);
            Traitment traitment = this.get_traitment_dent(liaisonbase);

            etat_budget = budget-dent_Traitment.getPrix();

            if(etat_budget >= 0){
                int apres_traitment = traitment.getApres_traitment();
                this.setEtat(apres_traitment);
                budget = etat_budget;
            }

            etat = this.getEtat();
        }

        if(liaisonbase != null){
                liaisonbase.Close();
        }
        return budget;

    }

}