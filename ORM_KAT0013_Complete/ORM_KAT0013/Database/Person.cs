using System;
using System.Collections.Generic;
using System.Text;

namespace ORM_KAT0013.Database
{
    public class Person
    {
        private int mId;
        private String mLogin;
        private String mName;
        private String mSurname;
        private String mAddress;
        private String mTelephone;
        private int mMaximumUnfinisfedAuctions;
        private DateTime mLastVisit;
        private String mType;

        public static int LEN_ATTR_login = 10;
        public static int LEN_ATTR_name = 20;
        public static int LEN_ATTR_surname = 20;
        public static int LEN_ATTR_address = 40;
        public static int LEN_ATTR_telephone = 12;
        public static int LEN_ATTR_type = 10;

        public int Id
        {
            get
            {
                return mId;
            }
            set
            {
                mId = value;
            }
        }

        public String Login
        {
            get
            {
                return mLogin;
            }
            set
            {
                mLogin = value;
            }
        }

        public String Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }

        public String Surname
        {
            get
            {
                return mSurname;
            }
            set
            {
                mSurname = value;
            }
        }

        public String Address
        {
            get
            {
                return mAddress;
            }
            set
            {
                mAddress = value;
            }
        }

        public String Telephone
        {
            get
            {
                return mTelephone;
            }
            set
            {
                mTelephone = value;
            }
        }

        public int MaximumUnfinisfedAuctions
        {
            get
            {
                return mMaximumUnfinisfedAuctions;
            }
            set
            {
                mMaximumUnfinisfedAuctions = value;
            }
        }

        public DateTime LastVisit
        {
            get
            {
                return mLastVisit;
            }
            set
            {
                mLastVisit = value;
            }
        }


        public String Type
        {
            get
            {
                return mType;
            }
            set
            {
                mType = value;
            }
        }

        /*
        public String ToString()
        {
            return Convert.ToString(mId) + ": " + Convert.ToString(mExtension) + "(" + Convert.ToString(mMime) + ")";
        }
        */
    }
}