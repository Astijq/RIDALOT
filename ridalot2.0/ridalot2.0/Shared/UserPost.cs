using Microsoft.AspNetCore.Components;
using System.Data;

namespace ridalot2._0.Shared
{
    public class UserPost : ComponentBase
    {
        protected int width;
        protected int height;
        protected string description;
        protected string img;
        protected string date;
        protected IEnumerable<UserPost> postList;
        void createList(IEnumerable<string> data)
        {
            postList = data.Select(item => new UserPost
            {
                // width = ...;
            })
            .ToList();
        }
    }


}
