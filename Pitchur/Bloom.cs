using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{

	/// <summary>An effect that intensifies bright regions.</summary>
	public class BloomEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BloomEffect), 0);
		public static readonly DependencyProperty BloomIntensityProperty = DependencyProperty.Register("BloomIntensity", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty BaseIntensityProperty = DependencyProperty.Register("BaseIntensity", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(1)));
		public static readonly DependencyProperty BloomSaturationProperty = DependencyProperty.Register("BloomSaturation", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(2)));
		public static readonly DependencyProperty BaseSaturationProperty = DependencyProperty.Register("BaseSaturation", typeof(double), typeof(BloomEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(3)));
		public BloomEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri(@"/Pichur;component/Shaders/Bloom.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(BloomIntensityProperty);
			this.UpdateShaderValue(BaseIntensityProperty);
			this.UpdateShaderValue(BloomSaturationProperty);
			this.UpdateShaderValue(BaseSaturationProperty);
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
		/// <summary>Intensity of the bloom image.</summary>
		public double BloomIntensity
		{
			get
			{
				return ((double)(this.GetValue(BloomIntensityProperty)));
			}
			set
			{
				this.SetValue(BloomIntensityProperty, value);
			}
		}
		/// <summary>Intensity of the base image.</summary>
		public double BaseIntensity
		{
			get
			{
				return ((double)(this.GetValue(BaseIntensityProperty)));
			}
			set
			{
				this.SetValue(BaseIntensityProperty, value);
			}
		}
		/// <summary>Saturation of the bloom image.</summary>
		public double BloomSaturation
		{
			get
			{
				return ((double)(this.GetValue(BloomSaturationProperty)));
			}
			set
			{
				this.SetValue(BloomSaturationProperty, value);
			}
		}
		/// <summary>Saturation of the base image.</summary>
		public double BaseSaturation
		{
			get
			{
				return ((double)(this.GetValue(BaseSaturationProperty)));
			}
			set
			{
				this.SetValue(BaseSaturationProperty, value);
			}
		}
	}
}
