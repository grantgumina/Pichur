﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{
	/// <summary>An effect that superimposes rippling waves upon the input.</summary>
	public class RippleEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(RippleEffect), 0);
		public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(RippleEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty AmplitudeProperty = DependencyProperty.Register("Amplitude", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(0.1D)), PixelShaderConstantCallback(1)));
		public static readonly DependencyProperty FrequencyProperty = DependencyProperty.Register("Frequency", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(70D)), PixelShaderConstantCallback(2)));
		public static readonly DependencyProperty PhaseProperty = DependencyProperty.Register("Phase", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(3)));
		public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(RippleEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(4)));
		public RippleEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri("/Pichur;component/Shaders/Ripple.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(CenterProperty);
			this.UpdateShaderValue(AmplitudeProperty);
			this.UpdateShaderValue(FrequencyProperty);
			this.UpdateShaderValue(PhaseProperty);
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
		/// <summary>The center point of the ripples.</summary>
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
		/// <summary>The amplitude of the ripples.</summary>
		public double Amplitude
		{
			get
			{
				return ((double)(this.GetValue(AmplitudeProperty)));
			}
			set
			{
				this.SetValue(AmplitudeProperty, value);
			}
		}
		/// <summary>The frequency of the ripples.</summary>
		public double Frequency
		{
			get
			{
				return ((double)(this.GetValue(FrequencyProperty)));
			}
			set
			{
				this.SetValue(FrequencyProperty, value);
			}
		}
		/// <summary>The phase of the ripples.</summary>
		public double Phase
		{
			get
			{
				return ((double)(this.GetValue(PhaseProperty)));
			}
			set
			{
				this.SetValue(PhaseProperty, value);
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
