using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORM_KAT0013.Database
{
    public class Pronajem
    {
        private int mId_pronajem;
        private DateTime mDatum_od;
        private DateTime mDatum_do;
        private int mCena;
        private int mZaloha;
        private String mPoznamka;
        private Klient mId_klient;
        private Auto mSPZ;
        private Zamestnanec mId_zamestnanec;

        public static int LEN_ATTR_cena = 7;
        public static int LEN_ATTR_zaloha = 7;
        public static int LEN_ATTR_poznamka = 250;
        public static int LEN_ATTR_spz = 7;

        public int Id_pronajem
        {
            get
            {
                return mId_pronajem;
            }
            set
            {
                mId_pronajem = value;
            }
        }
        public DateTime Datum_od
        {
            get
            {
                return mDatum_od;
            }
            set
            {
                mDatum_od = value;
            }
        }
        public DateTime Datum_do
        {
            get
            {
                return mDatum_do;
            }
            set
            {
                mDatum_do = value;
            }
        }
        public int Cena
        {
            get
            {
                return mCena;
            }
            set
            {
                mCena = value;
            }
        }
        public int Zaloha
        {
            get
            {
                return mZaloha;
            }
            set
            {
                mZaloha = value;
            }
        }
        public String Poznamka
        {
            get
            {
                return mPoznamka;
            }
            set
            {
                mPoznamka = value;
            }
        }
        public Klient Id_klient
        {
            get
            {
                return mId_klient;
            }
            set
            {
                mId_klient = value;
            }
        }
        public Auto SPZ
        {
            get
            {
                return mSPZ;
            }
            set
            {
                mSPZ = value;
            }
        }
        public Zamestnanec Id_zamestnanec
        {
            get
            {
                return mId_zamestnanec;
            }
            set
            {
                mId_zamestnanec = value;
            }
        }
    }
}