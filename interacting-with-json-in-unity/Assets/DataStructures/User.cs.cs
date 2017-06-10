[System.Serializable]
public struct GeoCoords
{
    public float lat;
    public float lng;
}

[System.Serializable]
public struct Address
{
    public string street;
    public string suite;
    public string city;
    public string zipcode;
    public GeoCoords geo;
}

[System.Serializable]
public struct Company
{
    public string name;
    public string catchPhrase;
    public string bs;
}

[System.Serializable]
public class User
{
    public int id;
    public string name;
    public string email;
    public Address address;
    public string phone;
    public string website;
    public Company company;
}