using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{

	/// <summary>An effect that controls brightness and contrast.</summary>
	public class ContrastAdjustEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(ContrastAdjustEffect), 0);
		public static readonly DependencyProperty BrightnessProperty = DependencyProperty.Register("Brightness", typeof(double), typeof(ContrastAdjustEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty ContrastProperty = DependencyProperty.Register("Contrast", typeof(double), typeof(ContrastAdjustEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(1)));
		public ContrastAdjustEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri("/Pichur;component/Shaders/ContrastAdjust.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(BrightnessProperty);
			this.UpdateShaderValue(ContrastProperty);
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
		/// <summary>The brightness offset.</summary>
		public double Brightness
		{
			get
			{
				return ((double)(this.GetValue(BrightnessProperty)));
			}
			set
			{
				this.SetValue(BrightnessProperty, value);
			}
		}
		/// <summary>The contrast multiplier.</summary>
		public double Contrast
		{
			get
			{
				return ((double)(this.GetValue(ContrastProperty)));
			}
			set
			{
				this.SetValue(ContrastProperty, value);
			}
		}
	}
}
