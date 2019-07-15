namespace AspNetCoreMvcExample.Services
{
    public interface IRankService<in T>
    {
        string GetRank(T cards);
    }
}