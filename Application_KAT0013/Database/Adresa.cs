using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_KAT0013.Database
{
    public class Adresa
    {
        private int mId_adresa;
        private String mMesto;
        private String mUlice;
        private String mStat;
        private String mPSC;
        private int mPocet_klientu;

        public static int LEN_ATTR_mesto = 50;
        public static int LEN_ATTR_ulice = 50;
        public static int LEN_ATTR_stat = 3;
        public static int LEN_ATTR_psc = 5;

        public int Id_adresa
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
        public String Mesto
        {
            get
            {
                return mMesto;
            }
            set
            {
                mMesto = value;
            }
        }
        public String Ulice
        {
            get
            {
                return mUlice;
            }
            set
            {
                mUlice = value;
            }
        }
        public String Stat
        {
            get
            {
                return mStat;
            }
            set
            {
                mStat = value;
            }
        }
        public String PSC
        {
            get
            {
                return mPSC;
            }
            set
            {
                mPSC = value;
            }
        }
        public int Pocet_klientu
        {
            get
            {
                return mPocet_klientu;
            }
            set
            {
                mPocet_klientu = value;
            }
        }

    }
}