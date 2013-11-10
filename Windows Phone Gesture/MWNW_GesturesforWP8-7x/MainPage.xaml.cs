using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MWNW_GesturesforWP8_7x
{
    public partial class MainPage : PhoneApplicationPage
    {

        private double _initialAngle;
        private double _initialScale;


        // Constructeur
        public MainPage()
        {
            InitializeComponent();
        }



        private void OnDragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            Image rect = sender as Image;
            TranslateTransform transform = rect.RenderTransform as TranslateTransform;


            MyMustacheTransformation.TranslateX += e.HorizontalChange;
            MyMustacheTransformation.TranslateY += e.VerticalChange;
        }


        private void OnPinchDelta(object sender, PinchGestureEventArgs e)
        {

            MyMustacheTransformation.Rotation = _initialAngle + e.TotalAngleDelta;
            MyMustacheTransformation.ScaleX = _initialScale * e.DistanceRatio;
            MyMustacheTransformation.ScaleY = MyMustacheTransformation.ScaleX;
        }
        private void OnPinchStarted(object sender, PinchStartedGestureEventArgs e)
        {

            _initialAngle = MyMustacheTransformation.Rotation;
            _initialScale = MyMustacheTransformation.ScaleX;


            Point firstTouch = e.GetPosition(myMustache, 0);
            Point secondTouch = e.GetPosition(myMustache, 1);

            Point center = new Point(firstTouch.X + (secondTouch.X - firstTouch.X) / 2.0,
                                        firstTouch.Y + (secondTouch.Y - firstTouch.Y) / 2.0);

            MyMustacheTransformation.CenterX = center.X;
            MyMustacheTransformation.CenterY = center.Y;
        }

    }
}