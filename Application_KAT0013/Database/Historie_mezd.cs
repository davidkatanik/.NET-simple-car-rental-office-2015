using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_KAT0013.Database
{
    public class Historie_mezd
    {
        private DateTime mDatum_od;
        private DateTime mDatum_do;
        private Zamestnanec mZamestnanec;
        private double mMzda;

        public static int LEN_ATTR_mzda = 6;

        public Historie_mezd()
        {
            mZamestnanec = new Zamestnanec();
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
        public Zamestnanec Zamestnanec
        {
            get
            {
                return mZamestnanec;
            }
            set
            {
                mZamestnanec = value;
            }
        }
        public double Mzda
        {
            get
            {
                return mMzda;
            }
            set
            {
                mMzda = value;
            }
        }
    }
}