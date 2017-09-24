using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Application_KAT0013.Database
{
    public class Typ_auta
    {
        private int mId_typ_auta;
        private String mZnacka;
        private String mModel;
        
        public static int LEN_ATTR_znacka = 30;
        public static int LEN_ATTR_model = 30;

        public int Id_typ_auta
        {
            get
            {
                return mId_typ_auta;
            }
            set
            {
                mId_typ_auta = value;
            }
        }
        public String Znacka
        {
            get
            {
                return mZnacka;
            }
            set
            {
                mZnacka = value;
            }
        }
        public String Model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
            }
        }
    }
}