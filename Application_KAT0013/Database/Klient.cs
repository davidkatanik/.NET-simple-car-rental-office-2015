using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_KAT0013.Database
{
    public class Klient
    {
        private int mId_klient;
        private String mJmeno;
        private String mPrijmeni;
        private String mRC;
        private String mTelefon;
        private String mEmail;
        private Adresa mAdresa;

        public static int LEN_ATTR_jmeno = 30;
        public static int LEN_ATTR_prijmeni = 60;
        public static int LEN_ATTR_rc = 11;
        public static int LEN_ATTR_telefon = 14;
        public static int LEN_ATTR_email = 60;

        public int Id_klient
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
        
        public Adresa Adresa
        {
            get
            {
                return mAdresa;
            }
            set
            {
                mAdresa = value;
            }
        }
    }
}