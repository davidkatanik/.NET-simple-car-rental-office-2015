using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_KAT0013.Database
{
    public class Oprava
    {
        private DateTime mDatum_od;
        private DateTime mDatum_do;
        private Auto mSPZ;
        private Zamestnanec mId_zamestnanec;
        private int mCena;
        private String mPopis;

        public static int LEN_ATTR_spz = 7;
        public static int LEN_ATTR_popis = 250;

        public Oprava()
        {
            mId_zamestnanec = new Zamestnanec();
            mSPZ = new Auto();
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
        public String Popis
        {
            get
            {
                return mPopis;
            }
            set
            {
                mPopis = value;
            }
        }

    }
}