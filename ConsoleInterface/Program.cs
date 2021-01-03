﻿using System;
using Covid19Track;
using System.Collections.Generic;

namespace ConsoleInterface
{
    class Program
    {
        private static List<Citoyen> citoyens = new List<Citoyen>();
        private static List<Laboratoire> laboratoires = new List<Laboratoire>();
        private static List<CentreDeVaccination> centres = new List<CentreDeVaccination>();
        static void Main(string[] args)
        {
            while (true)
            {
                int choice = Menu();

                switch (choice)
                {
                    case 1:

                        AddCitoyen();
                        break;
                    case 2:
                        AddLabo();
                        break;
                    case 3:
                        AddCentre();
                        break;
                    case 4:
                        AfficherCitoyen();
                        break;
                    case 5:
                        AfficherLabo();
                        break;
                    case 6:
                        AfficherCentre();
                        break;
                    case 7:
                        LiserCitoyens();
                        break;
                    case 8:
                        ListerLabos();
                        break;
                    case 9:
                        ListerCentres();
                        break;
                    case 10:
                        TestPCR();
                        break;
                    case 11:
                        VaccinerCitoyen();
                        break;
                    case 12:
                        RencentrerCitoyens();
                        break;
                    case 0:
                        Console.WriteLine("Quiter...");
                        return;
                    default:
                        Console.WriteLine("Y'a aucun operation avec le numero : " + choice);
                        break;
                }

            }
        }
        static int Menu()
        {
            while (true)
            {
                Console.WriteLine("\n--------------------------------------");
                Console.WriteLine("1)  Ajouter un Citoyen.");
                Console.WriteLine("2)  Ajouter un Laboratoire.");
                Console.WriteLine("3)  Ajouter un Centre de Vaccination.");
                Console.WriteLine("4)  Afficher un Citoyen.");
                Console.WriteLine("5)  Afficher un Laboratoire.");
                Console.WriteLine("6)  Afficher un Centre de Vaccination.");
                Console.WriteLine("7)  Lister Les Citoyens.");
                Console.WriteLine("8)  Lister Les Laboratoire.");
                Console.WriteLine("9)  Lister Les Centre de Vaccination.");
                Console.WriteLine("10) Faire un test PCR pour un citoyen.");
                Console.WriteLine("11) Injecter une Dose de vaccin pour un Citoyen.");
                Console.WriteLine("12) Rencontrer deux citoyens.");
                Console.WriteLine("0)  Quiter.");
                Console.Write("Choisier votre operation: ");
                bool valide = int.TryParse(Console.ReadLine(), out int choice);
                Console.Clear();
                if (valide)
                    return choice;
                else
                    Console.WriteLine("Choix Non Valide ! Ressayer");
            }
        }
        private static void LiserCitoyens()
        {
            for (int i = 0; i < citoyens.Count; i++)
            {
                Console.WriteLine(citoyens[i].ConsultationEtat());
            }
        }

        private static void RencentrerCitoyens()
        {
            Console.Write("Entrer le CNI de 1ér Citoyen: ");
            string cni = Console.ReadLine().Trim();
            int index = FindCitoyen(cni);
            if (index >= 0)
            {
                Console.Write("Entrer le CNI de 2éme Citoyen: ");
                string cni122 = Console.ReadLine().Trim();
                int i = FindCitoyen(cni);
                if (i >= 0)
                {
                    citoyens[i].Contacter(citoyens[index]);
                }
                else
                    Console.WriteLine("Il y'a aucun citoyen avec ce CNI !");
            }
            else
                Console.WriteLine("Il y'a aucun citoyen avec ce CNI !");
        }

        private static void VaccinerCitoyen()
        {
            Console.Write("Entrer le CNI de Citoyen: ");
            string cni = Console.ReadLine().Trim();
            int index = FindCitoyen(cni);
            if (index >= 0)
            {
                Console.Write("Entrer le reference de Centre: ");
                string reference = Console.ReadLine().Trim();
                int i = FindECentre(reference);
                if (i >= 0)
                {
                    centres[i].InjecteDose(citoyens[index]);
                }
                else
                    Console.WriteLine("Il y'a aucun laboratoire avec ce reference!");
            }
            else
                Console.WriteLine("Il y'a aucun citoyen avec ce CNI !");
        }

        private static void TestPCR()
        {
            Console.Write("Entrer le CNI de Citoyen: ");
            string cni = Console.ReadLine().Trim();
            int index7 = FindCitoyen(cni);
            if (index7 >= 0)
            {
                Console.Write("Entrer le reference de laboratoire: ");
                string reference = Console.ReadLine().Trim();
                int i = FindLabo(reference);
                if (i >= 0)
                {
                    bool res = laboratoires[i].TestPCR(citoyens[index7]);
                    if (res)
                    {
                        Console.WriteLine("Resultat positive");
                    }
                    else
                    {
                        Console.WriteLine("Resultat negative");
                    }
                }
                else
                    Console.WriteLine("Il y'a aucun laboratoire avec ce reference!");
            }
            else
                Console.WriteLine("Il y'a aucun citoyen avec ce CNI !");
        }

        private static void ListerCentres()
        {
            for (int i = 0; i < centres.Count; i++)
            {
                Console.WriteLine(centres[i]);
            }
        }

        private static void ListerLabos()
        {
            for (int i = 0; i < laboratoires.Count; i++)
            {
                Console.WriteLine(laboratoires[i]);
            }
        }

        private static void AfficherCentre()
        {
            Console.Write("Entrer le reference de la centre: ");
            string reference = Console.ReadLine().Trim();
            int index = FindECentre(reference);
            if (index < 0)
            {
                Console.WriteLine("Il y'a aucun centre avec ce reference !");
            }
            else
            {
                Console.WriteLine(centres[index]);
            }
        }

        private static void AfficherLabo()
        {
            Console.Write("Entrer le reference de laboratoire: ");
            string reference = Console.ReadLine().Trim();
            int index = FindLabo(reference);
            if (index < 0)
            {
                Console.WriteLine("Y'a aucun laboratoire avec ce reference !");
            }
            else
            {
                Console.WriteLine(laboratoires[index]);
            }
        }

        private static void AfficherCitoyen()
        {
            Console.Write("Entrer le CNI we citoyen: ");
            string cni = Console.ReadLine().Trim();
            int index = FindCitoyen(cni);
            if (index < 0)
            {
                Console.WriteLine("Y'a aucun citoyen avec ce CNI !");
            }
            else
            {
                Console.WriteLine(citoyens[index].ConsultationEtat());
            }
        }

        private static void AddCitoyen()
        {
            Console.Write("Entrer le CNI de Citoyen: ");
            string cni = Console.ReadLine().Trim();
            if (FindCitoyen(cni) < 0)
            {
                Console.Write("Entrer le Prenom de Citoyen: ");
                string prenom = Console.ReadLine().Trim();
                Console.Write("Entrer le Nom de Citoyen: ");
                string nom = Console.ReadLine().Trim();
                Console.Write("Entrer la Date de Naissance de Citoyen: ");
                string dn = Console.ReadLine().Trim();
                Console.Write("L'etat de citoyen est connu ? (y/n): ");
                if (Console.ReadKey().Key == ConsoleKey.Y)
                {
                    Console.WriteLine("\n1)Saint.\n2)Soupçonne.\n3)Infecté.\n4)Vacciné");
                    Console.Write("Entrer le numero de l'etat: ");
                    var c = Console.ReadKey();
                    switch (c.Key)
                    {
                        case ConsoleKey.D1:
                            citoyens.Add(new Citoyen(cni, nom, prenom, dn, Etats.Saint));
                            break;
                        case ConsoleKey.D2:
                            citoyens.Add(new Citoyen(cni, nom, prenom, dn, Etats.Soupconne));
                            break;
                        case ConsoleKey.D3:
                            citoyens.Add(new Citoyen(cni, nom, prenom, dn, Etats.Infecte));
                            break;
                        case ConsoleKey.D4:
                            citoyens.Add(new Citoyen(cni, nom, prenom, dn, Etats.Vaccine));
                            break;
                        default:
                            citoyens.Add(new Citoyen(cni, nom, prenom, dn, Etats.Inconnu));
                            Console.WriteLine("nombre d'etat invalide! citoyen enregistrer avec l'etat (Inconnu).");
                            break;
                    }
                }
                else
                {
                    citoyens.Add(new Citoyen(cni, nom, prenom, dn));
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine("Il y'a deja un citoyen avec meme CNI!");

        }
        
        private static void AddLabo()
        {
            Console.Write("Entrer le reference de Labo: ");
            string reference = Console.ReadLine().Trim().ToUpper();
            if (FindLabo(reference) < 0)
            {
                Console.Write("Entrer le Nom de Labo: ");
                string nom = Console.ReadLine().Trim();
                laboratoires.Add(new Laboratoire(reference, nom));
            }
            else
                Console.WriteLine("Il y'a deja un laboratoire avec meme reference!");


        }
        
        private static void AddCentre()
        {
            Console.Write("Entrer le reference de Centre: ");
            string reference = Console.ReadLine().Trim();
            if (FindECentre(reference) < 0)
            {
                Console.Write("Entrer le Nom de Centre de vaccination: ");
                string nom = Console.ReadLine().Trim();
                centres.Add(new CentreDeVaccination(nom, reference));
            }
            else
                Console.WriteLine("Il y'a deja un Centre avec meme reference!");


        }

        private static int FindCitoyen(string cin)
        {
            return citoyens.FindIndex(citoyen => citoyen.CIN.Equals(cin));
        }

        private static int FindECentre(string reference)
        {
            return centres.FindIndex(centre => centre.reference.Equals(reference));
        }

        private static int FindLabo(string reference)
        {
            return laboratoires.FindIndex(labo => labo.reference.Equals(reference));
        }

    }
}