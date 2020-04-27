using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace NivelAccesDate
{
    public class AdministrareAutomobile_FisierText: IStocareData
    {
        private const int PAS_ALOCARE = 10;
        string NumeFisier { get; set; }
        public AdministrareAutomobile_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();
        }
        public void AddAutomobil(Automobile []s,int _numarmasini)
        {
            if (File.Exists(@"C:\Users\Stefan\source\repos\TemaLab6\Problema\AutomobileForms\bin\Debug\Automobile.txt"))
            {
                File.WriteAllText(@"C:\Users\Stefan\source\repos\TemaLab6\Problema\AutomobileForms\bin\Debug\Automobile.txt", String.Empty);
            }
            for (int i = 0; i < _numarmasini; i++)
            {
                try
                {
                    using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                    {
                        swFisierText.WriteLine(s[i].afisare());
                    }
                }
                catch (IOException eIO)
                {
                    throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
                }
                catch (Exception eGen)
                {
                    throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
                }
            }
        }

        public Automobile[] GetAutomobile(out int NumarMasini)
        {
            Automobile[] masini = new Automobile[PAS_ALOCARE];

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    NumarMasini = 0;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        masini[NumarMasini] = new Automobile(line);
                        NumarMasini++;
                        if (NumarMasini == PAS_ALOCARE)
                        {
                            Array.Resize(ref masini, NumarMasini + PAS_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return masini;
        }
        public ArrayList GetAutomobile()
        {
            ArrayList masini= new ArrayList();

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Automobile s = new Automobile(line);
                        masini.Add(s);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return masini;
        }

        public Automobile GetAutomobil(string criteriu, int opt)
        {
            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        Automobile s = new Automobile(line);
                        if (opt ==1)
                        {
                            if (s.Marca.Equals(criteriu))
                                return s;
                        }
                        if (opt == 2)
                        {
                            if (s.Model.Equals(criteriu))
                                return s;
                        }
                        if (opt == 3)
                        {
                            if (s.Culoare.Equals(criteriu))
                                return s;
                        }
                        if (opt == 4)
                        {
                            if (s.Pret.Equals(criteriu))
                                return s;
                        }
                        if (opt == 5)
                        {
                            if (s.BugetClass.Equals(criteriu))
                                return s;
                        }

                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return null;
        }
        public bool UpdateAutomobil(Automobile automobilActualizat)
        {
            ArrayList masini = GetAutomobile();
            bool actualizareCuSucces = false;
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'false' al constructorului StreamWriter indica modul 'overwrite' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, false))
                {
                    foreach (Automobile s in masini)
                    {
                        s.Marca = Regex.Replace(s.Marca, @"\s", "");
                        s.Model = Regex.Replace(s.Model, @"\s", "");
                        //informatiile despre studentul actualizat vor fi preluate din parametrul "studentActualizat"
                        if (s.Marca != automobilActualizat.Marca && s.Model!=automobilActualizat.Model)
                        {
                            swFisierText.WriteLine(s.afisare());
                        }
                        else
                        {
                            swFisierText.WriteLine(automobilActualizat.afisare());
                        }
                    }
                    actualizareCuSucces = true;
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return actualizareCuSucces;
        }
    }
}
