using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_KAT0013.Database
{
    public class Oddeleni
    {
        private int mId_oddeleni;
        private String mNazev;
        private int mZakladni_mzda;

        public static int LEN_ATTR_nazev = 60;
        public static int LEN_ATTR_zakladni_mzda = 6;

        public int Id_oddeleni
        {
            get
            {
                return mId_oddeleni;
            }
            set
            {
                mId_oddeleni = value;
            }
        }
        public String Nazev
        {
            get
            {
                return mNazev;
            }
            set
            {
                mNazev = value;
            }
        }
        public int Zakladni_mzda
        {
            get
            {
                return mZakladni_mzda;
            }
            set
            {
                mZakladni_mzda = value;
            }
        }
    }
}