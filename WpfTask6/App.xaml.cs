using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace WpfTask6
{ 
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty;
        private string direction_wind;
        private int speed_wind;
        private Precipitation precipitation;
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }
        public WeatherControl(int temperature, string direction_wind, int speed_wind, Precipitation precipitation)
        {
            this.Temperature = temperature;
            this.DirectionWind = direction_wind;
            this.SpeedWind = speed_wind;
            this.precipitation = precipitation;
        }
        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsParentMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                    new ValidateValueCallback(ValidateTemperature));
        }
        private static bool ValidateTemperature(object value)
        {
            int t = (int)value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }
        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int t = (int)baseValue;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false;
        }
        public string DirectionWind
        {
            get => direction_wind;
            set => direction_wind = value;
        }
        public int SpeedWind
        {
            get => speed_wind;
            set => speed_wind = value;
        }
        public enum Precipitation
        {
            солнечно = 0,
            облачно = 1,
            дождь = 2,
            снег = 4
        }
        public string Print()
        {
            return $" {Temperature} {DirectionWind} {SpeedWind} Precipitation";
        }
    }
}


