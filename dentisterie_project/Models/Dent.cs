namespace dentisterie_project.Models;

using Npgsql;
using System.Data;
public class Dent
{
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


    public double get_prix_traitment(int etat){
        double prix = 0;
        return prix;
    }


    public List<Dent> get_all_dent(NpgsqlConnection liaisonbase){
        List<Dent> liste_dent = new List<Dent>();

        String sql = "SELECT * FROM dent";

        if(liaisonbase == null || liaisonbase.State == ConnectionState.Closed){
            Connexion connexion = new Connexion ();
            liaisonbase = connexion.createLiaisonBase();
            liaisonbase.Open();
        }

        try{
            NpgsqlCommand cmd = new NpgsqlCommand(sql, liaisonbase);
            NpgsqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read()){
                Dent dent = new Dent();
                dent.setId_dent(reader.GetInt32(0));
                dent.setType_dent(reader.GetInt32(1));
                liste_dent.Add(dent);
            }
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }finally{
            if(liaisonbase != null){
                liaisonbase.Close();
            }
        }

        return liste_dent;
    }
}