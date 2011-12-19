﻿using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{
	/// <summary>An effect that pinches a circular region.</summary>
	public class PinchEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(PinchEffect), 0);
		public static readonly DependencyProperty CenterProperty = DependencyProperty.Register("Center", typeof(Point), typeof(PinchEffect), new UIPropertyMetadata(new Point(0.5D, 0.5D), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register("Radius", typeof(double), typeof(PinchEffect), new UIPropertyMetadata(((double)(0.25D)), PixelShaderConstantCallback(1)));
		public static readonly DependencyProperty StrengthProperty = DependencyProperty.Register("Strength", typeof(double), typeof(PinchEffect), new UIPropertyMetadata(((double)(1D)), PixelShaderConstantCallback(2)));
		public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(PinchEffect), new UIPropertyMetadata(((double)(1.5D)), PixelShaderConstantCallback(3)));
		public PinchEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri("/Pichur;component/Shaders/Pinch.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(CenterProperty);
			this.UpdateShaderValue(RadiusProperty);
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
		/// <summary>The center point of the pinched region.</summary>
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
		/// <summary>The radius of the pinched region.</summary>
		public double Radius
		{
			get
			{
				return ((double)(this.GetValue(RadiusProperty)));
			}
			set
			{
				this.SetValue(RadiusProperty, value);
			}
		}
		/// <summary>The strength of the pinch effect.</summary>
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
