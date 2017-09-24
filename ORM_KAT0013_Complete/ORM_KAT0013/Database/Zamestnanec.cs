using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORM_KAT0013.Database
{
    public class Zamestnanec
    {
        private int mId_zamestnanec;
        private String mJmeno;
        private String mPrijmeni;
        private char mTyp;
        private String mRC;
        private String mTelefon;
        private String mEmail;
        private DateTime mDatum_nastupu;
        private DateTime mDatum_do;
        private int mPohybliva_mzda;
        private int mZakladni_mzda;
        private Adresa mId_adresa;
        private Oddeleni mId_oddeleni;

        public static int LEN_ATTR_jmeno = 30;
        public static int LEN_ATTR_prijmeni = 60;
        public static int LEN_ATTR_typ = 1;
        public static int LEN_ATTR_rc = 11;
        public static int LEN_ATTR_telefon = 14;
        public static int LEN_ATTR_email = 60;
        public static int LEN_ATTR_pohybliva_mzda = 6;
        public static int LEN_ATTR_zakladni_mzda = 6;

        public Zamestnanec()
        {
            mId_adresa = new Adresa();
            mId_oddeleni = new Oddeleni();
        }
        public int Id_zamestnanec
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
        public String Jmeno
        {
            get
            {
                return mJmeno;
            }
            set
            {
                mJmeno = value;
            }
        }
        public String Prijmeni
        {
            get
            {
                return mPrijmeni;
            }
            set
            {
                mPrijmeni = value;
            }
        }
        public char Typ
        {
            get
            {
                return mTyp;
            }
            set
            {
                mTyp = value;
            }
        }
        public String RC
        {
            get
            {
                return mRC;
            }
            set
            {
                mRC = value;
            }
        }
        public String Telefon
        {
            get
            {
                return mTelefon;
            }
            set
            {
                mTelefon = value;
            }
        }
        public String Email
        {
            get
            {
                return mEmail;
            }
            set
            {
                mEmail = value;
            }
        }
        public DateTime Datum_nastupu
        {
            get
            {
                return mDatum_nastupu;
            }
            set
            {
                mDatum_nastupu = value;
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
        public int Pohybliva_mzda
        {
            get
            {
                return mPohybliva_mzda;
            }
            set
            {
                mPohybliva_mzda = value;
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
        public Adresa Id_adresa
        {
            get
            {
                return mId_adresa;
            }
            set
            {
                mId_adresa = value;
            }
        }
        public Oddeleni Id_oddeleni
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

    }
}