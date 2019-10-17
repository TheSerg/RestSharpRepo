namespace ApiTests.Models
{
    public class Weather
    {
        public int ID
        {
            get; set;
        }

        public string Timezone
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Cod
        {
            get; set;
        }

        public string Temp
        {
            get; set;
        }

        public string Pressure
        {
            get; set;
        }

        public string Humidity
        {
            get; set;
        }

        public string Temp_min
        {
            get; set;
        }

        public string Temp_max
        {
            get; set;
        }
    }

    public class WeatherBuilder
    {
        private readonly Weather weather = new Weather();

        public WeatherBuilder WithId(int id)
        {
            this.weather.ID = id;
            return this;
        }

        public WeatherBuilder WithTimezone(string timezone)
        {
            this.weather.Timezone = timezone;
            return this;
        }

        public WeatherBuilder WithName(string name)
        {
            this.weather.Name = name;
            return this;
        }

        public WeatherBuilder WithCod(string cod)
        {
            this.weather.Cod = cod;
            return this;
        }

        public WeatherBuilder WithTemp(string temp)
        {
            this.weather.Temp = temp;
            return this;
        }

        public WeatherBuilder WithPressure(string pressure)
        {
            this.weather.Pressure = pressure;
            return this;
        }

        public WeatherBuilder WithHumidity(string humidity)
        {
            this.weather.Humidity = humidity;
            return this;
        }

        public WeatherBuilder WithTemp_max(string temp_max)
        {
            this.weather.Temp_max = temp_max;
            return this;
        }

        public WeatherBuilder WithTemp_min(string temp_min)
        {
            this.weather.Temp_min = temp_min;
            return this;
        }

        public Weather Build()
        {
            return this.weather;
        }
    }
}
