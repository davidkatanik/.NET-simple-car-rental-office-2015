using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_KAT0013.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            AdresaTable adt = new AdresaTable();
            AutoTable at = new AutoTable();
            Historie_mezdTable hmt = new Historie_mezdTable();
            KlientTable kt = new KlientTable();
            OddeleniTable odt = new OddeleniTable();
            OpravaTable ot = new OpravaTable();
            PronajemTable pt = new PronajemTable();
            Typ_autaTable tat = new Typ_autaTable();
            ZamestnanecTable zt = new ZamestnanecTable();

            Console.WriteLine("Program na overeni ORM od KAT0013: ");
            while(true)
            {
                int tmp = 0;
                Console.Clear();
                Console.WriteLine("MENU: ");
                Console.WriteLine("1.   Adresa menu: ");
                Console.WriteLine("2.   Auto menu: ");
                Console.WriteLine("3.   Histori_mezd menu: ");
                Console.WriteLine("4.   Klient menu: ");
                Console.WriteLine("5.   Oddeleni menu: ");
                Console.WriteLine("6.   Oprava menu: ");
                Console.WriteLine("7.   Pronajem menu: ");
                Console.WriteLine("8.   Typ Auta menu: ");
                Console.WriteLine("9.   Zamestnanec menu: ");
                Console.WriteLine("0.   EXIT: ");
                try
                {
                    tmp = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e){
                    Console.WriteLine("Zadejte pouze cisla");
                }
                catch{
                    Console.WriteLine("Jina chyba");
                }
                if (tmp == 0) { break; }
                switch (tmp)
                {
                    case 1:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Adresa menu: ");
                                Console.WriteLine("1.   Insert: ");
                                Console.WriteLine("2.   Update s ID: ");
                                Console.WriteLine("3.   Select s ID: ");
                                Console.WriteLine("4.   Select * adres: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert adresy");
                                            Adresa a = new Adresa();
                                            Console.WriteLine("Zadejte Mesto(String):");
                                            a.Mesto = Console.ReadLine();
                                            Console.WriteLine("Zadejte Ulici(String):");
                                            a.Ulice = Console.ReadLine();
                                            Console.WriteLine("Zadejte Stat(Char(3)):");
                                            a.Stat = Console.ReadLine();
                                            Console.WriteLine("Zadejte PSC(Char(5)):");
                                            a.PSC = Console.ReadLine();
                                            a.Pocet_klientu = 0;
                                            adt.Insert(a);
                                            
                                            Console.WriteLine("Vlozeni probehlo s hodnotami:");
                                            Console.WriteLine("{0} - {1} - {2} - {3}", a.Mesto, a.Ulice, a.Stat, a.PSC);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update adresy");
                                            Adresa a = new Adresa();
                                            int id_adresy = 0;
                                            Console.WriteLine("Zadejte id upravovane adresy(Int):");
                                            try
                                            {
                                                id_adresy = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            a = adt.Select(id_adresy);
                                            Console.WriteLine("Menite adresu");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", a.Id_adresa, a.Mesto, a.Ulice, a.Stat, a.PSC);
                                            Console.WriteLine("Zadejte Mesto(String):");
                                            a.Mesto = Console.ReadLine();
                                            Console.WriteLine("Zadejte Ulici(String):");
                                            a.Ulice = Console.ReadLine();
                                            Console.WriteLine("Zadejte Stat(Char(3)):");
                                            a.Stat = Console.ReadLine();
                                            Console.WriteLine("Zadejte PSC(Char(5)):");
                                            a.PSC = Console.ReadLine();
                                            
                                            adt.Update(a);
                                            
                                            Console.WriteLine("Update probehl a hodnoty v DB jsou :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", a.Id_adresa, a.Mesto, a.Ulice, a.Stat, a.PSC);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select adresy");
                                            Adresa a = new Adresa();
                                            int id_adresy = 0;
                                            Console.WriteLine("Zadejte id adresy:");
                                            try
                                            {
                                                id_adresy = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            a = adt.Select(id_adresy);
                                            Console.WriteLine("Byla vyselektovana tato adresa:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4}", a.Id_adresa, a.Mesto, a.Ulice, a.Stat, a.PSC);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select vsech adres");
                                            Collection<Adresa> adresy= new Collection<Adresa>();
                                            adresy = adt.Select();
                                            foreach (Adresa a in adresy)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4}", a.Id_adresa, a.Mesto, a.Ulice, a.Stat, a.PSC);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 2:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Auto menu: ");
                                Console.WriteLine("1.   Insert: ");
                                Console.WriteLine("2.   Update s SPZ: ");
                                Console.WriteLine("3.   Select s SPZ: ");
                                Console.WriteLine("4.   Select * aut: ");
                                Console.WriteLine("5.   Select * v oprave: ");
                                Console.WriteLine("6.   Select * provozuschopnych: ");
                                Console.WriteLine("7.   Select * neprovozuschopnych: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert Auta");
                                            Auto a = new Auto();
                                            Console.WriteLine("Zadejte SPZ(CHAR(7)):");
                                            a.SPZ = Console.ReadLine();
                                            Console.WriteLine("Zadejte denni sazba(Int):");
                                            a.Denni_sazba = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte porizovaci cena(Int):");
                                            a.Porizovaci_cena = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte rok vyroby(Int):");
                                            a.Rok_vyroby = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte id typy auta(Int):");
                                            a.Typ_auta.Id_typ_auta = Convert.ToInt32(Console.ReadLine());
                                            a.Pocet_oprav = 0;
                                            a.Stav = 'P';

                                            at.Insert(a);
                                            Console.WriteLine("Vlozeni probehlo s hodnotami:", a.SPZ);
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update auta");
                                            Auto a = new Auto();
                                            String spz;
                                            Console.WriteLine("Zadejte SPZ(CHAR(7)) meneneho auta:");
                                            spz = Console.ReadLine();
                                            a = at.Select(spz);
                                            Console.WriteLine("Upravujete auto:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            Console.WriteLine("Zadejte novou denni sazba(Int):");
                                            a.Denni_sazba = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte novou porizovaci cena(Int):");
                                            a.Porizovaci_cena = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte novy rok vyroby(Int):");
                                            a.Rok_vyroby = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte nove id typy auta(Int):");
                                            a.Typ_auta.Id_typ_auta = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte pocet oprav(Int) meneneho auta):");
                                            a.Pocet_oprav = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte Stav(CHAR(1)):");
                                            a.Stav = Convert.ToChar(Console.ReadLine());

                                            at.Update(a);

                                            Console.WriteLine("Update probehl a hodnoty v DB jsou :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select podle SPZ");
                                            Auto a = new Auto();
                                            String spz;
                                            Console.WriteLine("Zadejte SPZ(CHAR(7)) meneneho auta:");
                                            spz = Console.ReadLine();
                                            a = at.Select(spz);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * aut");
                                            Collection<Auto> auta = new Collection<Auto>();
                                            auta = at.Select();

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Auto a in auta)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * aut v oprave");
                                            Collection<Auto> auta = new Collection<Auto>();
                                            auta = at.Select('O');

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Auto a in auta)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * provozuschopnych aut");
                                            Collection<Auto> auta = new Collection<Auto>();
                                            auta = at.Select('P');

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Auto a in auta)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * neprovoyuschopnych");
                                            Collection<Auto> auta = new Collection<Auto>();
                                            auta = at.Select('N');

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Auto a in auta)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", a.SPZ, a.Denni_sazba, a.Porizovaci_cena, a.Rok_vyroby, a.Pocet_oprav, a.Stav, a.Typ_auta.Id_typ_auta);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 3:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Histori_mezd menu: ");
                                Console.WriteLine("1.   Insert: ");
                                Console.WriteLine("2.   Update: ");
                                Console.WriteLine("3.   Select historie konkretniho zamestnance(zname pouze id_klient): ");
                                Console.WriteLine("4.   Select konkretni historie konkretniho zamestnance(zname id_klient, datum_od a datum_do): ");
                                Console.WriteLine("5.   Select * historickych zaznamu mezd: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert se provadi automaticky(trigger) pri zmene mzdy - neni specifikovano ve funkcni analyze(logicky vyplyva)");
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update neni mozne provest, je to historicka tabulka");
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select podle ID zamestnance");
                                            Collection<Historie_mezd> hm = new Collection<Historie_mezd>();
                                            int id_zamestnance = 0;
                                            Console.WriteLine("Zadejte id zamestnance(Int):");
                                            try
                                            {
                                                id_zamestnance = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }

                                            hm = hmt.Select(id_zamestnance);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Historie_mezd h in hm)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3}", h.Datum_od, h.Datum_do, h.Zamestnanec.Id_zamestnanec, h.Mzda);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select podle ID zamestnance");
                                            Historie_mezd hm = new Historie_mezd();
                                            int id_zamestnance = 0;
                                            DateTime datum_od = new DateTime();
                                            DateTime datum_do = new DateTime();
                                            try
                                            {
                                                Console.WriteLine("Zadejte id zamestnance(Int):");
                                                id_zamestnance = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Zadejte datum od(Date) / naprikad \"21.12.2004\":");
                                                datum_od = Convert.ToDateTime(Console.ReadLine());
                                                Console.WriteLine("Zadejte datum do(Date):");
                                                datum_do = Convert.ToDateTime(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }

                                            hm = hmt.Select(datum_od, datum_do,id_zamestnance);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            Console.WriteLine("{0} - {1} - {2} - {3}", hm.Datum_od, hm.Datum_do, hm.Zamestnanec.Id_zamestnanec, hm.Mzda);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select vsech historii mezd");
                                            Collection<Historie_mezd> hm = new Collection<Historie_mezd>();
                                           
                                            hm = hmt.Select();

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Historie_mezd h in hm)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3}", h.Datum_od, h.Datum_do, h.Zamestnanec.Id_zamestnanec, h.Mzda);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 4:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Klient menu: ");
                                Console.WriteLine("1.   Insert s existujici adresou: ");
                                Console.WriteLine("2.   Insert s neexistujici adresou: ");
                                Console.WriteLine("3.   Update adresy ID klienta:");
                                Console.WriteLine("4.   Update s ID klienta: ");
                                Console.WriteLine("5.   Delete s ID klienta: ");
                                Console.WriteLine("6.   Select s ID klienta: ");
                                Console.WriteLine("7.   Select * klientu: ");
                                Console.WriteLine("8.   Select * klientu podle jmena: ");
                                Console.WriteLine("9.   Select * klientu podle prijmeni: ");
                                Console.WriteLine("10.   Select * klientu podle rc: ");
                                Console.WriteLine("11.   Select * klientu podle ID Adresy: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert klienta s existujici adresou");
                                            Klient k = new Klient();
                                            Console.WriteLine("Zadejte jmeno(String):");
                                            k.Jmeno = Console.ReadLine();
                                            Console.WriteLine("Zadejte prijmeni(String):");
                                            k.Prijmeni = Console.ReadLine();
                                            Console.WriteLine("Zadejte RC (Char(11)):");
                                            k.RC = Console.ReadLine();
                                            Console.WriteLine("Zadejte telefon(Char(14)):");
                                            k.Telefon = Console.ReadLine();
                                            Console.WriteLine("Zadejte email(String):");
                                            k.Email = Console.ReadLine();
                                            Console.WriteLine("Zadejte id adresa(Int):");
                                            k.Adresa = adt.Select(Convert.ToInt32(Console.ReadLine()));

                                            kt.Insert(k);
                                            Console.WriteLine("Vlozeni probehlo s hodnotami");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}",k.Jmeno,k.Prijmeni,k.RC,k.Telefon,k.Email,k.Adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert klienta s neexistujici adresou");
                                            Klient k = new Klient();
                                            Console.WriteLine("Zadejte jmeno(String):");
                                            k.Jmeno = Console.ReadLine();
                                            Console.WriteLine("Zadejte prijmeni(String):");
                                            k.Prijmeni = Console.ReadLine();
                                            Console.WriteLine("Zadejte RC (Char(11)):");
                                            k.RC = Console.ReadLine();
                                            Console.WriteLine("Zadejte telefon(Char(14)):");
                                            k.Telefon = Console.ReadLine();
                                            Console.WriteLine("Zadejte email(String):");
                                            k.Email = Console.ReadLine();
                                            Adresa a = new Adresa();
                                            Console.WriteLine("Zadejte Mesto(String):");
                                            a.Mesto = Console.ReadLine();
                                            Console.WriteLine("Zadejte Ulici(String):");
                                            a.Ulice = Console.ReadLine();
                                            Console.WriteLine("Zadejte Stat(Char(3)):");
                                            a.Stat = Console.ReadLine();
                                            Console.WriteLine("Zadejte PSC(Char(5)):");
                                            a.PSC = Console.ReadLine();
                                            a.Pocet_klientu = 0;
              
                                            adt.Insert(a);
                                            k.Adresa = adt.SelectLast();

                                            kt.Insert(k);
                                            Console.WriteLine("Vlozeni probehlo s hodnotami");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update adresy s ID klienta");
                                            Klient k = new Klient();
                                            int id_klient = 0;
                                            Console.WriteLine("Zadejte id klienta(Int):");
                                            try
                                            {
                                                id_klient = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            Adresa a = new Adresa();
                                            Console.WriteLine("Zadejte Mesto(String):");
                                            a.Mesto = Console.ReadLine();
                                            Console.WriteLine("Zadejte Ulici(String):");
                                            a.Ulice = Console.ReadLine();
                                            Console.WriteLine("Zadejte Stat(Char(3)):");
                                            a.Stat = Console.ReadLine();
                                            Console.WriteLine("Zadejte PSC(Char(5)):");
                                            a.PSC = Console.ReadLine();
                                            a.Pocet_klientu = 0;

                                            kt.AktualizaceAdresy(id_klient,a.Mesto,a.Ulice,a.Stat,a.PSC);

                                            Console.WriteLine("Update adresy probehl:");
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update s ID klienta");
                                            Klient k = new Klient();
                                            int id_klient = 0;
                                            Console.WriteLine("Zadejte id klienta(Int):");
                                            try
                                            {
                                                id_klient = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            k = kt.Select(id_klient);
                                            Console.WriteLine("Upravujete klienta:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            Console.WriteLine("Zadejte nove jmeno(String):");
                                            k.Jmeno = Console.ReadLine();
                                            Console.WriteLine("Zadejte nove prijmeni(String):");
                                            k.Prijmeni = Console.ReadLine();
                                            Console.WriteLine("Zadejte nove RC (Char(11)):");
                                            k.RC = Console.ReadLine();
                                            Console.WriteLine("Zadejte novy telefon(Char(14)):");
                                            k.Telefon = Console.ReadLine();
                                            Console.WriteLine("Zadejte novy email(String):");
                                            k.Email = Console.ReadLine();

                                            k.Id_klient = kt.Update(k);

                                            Console.WriteLine("Update probehl a hodnoty v DB jsou :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Delete ID klienta:");
                                            int id_klient = 0;
                                            Console.WriteLine("Zadejte id klienta(Int):");
                                            try
                                            {
                                                id_klient = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }

                                            kt.SmazKlienta(id_klient);

                                            Console.WriteLine("Smazani(zaloha klienta jeho adresy a pronajmu) probehlo");
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select podle ID klienta");
                                            Klient k = new Klient();
                                            Console.WriteLine("Zadejte id zamestnance(Int):");
                                            try
                                            {
                                                k.Id_klient = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }

                                            k = kt.Select(k.Id_klient);

                                            Console.WriteLine("Vyselektovane data jsou :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * klientu:");
                                            Collection<Klient> klienti = new Collection<Klient>();

                                            klienti = kt.Select();

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Klient k in klienti)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 8:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * klientu podle jmena:");
                                            Collection<Klient> klienti = new Collection<Klient>();
                                            Console.WriteLine("Zadejte jmeno(String):");
                                            string jmeno = Console.ReadLine();


                                            klienti = kt.SelectJmeno(jmeno);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Klient k in klienti)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 9:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * klientu podle prijmeni:");
                                            Collection<Klient> klienti = new Collection<Klient>();
                                            Console.WriteLine("Zadejte prijmeni(String):");
                                            string prijmeni = Console.ReadLine();


                                            klienti = kt.SelectPrijmeni(prijmeni);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Klient k in klienti)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 10:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * klientu podle rc:");
                                            Collection<Klient> klienti = new Collection<Klient>();
                                            Console.WriteLine("Zadejte rc(char(11)):");
                                            string rc = Console.ReadLine();


                                            klienti = kt.SelectRC(rc);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Klient k in klienti)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 11:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * klientu podle ID adresy:");
                                            Collection<Klient> klienti = new Collection<Klient>();
                                            Console.WriteLine("Zadejte ID adresy(Int):");
                                            int ida = Convert.ToInt32(Console.ReadLine());


                                            klienti = kt.SelectIdAdresa(ida);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Klient k in klienti)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6}", k.Id_klient, k.Jmeno, k.Prijmeni, k.RC, k.Telefon, k.Email, k.Adresa.Id_adresa);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 5:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Oddeleni menu: ");
                                Console.WriteLine("1.   Insert: ");
                                Console.WriteLine("2.   Update nazvu oddeleni s ID oddeleni: ");
                                Console.WriteLine("3.   Select ID oddeleni: ");
                                Console.WriteLine("4.   Select * oddeleni: ");
                                Console.WriteLine("5.   Zmena platu v oddeleni ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert oddeleni");
                                            Oddeleni o = new Oddeleni();
                                            Console.WriteLine("Zadejte nazev(String):");
                                            o.Nazev = Console.ReadLine();
                                            Console.WriteLine("Zadejte zakladni mzdu na oddeleni(Int):");
                                            o.Zakladni_mzda = Convert.ToInt32(Console.ReadLine());


                                            odt.Insert(o);
                                            Oddeleni od = odt.Select(o.Id_oddeleni);
                                            Console.WriteLine("Vlozeni probehlo s hodnotami");
                                            Console.WriteLine("{0} - {1}", o.Nazev, o.Zakladni_mzda);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update nazvu oddeleni s ID oddeleni");
                                            Console.WriteLine("Zadejte id oddeleni(Int):");
                                            int ido = Convert.ToInt32(Console.ReadLine());
                                            Oddeleni o = odt.Select(ido);

                                            Console.WriteLine("Zadejte nazev(String):");
                                            o.Nazev = Console.ReadLine();

                                            o.Id_oddeleni = odt.Update(o);

                                            Console.WriteLine("Update probehl a hodnoty v DB jsou :");
                                            Console.WriteLine("{0} - {1} - {2}", o.Id_oddeleni, o.Nazev, o.Zakladni_mzda);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select ID oddeleni:");
                                            Oddeleni o = new Oddeleni();
                                            int ido = 0;
                                            Console.WriteLine("Zadejte id oddeleni(Int):");
                                            try
                                            {
                                                ido = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }

                                            o = odt.Select(ido);

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            Console.WriteLine("{0} - {1} - {2}", o.Id_oddeleni, o.Nazev, o.Zakladni_mzda);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * oddeleni");
                                            Collection<Oddeleni> oddeleni = new Collection<Oddeleni>();

                                            oddeleni = odt.Select();

                                            Console.WriteLine("Vyselektovane hodnoty: ");
                                            foreach (Oddeleni o in oddeleni)
                                            {
                                                Console.WriteLine("{0} - {1} - {2}", o.Id_oddeleni, o.Nazev, o.Zakladni_mzda);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Zmena platu v oddeleni");
                                            int ido = 0;
                                            int mzda = 0;
                                            try
                                            {
                                                Console.WriteLine("Zadejte id oddeleni(Int):");
                                                ido = Convert.ToInt32(Console.ReadLine());
                                                Console.WriteLine("Zadejte novy zakladni plat(Int):");
                                                mzda = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }

                                            odt.ZmenPlatyVOddeleni(ido, mzda);

                                            Console.WriteLine("Hodnota minimalni mzdy byla zmenena(i u zamestnancu): ");
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 6:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Oprava menu: ");
                                Console.WriteLine("1.   Insert: ");
                                Console.WriteLine("2.   Update ceny a popisu u konkretni opravy: ");
                                Console.WriteLine("3.   Select konkretni opravy: ");
                                Console.WriteLine("4.   Select * oprav: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert opravy");
                                            Oprava o = new Oprava();
                                            Console.WriteLine("Zadejte datum pocatku opravy(Date):");
                                            o.Datum_od = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte datum konce opravy(Date):");
                                            o.Datum_do = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte SPZ auta(Char(7)):");
                                            o.SPZ = at.Select(Console.ReadLine());
                                            Console.WriteLine("Zadejte ID zamestnance(Int):");
                                            o.Id_zamestnanec = zt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Console.WriteLine("Zadejte cenu opravy(Int):");
                                            o.Cena = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte popis opravy(string):");
                                            o.Popis = Console.ReadLine();

                                            ot.Insert(o);
                                            Oprava op = new Oprava();
                                            op = ot.Select(o.Datum_od, o.Datum_do, o.SPZ.SPZ, o.Id_zamestnanec.Id_zamestnanec);
                                            Console.WriteLine("Vlozeni probehlo s hodnotami :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", op.Datum_od, op.Datum_do, op.SPZ.SPZ, op.Id_zamestnanec.Id_zamestnanec, op.Cena, op.Popis);
                                            
                                            
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update ceny a popisu u konkretni opravy:");
                                            Oprava o = new Oprava();
                                            Console.WriteLine("Zadejte datum pocatku opravy(Date):");
                                            o.Datum_od = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte datum konce opravy(Date):");
                                            o.Datum_do = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte SPZ auta(Char(7)):");
                                            o.SPZ = at.Select(Console.ReadLine());
                                            Console.WriteLine("Zadejte ID zamestnance(Int):");
                                            o.Id_zamestnanec = zt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Oprava op = ot.Select(o.Datum_od,o.Datum_do,o.SPZ.SPZ,o.Id_zamestnanec.Id_zamestnanec);
                                            Console.WriteLine("Upravujete tuto opravu:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", op.Datum_od, op.Datum_do, op.SPZ.SPZ, op.Id_zamestnanec.Id_zamestnanec, op.Cena, op.Popis);
                                            Console.WriteLine("Zadejte novou cenu opravy(Int):");
                                            op.Cena = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte novy popis opravy(string):");
                                            op.Popis = Console.ReadLine();

                                            ot.Update(op);

                                            Console.WriteLine("Update probehl s hodnotami :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", op.Datum_od, op.Datum_do, op.SPZ.SPZ, op.Id_zamestnanec.Id_zamestnanec, op.Cena, op.Popis);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update ceny a popisu u konkretni opravy:");
                                            Oprava o = new Oprava();
                                            Console.WriteLine("Zadejte datum pocatku opravy(Date):");
                                            o.Datum_od = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte datum konce opravy(Date):");
                                            o.Datum_do = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte SPZ auta(Char(7)):");
                                            o.SPZ = at.Select(Console.ReadLine());
                                            Console.WriteLine("Zadejte ID zamestnance(Int):");
                                            o.Id_zamestnanec = zt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Oprava op = ot.Select(o.Datum_od, o.Datum_do, o.SPZ.SPZ, o.Id_zamestnanec.Id_zamestnanec);

                                            Console.WriteLine("Hodnoty v DB jsou:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", op.Datum_od, op.Datum_do, op.SPZ.SPZ, op.Id_zamestnanec.Id_zamestnanec, op.Cena, op.Popis);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update ceny a popisu u konkretni opravy:");
                                            Console.WriteLine("Zadejte id oddeleni(Int):");
                                            Collection<Oprava> opravy = new Collection<Oprava>();

                                            opravy = ot.Select();

                                            Console.WriteLine("Hodnoty v DB jsou:");
                                            foreach (Oprava op in opravy)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", op.Datum_od, op.Datum_do, op.SPZ.SPZ, op.Id_zamestnanec.Id_zamestnanec, op.Cena, op.Popis);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 7:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Pronajem menu: ");
                                Console.WriteLine("1.   Insert: ");
                                Console.WriteLine("2.   Update pronajmu s ID pronajmu: ");
                                Console.WriteLine("3.   Delete pronajmu s ID pronajmu: ");
                                Console.WriteLine("4.   Select s ID pronajmu: ");
                                Console.WriteLine("5.   Select * pronajmu: ");
                                Console.WriteLine("6.   Select * probehnutych pronajmu: ");
                                Console.WriteLine("7.   Select * aktualnich pronajmu: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert pronajmu:");
                                            Pronajem p = new Pronajem();
                                            Console.WriteLine("Zadejte datum pocatku pronajmu(Date):");
                                            p.Datum_od = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte datum konce pronajmu(Date):");
                                            p.Datum_do = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte zalohu pronajmu(Int):");
                                            p.Zaloha = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte SPZ auta(Char(7)):");
                                            p.SPZ = at.Select(Console.ReadLine());
                                            Console.WriteLine("Zadejte ID klienta(Int):");
                                            p.Id_klient = kt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Console.WriteLine("Zadejte ID zamestnance(Int):");
                                            p.Id_zamestnanec = zt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Console.WriteLine("Zadejte poznamku k pronajmu(string):");
                                            p.Poznamka = Console.ReadLine();
                                            p.Cena = p.SPZ.Denni_sazba * (int)(p.Datum_do - p.Datum_od).TotalDays;

                                            pt.Insert(p);
                             
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update pronajmu s ID pronajmu:");
                                            Console.WriteLine("Zadejte id pronajmu(Int):");
                                            Pronajem p = new Pronajem();
                                            p = pt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Console.WriteLine("Upravujete tento pronajem:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}", p.Id_pronajem, p.Datum_od, p.Datum_do, p.Cena, p.Zaloha, p.Poznamka, p.Id_klient.Id_klient, p.SPZ.SPZ, p.Id_zamestnanec.Id_zamestnanec);
                                            
                                            Console.WriteLine("Zadejte datum pocatku pronajmu(Date):");
                                            p.Datum_od = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte datum konce pronajmu(Date):");
                                            p.Datum_do = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte zalohu pronajmu(Int):");
                                            p.Zaloha = Convert.ToInt32(Console.ReadLine());
                                            Console.WriteLine("Zadejte SPZ auta(Char(7)):");
                                            p.SPZ = at.Select(Console.ReadLine());
                                            Console.WriteLine("Zadejte ID klienta(Int):");
                                            p.Id_klient = kt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Console.WriteLine("Zadejte ID zamestnance(Int):");
                                            p.Id_zamestnanec = zt.Select(Convert.ToInt32(Console.ReadLine()));
                                            Console.WriteLine("Zadejte poznamku k pronajmu(string):");
                                            p.Poznamka = Console.ReadLine();
                                            p.Cena = p.SPZ.Denni_sazba * (int)(p.Datum_do - p.Datum_od).TotalDays;

                                            pt.Update(p);

                                            Console.WriteLine("Update probehl s hodnotami :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}", p.Id_pronajem, p.Datum_od, p.Datum_do, p.Cena, p.Zaloha, p.Poznamka, p.Id_klient.Id_klient, p.SPZ.SPZ, p.Id_zamestnanec.Id_zamestnanec);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update pronajmu s ID pronajmu:");
                                            Console.WriteLine("Zadejte id pronajmu(Int):");
                                            int id = (Convert.ToInt32(Console.ReadLine()));
                                            
                                            pt.Delete(id);

                                            Console.WriteLine("Delete probehl vporadku");
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select s ID pronajmu:");
                                            Console.WriteLine("Zadejte id pronajmu (Int):");
                                            Pronajem p = new Pronajem();
                                            int id = (Convert.ToInt32(Console.ReadLine()));

                                            p = pt.Select(id);

                                            Console.WriteLine("Vyselektovane hodnotz z DB :");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}", p.Id_pronajem, p.Datum_od, p.Datum_do, p.Cena, p.Zaloha, p.Poznamka, p.Id_klient.Id_klient, p.SPZ.SPZ, p.Id_zamestnanec.Id_zamestnanec);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * pronajmu:");
                                            Collection<Pronajem> pronajmy = new Collection<Pronajem>();

                                            pronajmy = pt.Select();

                                            Console.WriteLine("Hodnoty v DB jsou:");
                                            foreach (Pronajem p in pronajmy)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}", p.Id_pronajem, p.Datum_od, p.Datum_do, p.Cena, p.Zaloha,p.Poznamka, p.Id_klient.Id_klient, p.SPZ.SPZ, p.Id_zamestnanec.Id_zamestnanec);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * skoncenych pronajmu:");
                                            Collection<Pronajem> pronajmy = new Collection<Pronajem>();

                                            pronajmy = pt.SelectOld();

                                            Console.WriteLine("Hodnoty v DB jsou:");
                                            foreach (Pronajem p in pronajmy)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}", p.Id_pronajem, p.Datum_od, p.Datum_do, p.Cena, p.Zaloha, p.Poznamka, p.Id_klient.Id_klient, p.SPZ.SPZ, p.Id_zamestnanec.Id_zamestnanec);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 7:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select * aktualnich pronajmu:");
                                            Collection<Pronajem> pronajmy = new Collection<Pronajem>();

                                            pronajmy = pt.SelectActual();

                                            Console.WriteLine("Hodnoty v DB jsou:");
                                            foreach (Pronajem p in pronajmy)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8}", p.Id_pronajem, p.Datum_od, p.Datum_do, p.Cena, p.Zaloha, p.Poznamka, p.Id_klient.Id_klient, p.SPZ.SPZ, p.Id_zamestnanec.Id_zamestnanec);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 8:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Typ Auta menu: ");
                                Console.WriteLine("1.   Insert: ");
                                Console.WriteLine("2.   Update s ID: ");
                                Console.WriteLine("3.   Select s ID: ");
                                Console.WriteLine("4.   Select * typů aut: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert typu auta");
                                            Typ_auta ta = new Typ_auta();
                                            Console.WriteLine("Zadejte znacku(String):");
                                            ta.Znacka = Console.ReadLine();
                                            Console.WriteLine("Zadejte model(String):");
                                            ta.Model = Console.ReadLine();

                                            tat.Insert(ta);

                                            Console.WriteLine("Vlozeni probehlo s hodnotami:");
                                            Console.WriteLine("{0} - {1}", ta.Znacka, ta.Model);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update Typu auta");
                                            Typ_auta ta = new Typ_auta();
                                            int idt = 0;
                                            Console.WriteLine("Zadejte id upravovaneho typu auta(Int):");
                                            try
                                            {
                                                idt = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            ta = tat.Select(idt);
                                            Console.WriteLine("Upravujete tento typ auta");
                                            Console.WriteLine("{0} - {1}", ta.Znacka, ta.Model);
                                            Console.WriteLine("Zadejte znacku(String):");
                                            ta.Znacka = Console.ReadLine();
                                            Console.WriteLine("Zadejte model(String):");
                                            ta.Model = Console.ReadLine();

                                            tat.Update(ta);

                                            Console.WriteLine("Update probehl s hodnotami:");
                                            Console.WriteLine("{0} - {1} - {2}", ta.Id_typ_auta, ta.Znacka, ta.Model);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select typu auta");
                                            Typ_auta ta = new Typ_auta();
                                            int idt = 0;
                                            Console.WriteLine("Zadejte id typu auta:");
                                            try
                                            {
                                                idt = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            ta = tat.Select(idt);

                                            Console.WriteLine("Z DB bylo vyselektovano:");
                                            Console.WriteLine("{0} - {1} - {2}", ta.Id_typ_auta, ta.Znacka, ta.Model);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select vsech adres");
                                            Collection<Typ_auta> taut = new Collection<Typ_auta>();
                                            taut = tat.Select();
                                            Console.WriteLine("Z DB bylo vyselektovano:");
                                            foreach (Typ_auta ta in taut)
                                            {
                                                Console.WriteLine("{0} - {1} - {2}", ta.Id_typ_auta, ta.Znacka, ta.Model);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                    case 9:
                        {
                            while (true)
                            {
                                int tmp2 = 0;
                                Console.Clear();
                                Console.WriteLine("Zamestnanec menu: ");
                                Console.WriteLine("1.   Insert s existujici adresou: ");
                                Console.WriteLine("2.   Insert s neexistujici adresou: ");
                                Console.WriteLine("3.   Update s ID: ");
                                Console.WriteLine("4.   Select s ID: ");
                                Console.WriteLine("5.   Select * zamestnancu: ");
                                Console.WriteLine("6.   Souhrn zamestnance s ID: ");
                                Console.WriteLine("0.   EXIT ");
                                try
                                {
                                    tmp2 = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException e)
                                {
                                    Console.WriteLine("Zadejte pouze cisla");
                                }
                                catch
                                {
                                    Console.WriteLine("Jina chyba");
                                }
                                if (tmp2 == 0) { break; }

                                switch (tmp2)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert zamestnance s existujici adresou");
                                            Zamestnanec z = new Zamestnanec();
                                            Console.WriteLine("Zadejte jmeno(String):");
                                            z.Jmeno = Console.ReadLine();
                                            Console.WriteLine("Zadejte prijmeni(String):");
                                            z.Prijmeni = Console.ReadLine();
                                            Console.WriteLine("Zadejte typ(Char(1)):");
                                            z.Typ = Convert.ToChar(Console.ReadLine());
                                            Console.WriteLine("Zadejte RC (Char(11)):");
                                            z.RC = Console.ReadLine();
                                            Console.WriteLine("Zadejte telefon(Char(14)):");
                                            z.Telefon = Console.ReadLine();
                                            Console.WriteLine("Zadejte email(String):");
                                            z.Email = Console.ReadLine();
                                            Console.WriteLine("Zadejte datum nastupu(Date):");
                                            z.Datum_nastupu = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte pohyblivou mzdu(Int):");
                                            z.Pohybliva_mzda = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Zadejte id oddeleni(Int):");
                                            z.Id_oddeleni = odt.Select(Convert.ToInt32(Console.ReadLine()));

                                            z.Zakladni_mzda = z.Id_oddeleni.Zakladni_mzda;
                                            Console.WriteLine("Zadejte id adresa(Int):");
                                            z.Id_adresa = adt.Select(Convert.ToInt32(Console.ReadLine()));

                                            zt.Insert(z);

                                            Console.WriteLine("Vlozeni probehlo s hodnotami:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10}", z.Jmeno, z.Prijmeni, z.Typ, z.RC, z.Telefon, z.Email, z.Datum_nastupu, z.Pohybliva_mzda, z.Zakladni_mzda, z.Id_oddeleni.Id_oddeleni, z.Id_adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Insert zamestnance s neexistujici adresou");
                                            Zamestnanec z = new Zamestnanec();
                                            Console.WriteLine("Zadejte jmeno(String):");
                                            z.Jmeno = Console.ReadLine();
                                            Console.WriteLine("Zadejte prijmeni(String):");
                                            z.Prijmeni = Console.ReadLine();
                                            Console.WriteLine("Zadejte typ(Char(1)):");
                                            z.Typ = Convert.ToChar(Console.ReadLine());
                                            Console.WriteLine("Zadejte RC (Char(11)):");
                                            z.RC = Console.ReadLine();
                                            Console.WriteLine("Zadejte telefon(Char(14)):");
                                            z.Telefon = Console.ReadLine();
                                            Console.WriteLine("Zadejte email(String):");
                                            z.Email = Console.ReadLine();
                                            Console.WriteLine("Zadejte datum nastupu(Date):");
                                            z.Datum_nastupu = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte pohyblivou mzdu(Int):");
                                            z.Pohybliva_mzda = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Zadejte id oddeleni(Int):");
                                            z.Id_oddeleni = odt.Select(Convert.ToInt32(Console.ReadLine()));

                                            z.Zakladni_mzda = z.Id_oddeleni.Zakladni_mzda;
                                            Adresa a = new Adresa();
                                            Console.WriteLine("Zadejte Mesto(String):");
                                            a.Mesto = Console.ReadLine();
                                            Console.WriteLine("Zadejte Ulici(String):");
                                            a.Ulice = Console.ReadLine();
                                            Console.WriteLine("Zadejte Stat(Char(3)):");
                                            a.Stat = Console.ReadLine();
                                            Console.WriteLine("Zadejte PSC(Char(5)):");
                                            a.PSC = Console.ReadLine();
                                            a.Pocet_klientu = 0;
                                            a.Id_adresa = adt.Insert(a);
                                            z.Id_adresa = a;

                                            zt.Insert(z);

                                            Console.WriteLine("Vlozeni probehlo s hodnotami:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10}", z.Jmeno, z.Prijmeni, z.Typ, z.RC, z.Telefon, z.Email, z.Datum_nastupu, z.Pohybliva_mzda, z.Zakladni_mzda, z.Id_oddeleni.Id_oddeleni, z.Id_adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Update zamestnance");
                                            Zamestnanec z = new Zamestnanec();
                                            int idz = 0;
                                            Console.WriteLine("Zadejte id upravovaneho zamestnance(Int):");
                                            try
                                            {
                                                idz = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            z = zt.Select(idz);
                                            Console.WriteLine("Upravujete zamestnance:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10}", z.Jmeno, z.Prijmeni, z.Typ, z.RC, z.Telefon, z.Email, z.Datum_nastupu, z.Pohybliva_mzda, z.Zakladni_mzda, z.Id_oddeleni.Id_oddeleni, z.Id_adresa.Id_adresa);
                                            Console.WriteLine("Zadejte jmeno(String):");
                                            z.Jmeno = Console.ReadLine();
                                            Console.WriteLine("Zadejte prijmeni(String):");
                                            z.Prijmeni = Console.ReadLine();
                                            Console.WriteLine("Zadejte typ(Char(1)):");
                                            z.Typ = Convert.ToChar(Console.ReadLine());
                                            Console.WriteLine("Zadejte RC (Char(11)):");
                                            z.RC = Console.ReadLine();
                                            Console.WriteLine("Zadejte telefon(Char(14)):");
                                            z.Telefon = Console.ReadLine();
                                            Console.WriteLine("Zadejte email(String):");
                                            z.Email = Console.ReadLine();
                                            Console.WriteLine("Zadejte datum nastupu(Date):");
                                            z.Datum_nastupu = Convert.ToDateTime(Console.ReadLine());
                                            Console.WriteLine("Zadejte pohyblivou mzdu(Int):");
                                            z.Pohybliva_mzda = Convert.ToInt32(Console.ReadLine());

                                            Console.WriteLine("Zadejte id oddeleni(Int):");
                                            z.Id_oddeleni = odt.Select(Convert.ToInt32(Console.ReadLine()));

                                            z.Zakladni_mzda = z.Id_oddeleni.Zakladni_mzda;

                                            Console.WriteLine("Zadejte Mesto(String):");
                                            z.Id_adresa.Mesto = Console.ReadLine();
                                            Console.WriteLine("Zadejte Ulici(String):");
                                            z.Id_adresa.Ulice = Console.ReadLine();
                                            Console.WriteLine("Zadejte Stat(Char(3)):");
                                            z.Id_adresa.Stat = Console.ReadLine();
                                            Console.WriteLine("Zadejte PSC(Char(5)):");
                                            z.Id_adresa.PSC = Console.ReadLine();

                                            zt.Update(z);
                                            adt.Update(z.Id_adresa);

                                            Console.WriteLine("Update probehl s hodnotami:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10} - {11}", z.Id_zamestnanec, z.Jmeno, z.Prijmeni, z.Typ, z.RC, z.Telefon, z.Email, z.Datum_nastupu, z.Pohybliva_mzda, z.Zakladni_mzda, z.Id_oddeleni.Id_oddeleni, z.Id_adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select zamestnance");
                                            Zamestnanec z = new Zamestnanec();
                                            int idz = 0;
                                            Console.WriteLine("Zadejte id typu auta:");
                                            try
                                            {
                                                idz = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            z=zt.Select(idz);

                                            Console.WriteLine("Update probehl s hodnotami:");
                                            Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10} - {11}", z.Id_zamestnanec, z.Jmeno, z.Prijmeni, z.Typ, z.RC, z.Telefon, z.Email, z.Datum_nastupu, z.Pohybliva_mzda, z.Zakladni_mzda, z.Id_oddeleni.Id_oddeleni, z.Id_adresa.Id_adresa);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Select vsech zamestnancu");
                                            Collection<Zamestnanec> zamestnanci = new Collection<Zamestnanec>();
                                            zamestnanci = zt.Select();
                                            Console.WriteLine("Z DB bylo vyselektovano:");
                                            foreach (Zamestnanec z in zamestnanci)
                                            {
                                                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5} - {6} - {7} - {8} - {9} - {10} - {11}", z.Id_zamestnanec, z.Jmeno, z.Prijmeni, z.Typ, z.RC, z.Telefon, z.Email, z.Datum_nastupu, z.Pohybliva_mzda, z.Zakladni_mzda, z.Id_oddeleni.Id_oddeleni, z.Id_adresa.Id_adresa);
                                            }
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                    case 6:
                                        {
                                            Console.Clear();
                                            Console.WriteLine("Souhrn zamestnance");
                                            Zamestnanec z = new Zamestnanec();
                                            int idz = 0;
                                            Console.WriteLine("Zadejte id typu auta:");
                                            try
                                            {
                                                idz = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Chyba pri zadani ID");
                                            }
                                            zt.SouhrnZamestnance(idz);
                                            Console.WriteLine("Pro pokracovani stisknete libovolnou klavesu");
                                            Console.ReadKey();
                                            break;
                                        }
                                }

                            }
                            break;
                        }
                }
                
                Console.WriteLine();
                Console.WriteLine(tmp);
                Console.WriteLine();

            }
        }
    }
}
