using SmokeBall.BL.Interfaces;

namespace SmokeBall.BL
{
    public class FindMatchItem : IFindMatchItem
    {
        public List<int> FindLinkLocations(List<string> links, string url)
        {
            var locations = new List<int>();
            var locationIndex = 1;

            foreach (var result in links)
            {
                if (result.Contains(url))
                    locations.Add(locationIndex);
                locationIndex++;
            }

            return locations;
        }
    }
}
