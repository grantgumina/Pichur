using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.IO;

using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Effects;
using System.Windows.Threading;
using System.Media;

using Microsoft.Windows.Controls.Ribbon;
using Facebook;
using ImagingDevice;
using Pichur;

namespace Pichur
{
	public partial class MainWindow : RibbonWindow
	{
		private Boolean flag;
		// add own token below
		private FacebookClient client = new FacebookClient("");
		private ImageGrabber grabber;
		private IntPtr hwnd = IntPtr.Zero;
	
		private BitmapImage[] temp = new BitmapImage[4];

		private int time;
		private DispatcherTimer timer;

		public MainWindow()
		{
			temp[0] = new BitmapImage(new Uri(@"/Pichur;component/Images/Numbers/zero.png", UriKind.Relative));
			temp[1] = new BitmapImage(new Uri(@"/Pichur;component/Images/Numbers/one.png", UriKind.Relative));
			temp[2] = new BitmapImage(new Uri(@"/Pichur;component/Images/Numbers/two.png", UriKind.Relative));
			temp[3] = new BitmapImage(new Uri(@"/Pichur;component/Images/Numbers/three.png", UriKind.Relative));

			timer = new DispatcherTimer();
			timer.Interval = new TimeSpan(0, 0, 1);
			timer.Tick += new EventHandler(timerTick);

			InitializeComponent();
		}

		private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
		{
			flag = false;
			saveBtn.IsEnabled = false;
		}

		private void RibbonWindow_SourceInitialized(object sender, EventArgs e)
		{
			var hwndSource = PresentationSource.FromVisual(camImg) as HwndSource;

			if (hwndSource != null)
			{
				hwnd = hwndSource.Handle;
				grabber = new ImageGrabber(hwnd.ToInt32());
				grabber.ImageCaptured += GrabberImageCaptured;
				grabber.Start();
			}
		}

		private void GrabberImageCaptured(object source, ImageGrabberEventArgs e)
		{
			// store latest image from webcam in the CameraImage box
			camImg.Source = e.DeviceImage.ToBitmapSource();
		}

		private void captureBtn_Click(object sender, RoutedEventArgs e)
		{
			captureImage();
		}

		private void refreshBtn_Click(object sender, RoutedEventArgs e)
		{
			refreshImage();
		}

		private void e0RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = null;
		}

		private void e1RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new GrayscaleEffect();
		}

		private void e3RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new InvertColorEffect();
		}

		private void e4RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new ContrastAdjustEffect();
		}

		private void e5RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new BloomEffect();
		}

		private void e6RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new GloomEffect();
		}

		private void e7RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new BandedSwirlEffect();
		}

		private void e8RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new PinchEffect();
		}

		private void e9RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new OldMovieEffect();
		}

		private void e10RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new PixelateEffect();
		}

		private void e11RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new RippleEffect();
		}

		private void e13RibBtn_Click(object sender, RoutedEventArgs e)
		{
			camImg.Effect = new CopierEffect(); 
		}

		private void saveBtn_Click(object sender, RoutedEventArgs e)
		{
			String path = "";
			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
			dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			dlg.Filter = "Jpg|*.jpg";

			dlg.Title = "Save File";
			if (dlg.ShowDialog() == true)
			{
				path = dlg.FileName;
				var b = ConvertControlsImageToDrawingImage(camImg);
				b.Save(path);
			}
		}

		private void captureImage()
		{
			if (flag)
			{
				grabber.Start();
			}
			time = 3;
			timer.Start();
		}

		private void refreshImage()
		{
			if (flag)
			{
				grabber.Start();
				flag = false;
			}
			camImg.Effect = null;
			saveBtn.IsEnabled = false;
		}

		private void timerTick(object sender, EventArgs e)
		{
			if (time >= 0)
			{
				flag = false;
				saveBtn.IsEnabled = false;
				captureIcon.Source = temp[time];
				time--;
			}
			else
			{
				SoundPlayer player = new SoundPlayer("click.wav");
				player.Play();
				captureIcon.Source = new BitmapImage(new Uri("/Pichur;component/Images/camera.png", UriKind.Relative)); 
				grabber.Stop();
				timer.Stop();
				flag = true;
				saveBtn.IsEnabled = true;
			}
		}


		public System.Drawing.Image ConvertControlsImageToDrawingImage(System.Windows.Controls.Image imageControl)
		{
			RenderTargetBitmap rtb2 = new RenderTargetBitmap((int)(imageControl.Source.Width), (int)(imageControl.Source.Height), 96, 96, PixelFormats.Pbgra32);
			rtb2.Render(imageControl);

			PngBitmapEncoder png = new PngBitmapEncoder();
			png.Frames.Add(BitmapFrame.Create(rtb2));

			Stream ms = new MemoryStream();
			png.Save(ms);

			ms.Position = 0;

			System.Drawing.Image retImg = System.Drawing.Image.FromStream(ms);
			return retImg;
		}

		private void RibbonWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Space)
			{
				captureImage();
			}
			else if (e.Key == Key.F5 || e.Key == Key.R)
			{
				refreshImage();
			}
		}

		private void uploadBtn_Click(object sender, RoutedEventArgs e)
		{
			var facebookWindow = new FacebookWindow();
			facebookWindow.Show();
		}
	}
	/// <summary>
	/// http://stackoverflow.com/questions/94456/load-a-wpf-bitmapimage-from-a-system-drawing-bitmap
	/// </summary>
	public static class ExtensionMethods
	{
		/// <summary>
		/// Converts a <see cref="System.Drawing.Image"/> into a WPF <see cref="BitmapSource"/>.
		/// </summary>
		/// <param name="source">The source image.</param>
		/// <returns>A BitmapSource</returns>
		public static BitmapSource ToBitmapSource(this Image source)
		{
			var bitmap = new Bitmap(source);

			var bitSrc = bitmap.ToBitmapSource();

			bitmap.Dispose();

			return bitSrc;
		}

		/// <summary>
		/// Converts a <see cref="System.Drawing.Bitmap"/> into a WPF <see cref="BitmapSource"/>.
		/// </summary>
		/// <remarks>Uses GDI to do the conversion. Hence the call to the marshalled DeleteObject.
		/// </remarks>
		/// <param name="source">The source bitmap.</param>
		/// <returns>A BitmapSource</returns>
		public static BitmapSource ToBitmapSource(this Bitmap source)
		{
			BitmapSource bitSrc;

			IntPtr hBitmap = source.GetHbitmap();

			try
			{
				bitSrc = Imaging.CreateBitmapSourceFromHBitmap(
					hBitmap,
					IntPtr.Zero,
					Int32Rect.Empty,
					BitmapSizeOptions.FromEmptyOptions());
			}
			catch (Win32Exception)
			{
				bitSrc = null;
			}
			finally
			{
				NativeMethods.DeleteObject(hBitmap);
			}

			return bitSrc;
		}

		#region Nested type: NativeMethods

		/// <summary>
		/// FxCop requires all Marshalled functions to be in a class called NativeMethods.
		/// </summary>
		internal static class NativeMethods
		{
			[DllImport("gdi32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern bool DeleteObject(IntPtr hObject);
		}
		#endregion
	}
}
