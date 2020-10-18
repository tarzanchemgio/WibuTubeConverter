﻿using WibuTubeConverter.ViewModels.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WibuTubeConverter.Models
{
    public class Mp3ViewerModel: INotifyPropertyChanged
    {
        public string Tittle 
        { 
            get => this.tittle; 
            set
            {
                this.tittle = value;
                this.OnPropertyChanged();
            }
        }
        string tittle = "";
        public string Performers 
        { 
            get => this.performers; 
            set 
            {
                this.performers = value;
                this.OnPropertyChanged();
            } 
        }
        string performers = "";
        public string Album 
        { 
            get=> this.album;
            set
            {
                this.album = value;
                this.OnPropertyChanged();
            }
        }
        string album = "";

        public bool UseSnapshot
        {
            get => useSnapshot;
            set
            {
                useSnapshot = value;
                this.OnPropertyChanged();
            }
        }
        bool useSnapshot = false;

        public CommandEventHandler<bool> UseSnapshotCommand
        {
            get
            {
                return new CommandEventHandler<bool>((isCheck) =>
                {
                    UseVidSnapshot(isCheck);
                });
            }
        }

        public double Snapshot 
        { 
            get => this.snapshot;
            set
            {
                this.snapshot = value;
                this.OnPropertyChanged();
            } 
        }
        double snapshot = 0f;

        string imagePath = "/Assets/total-black.png";
        string defaultImg = "/Assets/default_thumbnail.jpg";
        public string ImagePath 
        {
            get
            {
                if (UseSnapshot)
                    return imagePath;
                else
                    return defaultImg;
            }
            set
            {
                imagePath = value;
                this.OnPropertyChanged();
            }
        }

        public double Duration 
        { 
            get => this.duration;
            set
            {
                this.duration = value;
                this.OnPropertyChanged();
            } 
        }
        double duration = 0f;


        public Mp3ViewerModel()
        {

        }

        public void UseVidSnapshot(bool isUse)
        {
            UseSnapshot = isUse;

            OnPropertyChanged(nameof(ImagePath));
            //OnPropertyChanged(nameof(ThumbnailImage));
        }

        #region Implement INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        #endregion
    }
}
