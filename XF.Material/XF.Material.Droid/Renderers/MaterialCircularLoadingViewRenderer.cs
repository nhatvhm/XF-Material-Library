﻿using Android.Graphics;
using Com.Airbnb.Lottie;
using Lottie.Forms;
using Lottie.Forms.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF.Material.Droid.Renderers;
using XF.Material.Views;
using static Com.Airbnb.Lottie.LottieAnimationView;

[assembly: ExportRenderer(typeof(MaterialCircularLoadingView), typeof(MaterialCircularLoadingViewRenderer))]
namespace XF.Material.Droid.Renderers
{
    public class MaterialCircularLoadingViewRenderer : AnimationViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<AnimationView> e)
        {
            base.OnElementChanged(e);

            if(e?.NewElement != null)
            {
                var materialElement = this.Element as MaterialCircularLoadingView;
                this.Control.SetAnimation(Resource.Raw.loading_animation, CacheStrategy.Strong);
                this.Control.AddValueCallback(new Com.Airbnb.Lottie.Model.KeyPath("**"), LottieProperty.ColorFilter, new Com.Airbnb.Lottie.Value.LottieValueCallback(new PorterDuffColorFilter(materialElement.Color.ToAndroid(), PorterDuff.Mode.SrcAtop)));
                this.Control.PlayAnimation();
            }
        }
    }
}