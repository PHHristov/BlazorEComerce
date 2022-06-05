namespace BlazorEComerce.Client.Shared
{
    public partial class ProductList
    {
        private static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Title ="Hvyrchiplqktor",
                Description = "its something",
                ImageUrl = "https://tractor.bg/media/2019/02/19/262745/710x710.jpg",
                Price = 9.99m
            },
            new Product
            {
                Id = 2,
                Title ="Sharazunga",
                Description = "its something as well",
                ImageUrl = "https://pbs.twimg.com/ext_tw_video_thumb/1507193246069534723/pu/img/ecuzLUJYJo2XK6BH.jpg",
                Price = 9.99m
            },
            new Product
            {
                Id = 3,
                Title ="Kokoshinka",
                Description = "its a bug",
                ImageUrl = "https://agro-journal.com/wp-content/uploads/2021/02/agro-journal-dermanyssus-gallinae-kokoshinka-vrediteli-02.jpg",
                Price = 9.99m
            },
        };
    }
}
