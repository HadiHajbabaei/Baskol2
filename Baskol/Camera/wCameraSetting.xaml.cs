using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ozeki.Camera;
using Ozeki.Media;
using System.Drawing;
using System.Drawing.Imaging;
using MyDB.BusinessLayer;
using Telerik.Windows.Controls;

namespace Baskol.Camera
{
    /// <summary>
    /// Interaction logic for wCameraSetting.xaml
    /// </summary>
    public partial class wCameraSetting : RadWindow
    {
        public wCameraSetting()
        {
            InitializeComponent();
        }
        private OzekiCamera _camera;
        private DrawingImageProvider _imageProvider;
        private MediaConnector _connector;
        private SnapshotHandler _snapshotHandler;
        private CameraURLBuilderWF _myCameraUrlBuilder;
        private MyDB.BusinessLayer.Models.Camera cam;
        private List<MyDB.BusinessLayer.Models.Camera> lstCam;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _imageProvider = new DrawingImageProvider();
            _connector = new MediaConnector();
            _myCameraUrlBuilder = new CameraURLBuilderWF();
            _snapshotHandler = new SnapshotHandler();
            cam = new MyDB.BusinessLayer.Models.Camera();
            lstCam = ClsDB<MyDB.BusinessLayer.Models.Camera>.GetAll();
            if (lstCam.Count() > 0)
            {
                TxtCamera.Text = lstCam.First().CameraURL;
                TxtMasir.Text = lstCam.First().CameraSelectedPath;
            }

        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            var result = _myCameraUrlBuilder.ShowDialog();
            TxtCamera.Text = _myCameraUrlBuilder.CameraURL;


        }

        private void btnSaveto_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                TxtMasir.Text = openFileDlg.SelectedPath;
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (cam.CameraURL != "" && cam.CameraSelectedPath != "")
            {
                if (lstCam.First().CameraSelectedPath != TxtMasir.Text || lstCam.First().CameraURL != TxtCamera.Text)
                {
                    cam = lstCam.First();
                    cam.CameraSelectedPath = TxtMasir.Text.ToString();
                    cam.CameraURL = TxtCamera.Text.ToString();
                    ClsDB<MyDB.BusinessLayer.Models.Camera>.Update(cam);
                }
              else
                {
                    cam.CameraSelectedPath = TxtMasir.Text.ToString();
                    cam.CameraURL = TxtCamera.Text.ToString();
                    ClsDB<MyDB.BusinessLayer.Models.Camera>.Insert(cam);
                }

            }
            else
            {
                clsMessageBox.MessageBoxSubject = "دوربین انتخاب نشده";
                new WinInfo().ShowDialog();
            }
        }
    }
}
