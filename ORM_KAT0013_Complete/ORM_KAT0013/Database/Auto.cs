using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORM_KAT0013.Database
{
    public class Auto
    {
        private String mSPZ;
        private int mDenni_sazba;
        private int mPorizovaci_cena;
        private int mRok_vyroby;
        private int mPocet_oprav;
        private char mStav;
        private Typ_auta mTyp_auta;

        public static int LEN_ATTR_spz = 7;
        public static int LEN_ATTR_stav = 1;

        public String SPZ
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
        public int Denni_sazba
        {
            get
            {
                return mDenni_sazba;
            }
            set
            {
                mDenni_sazba = value;
            }
        }
        public int Porizovaci_cena
        {
            get
            {
                return mPorizovaci_cena;
            }
            set
            {
                mPorizovaci_cena = value;
            }
        }
        public int Rok_vyroby
        {
            get
            {
                return mRok_vyroby;
            }
            set
            {
                mRok_vyroby = value;
            }
        }
        public int Pocet_oprav
        {
            get
            {
                return mPocet_oprav;
            }
            set
            {
                mPocet_oprav = value;
            }
        }
        public char Stav
        {
            get
            {
                return mStav;
            }
            set
            {
                mStav = value;
            }
        }
        public Typ_auta Typ_auta
        {
            get
            {
                return mTyp_auta;
            }
            set
            {
                mTyp_auta = value;
            }
        }
    }
}