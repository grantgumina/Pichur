using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{

	public class CopierEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(CopierEffect), 0);
		public static readonly DependencyProperty SampleIProperty = DependencyProperty.Register("SampleI", typeof(double), typeof(CopierEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(0)));
		public CopierEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri("/Pichur;component/Shaders/Copier.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(SampleIProperty);
		}
		public Brush Input
		{
			get
			{
				return ((Brush)(this.GetValue(InputProperty)));
			}
			set
			{
				this.SetValue(InputProperty, value);
			}
		}
		public double SampleI
		{
			get
			{
				return ((double)(this.GetValue(SampleIProperty)));
			}
			set
			{
				this.SetValue(SampleIProperty, value);
			}
		}
	}
}
