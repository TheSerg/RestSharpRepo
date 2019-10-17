namespace ApiTests.Schemas
{
    using Newtonsoft.Json.Schema;

    public class ProductSchemas
    {
        private JSchema GetProductSchema()
        {
            JSchema productSchema = JSchema.Parse(
                   @"{
                       'coord': {
		                    'lon': double,
		                    'lat': double
	                    },
	                    'weather': [
		                    {
			                    'id': int,
			                    'main': 'string',
			                    'description': 'string',
			                    'icon': 'string'
		                    }
	                    ],
	                    'base': string,
	                    'main': {
		                    'temp': double,
		                    'pressure': int,
		                    'humidity': int,
		                    'temp_min': double,
		                    'temp_max': double
	                    },
	                    'visibility': int,
	                    'wind': {
		                    'speed':double,
		                    'deg': int
	                    },
	                    'clouds': {
		                    'all': int
	                    },
	                    'dt': long,
	                    'sys': {
		                    'type': 1,
		                    'id': int,
		                    'message': float,
		                    'country': 'string',
		                    'sunrise': long,
		                    'sunset': long
	                    },
	                    'timezone': int,
	                    'id': long,
	                    'name': 'string',
	                    'cod': int
                }");

            // Example of schema adjusting
            productSchema.AllowAdditionalItems = true;

            return productSchema;
        }
    }
}