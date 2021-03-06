﻿using System.Collections.Generic;

namespace GeoWeather.Stations
{
    /// <summary>
    /// Lists known NOAA weather stations (callsigns + details) from https://radar.weather.gov/
    /// </summary>
    /// <remarks>
    /// Ideally this would be a read-in file, but this changes so infrequently that it's easy to modify here and recompile when changes are needed.</remarks>
    public static class KnownStations
    {
        /// <summary>
        /// Maps each NOAA weather station callsign to data about that station.
        /// </summary>
        public static IReadOnlyList<Station> Stations = new List<Station>
        {
            new Station("BMX", "Birmingham, AL", 33.52068, -86.81176),
            new Station("EOX", "Fort Rucker, AL", 31.33675, -85.71153),
            new Station("HTX", "Huntsville, AL", 34.72929, -86.5851),
            new Station("MOB", "Mobile, AL", 30.68648, -88.05297),
            new Station("MXX", "Auburn, AL", 32.60746, -85.48173),
            new Station("ABC", "Bethel, AK", 60.79429, -161.7609),
            new Station("ACG", "Sitka, AK", 57.05202, -135.334),
            new Station("AEC", "Nome, AK", 64.49947, -165.4058),
            new Station("AHG", "Kenai, AK", 60.55308, -151.2597),
            new Station("AKC", "King Salmon, AL", 58.69601, -156.6975),
            new Station("APD", "Fairbanks, AL", 64.84509, -147.722),
            new Station("EMX", "Tucson, AZ", 32.21041, -110.9187),
            new Station("FSX", "Flagstaff, AZ", 35.198284, -111.651299),
            new Station("IWA", "Phoenix, AZ", 33.448376, -112.074036),
            new Station("YUX", "Yuma, AZ", 32.68485, -114.6246),
            new Station("LZK", "Little Rock, AR", 34.72527, -92.27031),
            new Station("SRX", "Fort Smith, AR", 35.3846, -94.4213),
            new Station("BBX", "Beale AFB, CA", 39.14078, -121.6195),
            new Station("BHX", "Eureka, CA", 40.8021, -124.1637),
            new Station("DAX", "Sacramento, CA", 38.57933, -121.4909),
            new Station("EYX", "Edwards AFB, CA", 34.20965, -118.4859),
            new Station("HNX", "Hanford, CA", 36.32717, -119.6458),
            new Station("MUX", "San Francisco Bay Area, CA", 37.77937, -122.3981),
            new Station("NKX", "San Diego, CA", 32.8169573, -117.13363),
            new Station("SOX", "Santa Ana Mtns, CA", 33.745571, -117.867836),
            new Station("VBX", "Vandenberg AFB, CA", 34.7493, -120.5173),
            new Station("VTX", "Los Angeles, CA", 34.0498, -118.2498),
            new Station("FTG", "Denver, CO", 39.73715, -104.9892),
            new Station("GJX", "Grand Junction, CO", 39.06879, -108.5645),
            new Station("PUX", "Pueblo, CO", 38.26386, -104.6124),
            new Station("DOX", "Dover AFB, DL", 39.127904, -75.470539),
            new Station("AMX", "Miami, FL", 25.772506, -80.215362),
            new Station("BYX", "Key West, FL", 24.55236, -81.80479),
            new Station("EVX", "Eglin AFB, FL", 30.48944, -86.54222),
            new Station("JAX", "Jacksonville, FL", 30.33147, -81.65622),
            new Station("MLB", "Melbourne, FL", 28.07943, -80.60718),
            new Station("TLH", "Tallahassee, FL", 30.43977, -84.28065),
            new Station("TBW", "Tampa Bay Area, FL", 27.583, -82.633),
            new Station("FFC", "Atlanta, GA", 33.74831, -84.39111),
            new Station("JGX", "Robins AFB, GA", 32.61081, -83.58207),
            new Station("VAX", "Moody AFB, GA", 30.9687, -83.19296),
            new Station("GUA", "Andersen AFB, Guam", 13.58111, 144.9244),
            new Station("HKI", "Kauai, HA", 22.05818, -159.5245),
            new Station("HKM", "Kohala, HA", 20.13194, -155.7939),
            new Station("HMO", "Molokai, HA", 21.13314, -157.0141),
            new Station("HWA", "Hawaiʻi, HA", 19.59852, -155.5186),
            new Station("CBX", "Boise, ID", 43.60761, -116.1934),
            new Station("SFX", "Pocatello, ID", 42.87474, -112.4506),
            new Station("ILX", "Springfield, IL", 39.80105, -89.6436),
            new Station("LOT", "Chicago, IL", 41.88425, -87.63245),
            new Station("IND", "Indianapolis, IN", 39.82761, -86.13511),
            new Station("IWX", "South Bend, IN", 41.67907, -86.25405),
            new Station("VWX", "Evansville, IN", 37.97708, -87.56405),
            new Station("DMX", "Des Moines, IO", 41.58976, -93.61565),
            new Station("DVN", "Quad Cities, IO", 41.51667, -90.53333),
            new Station("DDC", "Dodge City, KS", 37.75266, -100.0187),
            new Station("GLD", "Goodland, KS", 39.36573, -101.712),
            new Station("ICT", "Wichita, KS", 37.65725, -97.37402),
            new Station("TWX", "Topeka, KS", 39.04928, -95.67118),
            new Station("HPX", "Fort Cambell, KY", 36.65, -87.467),
            new Station("JKL", "Jackson, KY", 37.5581, -83.37801),
            new Station("LVX", "Louisville, KY", 38.25486, -85.7664),
            new Station("PAH", "Paducah, KY", 37.08571, -88.59585),
            new Station("LCH", "Lake Charles, LA", 30.22403, -93.22011),
            new Station("LIX", "New Orleans, LA", 29.93507, -90.07906),
            new Station("POE", "Fort Polk, LA", 31.07264, -93.08064),
            new Station("SHV", "Shreveport, LA", 32.51487, -93.74689),
            new Station("CBW", "Caribou, ME", 46.85929, -68.01124),
            new Station("GVX", "Portland, ME", 43.65915, -70.25668),
            new Station("BOX", "Boston, MA", 42.35866, -71.05674),
            new Station("APX", "Gaylord, MI", 45.02736, -84.6777),
            new Station("DTX", "Detroit, MI", 42.33935, -83.06734),
            new Station("BRR", "Grand Rapids, MI", 42.96641, -85.67118),
            new Station("MQT", "Marquette, MI", 46.54584, -87.41368),
            new Station("DLH", "Duluth, MN", 46.78796, -92.09985),
            new Station("MPX", "Minneapolis, MN", 44.97903, -93.26493),
            new Station("DGX", "Jackson, MS", 32.29869, -90.18049),
            new Station("GWX", "Columbus AFB, MS", 33.64517, -88.44592),
            new Station("EAX", "Kansas City, MO", 39.09937, -94.58321),
            new Station("LSX", "St. Louis, MO", 38.62775, -90.19956),
            new Station("SGF", "Springfield, MO", 37.20897, -93.29156),
            new Station("BLX", "Billings, MT", 45.78397, -108.5058),
            new Station("GGW", "Glasgow, MT", 48.19512, -106.6369),
            new Station("MSX", "Missoula, MT", 46.87278, -113.9962),
            new Station("TFX", "Great Falls, MT", 47.50714, -111.3061),
            new Station("LNX", "North Platte, NE", 41.13632, -100.7633),
            new Station("OAX", "Omaha, NE", 41.26067, -95.94056),
            new Station("UEX", "Hastings, NE", 40.58568, -98.39243),
            new Station("ESX", "Las Vegas, NV", 36.01169, -115.1758),
            new Station("LRX", "Elko, NV", 40.83568, -115.7675),
            new Station("RGX", "Reno, NV", 39.52756, -119.8135),
            new Station("DIX", "Mt. Holly, NJ", 39.9928, -74.78925),
            new Station("ABX", "Albuquerque, NM", 35.08423, -106.649),
            new Station("FDX", "Cannon AFB, NM", 34.38389, -103.3167),
            new Station("HDX", "Holloman AFB, NM", 32.85186, -106.1085),
            new Station("BGM", "Binghamton, NY", 42.09869, -75.91136),
            new Station("BUF", "Buffalo, NY", 42.88544, -78.87846),
            new Station("ENX", "Albany, NY", 42.65155, -73.75521),
            new Station("OKX", "NYC, NY", 40.71297, -74.00367),
            new Station("TYX", "Montague, NY", 43.73804, -75.70776),
            new Station("LTX", "Wilmington, NC", 34.23497, -77.946),
            new Station("MHX", "Morehead City, NC", 34.72179, -76.71758),
            new Station("RAX", "Raleigh, NC", 35.78551, -78.64267),
            new Station("BIS", "Bismarck, ND", 46.80536, -100.7793),
            new Station("MBX", "Minot AFB, ND", 48.41577, -101.358),
            new Station("MVX", "Grand Forks, ND", 47.92408, -97.03203),
            new Station("CLE", "Cleveland, OH", 41.49052, -81.66941),
            new Station("ILN", "Dayton, OH", 39.7592, -84.19381),
            new Station("FDR", "Frederick, OK", 34.39252, -99.01702),
            new Station("INX", "Tulsa, OK", 36.14974, -95.99333),
            new Station("TLX", "Oklahoma City, OK", 35.48177, -97.54105),
            new Station("VNX", "Vance AFB, OK", 36.34277, -97.90658),
            new Station("MAX", "Medford, OR", 36.80752, -97.73369),
            new Station("PDT", "Pendleton, OR", 45.67207, -118.7886),
            new Station("RTX", "Portland, OR", 45.51179, -122.6756),
            new Station("CCX", "State College, PN", 40.79373, -77.8607),
            new Station("PBZ", "Pittsburgh, PN", 40.43851, -79.99734),
            new Station("JUA", "Puerto Rico", 18.200178, -66.664513),
            new Station("CAE", "Columbia, SC", 33.99882, -81.04537),
            new Station("CLX", "Charleston, SC", 32.78115, -79.9316),
            new Station("GSP", "Greenville, SC", 34.84827, -82.40011),
            new Station("ABR", "Aberdeen, SD", 45.45909, -98.48732),
            new Station("FSD", "Sioux Falls, SD", 43.54535, -96.73128),
            new Station("UDX", "Rapid City, SD", 44.08116, -103.2309),
            new Station("MRX", "Knoxville, TN", 35.96068, -83.92103),
            new Station("NQA", "Memphis, TN", 35.13823, -90.05046),
            new Station("OHX", "Nashville, TN", 36.16784, -86.77816),
            new Station("AMA", "Amarillo, TX", 35.20725, -101.8339),
            new Station("BRO", "Brownsville, TX", 25.90209, -97.49924),
            new Station("CRP", "Corpus Christi, TX", 27.79641, -97.40374),
            new Station("DFX", "Laughlin AFB, TX", 29.36023, -100.7745),
            new Station("DYX", "Dyess AFB, TX", 32.42092, -99.84566),
            new Station("EPZ", "El Paso, TX", 31.7585, -106.4896),
            new Station("EWX", "Austin, TX", 30.26759, -97.74299),
            new Station("FWS", "Dallas, TX", 32.84652, -96.77169),
            new Station("GRK", "Abilene, TX", 32.44917, -99.74142),
            new Station("HGX", "Houston, TX", 29.74894, -95.35619),
            new Station("LBB", "Lubbock, TX", 33.58451, -101.845),
            new Station("MAF", "Odessa, TX", 31.84915, -102.3752),
            new Station("SJT", "San Angelo, TX", 31.4615, -100.4424),
            new Station("ICX", "Cedar City, UT", 37.67795, -113.0618),
            new Station("MTX", "Salt Lake City, UT", 40.76645, -111.8934),
            new Station("CXX", "Burlington, VT", 44.47593, -73.21277),
            new Station("AKQ", "Richmond, VA", 37.5407, -77.43365),
            new Station("FCX", "Roanoke, VA", 37.20612, -80.03589),
            new Station("ATX", "Seattle, WA", 47.62312, -122.3538),
            new Station("LGX", "Langley Hill, WA", 46.97982, -123.8869),
            new Station("OTX", "Spokane, WA", 47.65726, -117.4123),
            new Station("LWX", "Washington, D. C.", 38.84801, -76.97849),
            new Station("RLX", "Charleston, WV", 38.35588, -81.63992),
            new Station("ARX", "La Crosse, WI", 43.81262, -91.25192),
            new Station("GRB", "Green Bay, WI", 44.513, -88.01001),
            new Station("MKX", "Milwaukee, WI", 43.04181, -87.90684),
            new Station("CYS", "Cheyenne, WY", 41.13481, -104.8215),
            new Station("RIW", "Riverton, WY", 43.02467, -108.3813),
        };
    }
}
