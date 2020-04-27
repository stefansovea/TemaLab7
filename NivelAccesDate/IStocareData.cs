using LibrarieModele;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    //definitia interfetei
    public interface IStocareData
    {
        Automobile[] GetAutomobile(out int NumarMasini);
        void AddAutomobil(Automobile [] s,int numarmasini);
         Automobile GetAutomobil(string criteriu, int opt);
        ArrayList GetAutomobile();
        bool UpdateAutomobil(Automobile automobilActualizat);
    }
}
