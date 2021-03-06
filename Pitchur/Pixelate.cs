﻿
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;


namespace Pichur 
{

	/// <summary>An effect that turns the input into blocky pixels.</summary>
	public class PixelateEffect : ShaderEffect
	{
		public static readonly DependencyProperty InputProperty = ShaderEffect.RegisterPixelShaderSamplerProperty("Input", typeof(PixelateEffect), 0);
		public static readonly DependencyProperty PixelCountsProperty = DependencyProperty.Register("PixelCounts", typeof(Size), typeof(PixelateEffect), new UIPropertyMetadata(new Size(60D, 40D), PixelShaderConstantCallback(0)));
		public static readonly DependencyProperty BrickOffsetProperty = DependencyProperty.Register("BrickOffset", typeof(double), typeof(PixelateEffect), new UIPropertyMetadata(((double)(0D)), PixelShaderConstantCallback(1)));
		public PixelateEffect()
		{
			PixelShader pixelShader = new PixelShader();
			pixelShader.UriSource = new Uri("/Pichur;component/Shaders/Pixelate.ps", UriKind.Relative);
			this.PixelShader = pixelShader;

			this.UpdateShaderValue(InputProperty);
			this.UpdateShaderValue(PixelCountsProperty);
			this.UpdateShaderValue(BrickOffsetProperty);
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
		/// <summary>The number of horizontal and vertical pixel blocks.</summary>
		public Size PixelCounts
		{
			get
			{
				return ((Size)(this.GetValue(PixelCountsProperty)));
			}
			set
			{
				this.SetValue(PixelCountsProperty, value);
			}
		}
		/// <summary>The amount to shift alternate rows (use 1 to get a brick wall look).</summary>
		public double BrickOffset
		{
			get
			{
				return ((double)(this.GetValue(BrickOffsetProperty)));
			}
			set
			{
				this.SetValue(BrickOffsetProperty, value);
			}
		}
	}
}

