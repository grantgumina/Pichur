﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{

	/// <summary>An effect that intensifies dark regions.</summary>
	public class GloomEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(GloomEffect), 0);
		public static readonly DependencyProperty GloomIntensityProperty = DependencyProperty.Register("GloomIntensity", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty BaseIntensityProperty = DependencyProperty.Register("BaseIntensity", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(1)));
		public static readonly DependencyProperty GloomSaturationProperty = DependencyProperty.Register("GloomSaturation", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(0.2D)), PixelShaderConstantCallback(2)));
		public static readonly DependencyProperty BaseSaturationProperty = DependencyProperty.Register("BaseSaturation", typeof(double), typeof(GloomEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(3)));
		public GloomEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri("/Pichur;component/Shaders/Gloom.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(GloomIntensityProperty);
			this.UpdateShaderValue(BaseIntensityProperty);
			this.UpdateShaderValue(GloomSaturationProperty);
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
		/// <summary>Intensity of the gloom image.</summary>
		public double GloomIntensity
		{
			get
			{
				return ((double)(this.GetValue(GloomIntensityProperty)));
			}
			set
			{
				this.SetValue(GloomIntensityProperty, value);
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
		/// <summary>Saturation of the gloom image.</summary>
		public double GloomSaturation
		{
			get
			{
				return ((double)(this.GetValue(GloomSaturationProperty)));
			}
			set
			{
				this.SetValue(GloomSaturationProperty, value);
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
