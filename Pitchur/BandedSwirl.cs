﻿
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{

	/// <summary>An effect that swirls the input in alternating clockwise and counterclockwise bands.</summary>
	public class BandedSwirlEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(BandedSwirlEffect), 0);
		public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(BandedSwirlEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty BandsProperty = DependencyProperty.Register("Bands", typeof(double), typeof(BandedSwirlEffect), new UIPropertyMetadata(((double)(10D)), PixelShaderConstantCallback(1)));
		public static readonly DependencyProperty StrengthProperty = DependencyProperty.Register("Strength", typeof(double), typeof(BandedSwirlEffect), new UIPropertyMetadata(((double)(0.5D)), PixelShaderConstantCallback(2)));
		public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(BandedSwirlEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(3)));
		public BandedSwirlEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri("/Pichur;component/Shaders/BandedSwirl.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(CenterProperty);
			this.UpdateShaderValue(BandsProperty);
			this.UpdateShaderValue(StrengthProperty);
			this.UpdateShaderValue(AspectRatioProperty);
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
		/// <summary>The center of the swirl. (100,100) is lower right corner </summary>
		public Point Center
		{
			get
			{
				return ((Point)(this.GetValue(CenterProperty)));
			}
			set
			{
				this.SetValue(CenterProperty, value);
			}
		}
		/// <summary>The number of bands in the swirl.</summary>
		public double Bands
		{
			get
			{
				return ((double)(this.GetValue(BandsProperty)));
			}
			set
			{
				this.SetValue(BandsProperty, value);
			}
		}
		/// <summary>The strength of the effect.</summary>
		public double Strength
		{
			get
			{
				return ((double)(this.GetValue(StrengthProperty)));
			}
			set
			{
				this.SetValue(StrengthProperty, value);
			}
		}
		/// <summary>The aspect ratio (width / height) of the input.</summary>
		public double AspectRatio
		{
			get
			{
				return ((double)(this.GetValue(AspectRatioProperty)));
			}
			set
			{
				this.SetValue(AspectRatioProperty, value);
			}
		}
	}
}
