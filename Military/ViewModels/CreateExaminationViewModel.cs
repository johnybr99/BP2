using Military.Database;
using Military.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Military.ViewModels
{
    public class CreateExaminationViewModel : INotifyPropertyChanged
    {
        private List<Soldier> soldiersSource;
        private Soldier soldiersSourceSelected;
        private List<Medic> doctorsSource;
        private Medic doctorsSourceSelected;
        private List<Camp> campsSource;
        private Camp campsSourceSelected;
        MilitaryContainer mc = new MilitaryContainer();
        public Action CloseAction { get; set; }


        public CreateExaminationViewModel()
        {
            DoctorsSource = populateDoctors();
            SoldiersSource = populateSoldiers();
            CampsSource = populateCamps();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private List<Medic> populateDoctors()
        {
            return mc.Medics.ToList();
        }

        private List<Soldier> populateSoldiers()
        {
            return mc.Soldiers.ToList();
        }

        private List<Camp> populateCamps()
        {
            return mc.Camps.ToList();
        }

        public List<Medic> DoctorsSource
        {
            get { return doctorsSource; }
            set
            {
                if (doctorsSource != value)
                {
                    doctorsSource = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<Soldier> SoldiersSource
        {
            get { return soldiersSource; }
            set
            {
                if (soldiersSource != value)
                {
                    soldiersSource = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<Camp> CampsSource
        {
            get { return campsSource; }
            set
            {
                if (campsSource != value)
                {
                    campsSource = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Camp CampsSourceSelected
        {
            get { return campsSourceSelected; }
            set
            {
                if (campsSourceSelected != value)
                {
                    campsSourceSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Soldier SoldiersSourceSelected
        {
            get { return soldiersSourceSelected; }
            set
            {
                if (soldiersSourceSelected != value)
                {
                    soldiersSourceSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Medic DoctorsSourceSelected
        {
            get { return doctorsSourceSelected; }
            set
            {
                if (doctorsSourceSelected != value)
                {
                    doctorsSourceSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        

        public ICommand CreateExamCommand { get { return new RelayCommand(createExam, canCreateExam); } }

        private void createExam(object param)
        {
            if(DoctorsSourceSelected == null || CampsSourceSelected == null || SoldiersSourceSelected == null)
            {
                return;
            } else
            {
                mc.Examinations.Add(new Examination { Camp = CampsSourceSelected, Medic = DoctorsSourceSelected, Soldier = SoldiersSourceSelected, Id = DateTime.Now });
                mc.SaveChanges();
            }
        }

        private bool canCreateExam(object param)
        {
            return true;
        }
    }
}
