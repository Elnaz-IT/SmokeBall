namespace SmokeBall.BL.Interfaces
{
    public interface IScrapperService
    {
        public List<int> SerachAndFindLinkLoations(string keyWords, string url);
    }
}
