namespace DrinkAndRate.Web.User
{
    using DrinkAndRate.Data;
    using DrinkAndRate.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    public partial class BeerCreate : Page
    {
        private const int MAX_FILE_SIZE = 10485760;

        private string[] imageFormats = new string[3] { "image/jpeg", "image/jpg", "image/png" };

        //TODO Ninject
        private IDrinkAndRateData data;

        protected void Page_Load(object sender, EventArgs e)
        {
            var dbContext = new DrinkAndRateDbContext();
            this.data = new DrinkAndRateData(dbContext);

            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void AddBrandButton_Click(object sender, EventArgs e)
        {
            this.SelectBrand.Visible = !this.SelectBrand.Visible;
            this.BrandCreation.Visible = !this.BrandCreation.Visible;
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string filePathAndName = string.Empty;

                try
                {
                    filePathAndName = FileUpload();
                }
                catch (InvalidOperationException ex)
                {
                    this.DivLabelErrorMessage.Visible = true;
                    this.LabelErrorMessage.Text = ex.Message;

                    return;
                }

                var loggedInUserName = HttpContext.Current.User.Identity.Name;
                var currentUserId = this.data.Users.All().FirstOrDefault(x => x.UserName == loggedInUserName).Id;

                var newBeer = new Beer
                {
                    CategoryID = int.Parse(this.Categories.SelectedValue),
                    CreatedOn = DateTime.Now,
                    Name = this.name.Value,
                    CreatorID = currentUserId
                };

                if (this.SelectBrand.Visible)
                {
                    newBeer.BrandID = int.Parse(this.Brands.SelectedValue);
                }
                else
                {
                    var newBrand = new Brand
                    {
                        Name = this.BrandName.Text,
                        CountryID = int.Parse(this.Countries.SelectedValue),
                        Established = Convert.ToDateTime(this.Established.Value),
                    };

                    this.data.Brands.Add(newBrand);
                    this.data.SaveChanges();

                    newBeer.BrandID = newBrand.ID;
                }

                if (!string.IsNullOrEmpty(filePathAndName))
                {
                    var newImage = new Image
                    {
                        Path = filePathAndName
                    };

                    this.data.Images.Add(newImage);
                    this.data.SaveChanges();
                    newBeer.Images.Add(newImage);
                }

                if (!string.IsNullOrEmpty(this.alcoholPercentage.Value))
                {
                    newBeer.AlchoholPercentage = int.Parse(this.alcoholPercentage.Value);
                }

                if (!string.IsNullOrEmpty(this.description.Value))
                {
                    newBeer.Description = this.description.Value;
                }

                this.data.Beers.Add(newBeer);
                this.data.SaveChanges();

                Response.Redirect("~/User/Beers");
            }
            else
            {
                throw new InvalidOperationException("Error occure while saving the element!");
            }
        }

        private void LoadData()
        {
            var allBrands = this.data.Brands.All().ToList();
            this.Brands.DataSource = allBrands;
            this.Brands.DataBind();

            var allCountries = this.data.Countries.All().ToList();
            this.Countries.DataSource = allCountries;
            this.Countries.DataBind();

            var allCategories = this.data.Categories.All().ToList();
            this.Categories.DataSource = allCategories;
            this.Categories.DataBind();
        }

        private string FileUpload()
        {
            //TODO: Finish the method + think to recreate in  control
            if (ImageUpload.HasFile)
            {

                if (imageFormats.Any(ImageUpload.PostedFile.ContentType.Contains))
                {
                    if (ImageUpload.PostedFile.ContentLength < MAX_FILE_SIZE)
                    {
                        var guidName = Guid.NewGuid();
                        var extension = Path.GetExtension(ImageUpload.FileName);

                        string fileName = string.Format("{0}.{1}", guidName, extension);

                        string path = Server.MapPath("~/App_Data/ImageFiles/");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        ImageUpload.SaveAs(path + fileName);

                        return "~/App_Data/ImageFiles/" + fileName;
                    }
                    else
                    {
                        throw new InvalidOperationException("Upload status: The file has to be less than 10 mb!");
                    }
                }
                else
                {
                    throw new InvalidOperationException("Upload status: Only JPEG or PNG files are accepted!");
                }

            }

            return string.Empty;
        }
    }
}