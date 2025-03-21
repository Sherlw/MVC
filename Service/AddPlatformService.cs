namespace MVC.Service
{
    public class AddPlatformService
    {
        private readonly Dictionary<string, List<string>> _platforms = new();

        public void LoadPlatforms(string[] lines)
        {
            _platforms.Clear();
            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    var platform = parts[0].Trim();
                    var locations = parts[1].Split(',').Select(loc => loc.Trim()).ToList();
                    _platforms[platform] = locations;
                }
            }
        }

        public List<string> FindPlatforms(string location)
        {
            return _platforms.Where(p => p.Value.Any(loc => location.StartsWith(loc)))
                             .Select(p => p.Key)
                             .ToList();
        }
    }
}
