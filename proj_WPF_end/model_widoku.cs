using proj_WPF_end.Baza;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

using System.ComponentModel;
using System.Diagnostics;

namespace proj_WPF_end
{
    internal class model_widoku:INotifyPropertyChanged, IDataErrorInfo
    {
        private MosttContext? context;
        public model_widoku()
        {
            Nazwa = "Witam";
            Data_pow = "1999-02-03";
            context = new MosttContext();
            dodaj_do_bazy = new comand(dodawanie_do_bazy);
            wysw_baze = new comand(wyswietl_baz);
        }

        private void wyswietl_baz(object obj)
        {
            try
            {
                var dane = context.Mosts.ToList();
                var dane_1 = context.Projekts.ToList();
                Baza = "";
                Baza1 ="";
                string newLine = Environment.NewLine;
                foreach (var item in dane)
                {
                    //if (item.NazwaMostu is null) item.NazwaMostu = "******";
                    //if (item.NumerProjektu is null) item.NumerProjektu =99999;
                    //if (item.DataPowstania is null) item.DataPowstania = new DateTime(9999, 99, 99);
                    //if (item.TypMostu is null) item.TypMostu = "******";
                    //if (item.NazwaMostu is null) item.NazwaMostu = "******";
                    //if (item.DaneTechniczne is null) item.DaneTechniczne = "******";
                    Baza += $"NAZWA:  {item.NazwaMostu}  NUMER PROJ:  {item.NumerProjektu}  Data:  {Convert.ToString(item.DataPowstania)} Typ:  {item.TypMostu} Dane techno:  {item.DaneTechniczne} {newLine}";
                }

                foreach (var item in dane_1)
                {
                    //if (item.NazwaMostu is null) item.NazwaMostu = "******";
                    //if (item.NumerProjektu is null) item.NumerProjektu =99999;
                    //if (item.DataPowstania is null) item.DataPowstania = new DateTime(9999, 99, 99);
                    //if (item.TypMostu is null) item.TypMostu = "******";
                    //if (item.NazwaMostu is null) item.NazwaMostu = "******";
                    //if (item.DaneTechniczne is null) item.DaneTechniczne = "******";
                    Baza1 += $"NUMER:  {item.NumerProjektu}  DATA:  {item.DataProjektu}  IMIE:  {item.AutorProjektuImie}   NAZWISKO:  {item.AutorProjektuNazwisko}  RODZAJ:  {item.Rodzaj} {newLine}";
                }
            }
            catch
            {
                MessageBox.Show("Blad wyswietlania bazy");
            }
        }

        private void dodawanie_do_bazy(object obj)
        {
            //MessageBox.Show("witam");
            
            if (!context.Database.EnsureCreated())
            {
                try
                {
                    var mostt = new Most();
                    var proj = new Projekt();
                    proj.NumerProjektu = Numer_p;
                    proj.DataProjektu = DateTime.Parse(Data_pow);
                    proj.AutorProjektuImie = Imie_p;
                    proj.AutorProjektuNazwisko = Nazwisko_p;
                    proj.Rodzaj = Typ_proj;
                   
                    mostt.NazwaMostu = Nazwa;
                    mostt.NumerProjektu = proj.NumerProjektu;
                    mostt.TypMostu = "Most";
                    mostt.DaneTechniczne = Opis_tech;
                    mostt.Miasto = "Brak";
                    mostt.Ulica = "Brak";
                    mostt.DataPowstania= DateTime.Parse(Data_pow);
                    context.Projekts.Add(proj);
                    context.Mosts.Add(mostt);
                    context.SaveChanges();
                    MessageBox.Show($"Dodano do bazy");
                }
                catch
                {
                    MessageBox.Show("BLEDNE DANE");
                    Process.Start(Application.ResourceAssembly.Location);
                    Application.Current.Shutdown();
                }
              
            }
            else
            {

                var mostt = new Most();
                var proj = new Projekt();
                proj.NumerProjektu = 1;
                proj.DataProjektu = DateTime.Parse("1999-01-01");
                proj.AutorProjektuImie = "Kris";
                proj.AutorProjektuNazwisko = "Kris";
                proj.Rodzaj = "Powykonawczy";
                mostt.NazwaMostu = "Golden chain";
                mostt.NumerProjektu = proj.NumerProjektu;
                mostt.TypMostu = "Most ciezki";
                mostt.DaneTechniczne = "Ciezki most transportowy";
                context.Projekts.Add(proj);
                context.Mosts.Add(mostt);
                context.SaveChanges();
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;



        private string nazwa;
        private int numer_p;
        private string data_pow;
        private string imie_p;
        private string nazwisko_p;
        private string typ_proj;
        private string opis_tech;
        private string baza;
        private string baza1;


        public ICommand dodaj_do_bazy { get; set; }
        public ICommand wysw_baze { get; set; }

        public string Nazwa
        {
            get { return nazwa; }
            set
            {
                nazwa = value;
                OnPropertyChanged();
            }
        }

        public int Numer_p
        {
            get { return numer_p; }
            set
            {
                numer_p = value;
                OnPropertyChanged();
            }
        }

        public String Data_pow
        {
            get { return data_pow; }
            set
            {
                data_pow = ( value);
                OnPropertyChanged();
            }
        }

        public string Imie_p
        {
            get { return imie_p; }
            set
            {
                imie_p = value;
                OnPropertyChanged();
            }
        }
        public string Nazwisko_p
        {
            get { return nazwisko_p; }
            set
            {
                nazwisko_p = value;
                OnPropertyChanged();
            }
        }



        public string Typ_proj
        {
            get { return typ_proj; }
            set
            {
                typ_proj = value;
                OnPropertyChanged();
            }
        }

        public string Opis_tech
        {
            get { return opis_tech; }
            set
            {
                opis_tech = value;
                OnPropertyChanged();
            }
        }

        public string Baza
        {
            get { return baza; }
            set
            {
                baza = value;
                OnPropertyChanged();
            }
        }
        public string Baza1
        {
            get { return baza1; }
            set
            {
                baza1 = value;
                OnPropertyChanged();
            }
        }


        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;


                switch (columnName)
                {
                    case nameof(Nazwa):
                        if (string.IsNullOrWhiteSpace(Nazwa))
                            error = "Nazwa nie może byc pusta";
                        if (Nazwa?.Length > 10)
                            error = "Nazwa musi byc mniejsza od 10 znakow";
                        break;

                    case nameof(Numer_p):
                        if (string.IsNullOrWhiteSpace(Convert.ToString( Numer_p)))
                            error = "Numer nie może byc pusty";
                        break;
                    case nameof(Data_pow):
                        if (string.IsNullOrWhiteSpace(Data_pow))
                            error = "Data nie moze byc pusta, format miesiac dzien, rok";
                        break;
                    case nameof(Imie_p):
                        if (string.IsNullOrWhiteSpace(Imie_p))
                            error = "Imie nie moze byc puste";
                        break;
                    case nameof(Nazwisko_p):
                        if (string.IsNullOrWhiteSpace(Nazwisko_p))
                            error = "Nazwisko nie moze byc puste";
                        break;
                    case nameof(Typ_proj):
                        if (string.IsNullOrWhiteSpace(Typ_proj))
                            error = "Typ nie moze byc pusty";
                        break;
                    case nameof(Opis_tech):
                        if (string.IsNullOrWhiteSpace(Nazwisko_p))
                            error = "Opis nie moze byc pusty";
                        break;
                }

                return error;
            }
        }

        public string Error => Error;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
