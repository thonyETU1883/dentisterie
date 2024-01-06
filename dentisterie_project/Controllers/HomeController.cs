using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dentisterie_project.Models;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;


using Npgsql;
using System.Data;

namespace dentisterie_project.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Etat_personne etat = new Etat_personne(1,new DateTime(),1,1,2,1);
        etat.traitment_dent(null,20000);
        Console.WriteLine(etat.getEtat());
        return View();
    }

    public IActionResult face()
    {
         /*try{
        Mat image = CvInvoke.Imread("D:/multimedia/multimedia/IMG_20231218_152635.jpg", ImreadModes.Color);

        // Vérification si l'image a été chargée correctement
        if (image != null)
        {
            // Convertir l'image en niveaux de gris (nécessaire pour la détection de visages)
            Mat grayImage = new Mat();
            CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

            // Charger le classificateur de visages pré-entrainé
            CascadeClassifier faceCascade = new CascadeClassifier("D:/haarcascade_frontalface_default.xml");

            // Détection des visages dans l'image
            Rectangle[] faces = faceCascade.DetectMultiScale(grayImage, 1.1, 3);

            // Dessiner des rectangles autour des visages détectés
            foreach (Rectangle face in faces)
            {
                CvInvoke.Rectangle(image, face, new MCvScalar(0, 255, 0), 2);
            }

            // Afficher l'image avec les visages détectés
            CvInvoke.Imshow("Faces Detection", image);
            CvInvoke.WaitKey(0);
        }
        else
        {
            Console.WriteLine("Erreur lors du chargement de l'image.");
        }
        }catch (Exception ex)
        {
            Console.WriteLine("Erreur Emgu CV : " + ex.Message);
        }*/

        /*try{
        Mat image = CvInvoke.Imread("D:/R.jpg", ImreadModes.Color);

        // Vérification si l'image a été chargée correctement
        if (image != null)
        {
            Mat grayImage = new Mat();
        CvInvoke.CvtColor(image, grayImage, ColorConversion.Bgr2Gray);

        // Appliquer un flou pour réduire le bruit
        CvInvoke.GaussianBlur(grayImage, grayImage, new Size(5, 5), 0);

        // Détecter les contours avec l'algorithme de Canny
        Mat cannyEdges = new Mat();
        CvInvoke.Canny(grayImage, cannyEdges, 50, 150);

        // Afficher les contours
        CvInvoke.Imshow("Contours", cannyEdges);
        CvInvoke.WaitKey(0);

        }
        else
        {
            Console.WriteLine("Erreur lors du chargement de l'image.");
        }
        }catch (Exception ex)
        {
            Console.WriteLine("Erreur Emgu CV : " + ex.Message);
        }*/


        return View();
    }

    public IActionResult Privacy()
    {
        
        return View();
    }

    public IActionResult vers_dent()
    {
        Personne personne = new Personne();
        Dent dent = new Dent();
        List<Personne> liste_personne = personne.get_all_personne(null);
        List<Dent> liste_dent = dent.get_all_dent(null);
        ViewBag.liste_personne = liste_personne;
        ViewBag.liste_dent = liste_dent;
        return View("dent");
    }

    [HttpPost]
    public IActionResult InsertionEtatPersonne(IFormCollection collection,int id_personne)
    {
        DateTime aujourdhui = DateTime.Today;
        Dent dent = new Dent();
        List<Dent> liste_dent = dent.get_all_dent(null);
        int i = 0;
        Connexion connexion = new Connexion();
        NpgsqlConnection liaisonbase = connexion.createLiaisonBase();

        foreach (var key in collection.Keys)
        {
            if (key.StartsWith("dent["))
            {
                string idDent = key.Substring(5, key.Length - 6);
                int valeur = Convert.ToInt32(collection[key]);
                Etat_personne etat_personne = new Etat_personne(aujourdhui,id_personne,liste_dent[i].getId_dent(),valeur);
                //etat_personne.insertion_etat_personne(liaisonbase);
                i++;
            }
        }




        Offre offre = new Offre(0);
        Personne personne = new Personne(id_personne);
        personne.get_last_etat_personne(liaisonbase,offre);
        List<Etat_personne> liste_etat_personne = personne.getListe_etat_personne();
        List<Offre> liste_offre = offre.get_all_offre(liaisonbase);
        ViewBag.liste_etat_personne = liste_etat_personne;
        ViewBag.liste_offre = liste_offre;
        ViewBag.id_personne = id_personne;


        return View("etat");
    }

    public IActionResult vers_resultat(int id_personne,int id_offre,double budget)
    {   
        Personne personne = new Personne(id_personne);
        Offre offre = new Offre(id_offre);
        Connexion connexion = new Connexion();
        NpgsqlConnection liaisonbase = connexion.createLiaisonBase();
        offre.get_offre_by_id(liaisonbase);
        Consultation consultation = personne.to_do_traitement(liaisonbase,offre,budget);

        ViewBag.offre = offre;
        ViewBag.consultation = consultation;

        return View("resultat");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
