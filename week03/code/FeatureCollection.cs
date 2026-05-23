public class FeatureCollection
{
    // Problem 5:
    // This class represents the main JSON object returned
    // from the USGS earthquake API.

    // The JSON contains a list called "features"
    // which stores earthquake information.
    public List<Feature> Features { get; set; } = new();
}

// Represents each earthquake entry in the JSON data
public class Feature
{
    // Each feature contains a "properties" object
    // with earthquake details such as place and magnitude.
    public Properties Properties { get; set; } = new();
}

// Represents the earthquake details
public class Properties
{
    // Location where the earthquake happened
    public string Place { get; set; } = "";

    // Magnitude of the earthquake
    public double Mag { get; set; }
}