using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RATA.Shared.Models;
using RATA.Shared.Services;
using System.Collections.ObjectModel;

namespace RATA.ViewModel
{
    public partial class TenantsViewModel : ObservableObject
    {
        private readonly TenantDatabase dataContext;
        public TenantsViewModel(TenantDatabase context)
        {
            dataContext = context;
            this.AddTenantLabel = "Add Tenants";
            this.ShowAllTenants = true;
            this.ShowAddTenant = false;
            this.Tenant = new Tenant();
            //this.Tenant.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            this.Tenant.RentedDate = DateTime.Now;
            this.Tenants = new ObservableCollection<Tenant>();
            foreach (var item in dataContext.TenantSet)
            {
                this.Tenants.Add(new Tenant()
                {
                    Advance = item.Advance,
                    FlatNumber = item.FlatNumber,
                    MobileNumber = item.MobileNumber,
                    PermanentAddress = item.PermanentAddress,
                    Rent = item.Rent,
                    RentedDate = item.RentedDate,
                    SiteNumber = item.SiteNumber,
                    TenantName = item.TenantName,
                    VacatedDate = item.VacatedDate,
                    //MinDate = new DateTime(DateTime.Now.Year, 1, 1)
                });
            }

            //    this.Tenants = new ObservableCollection<Tenant>()
            //{
            //    new Tenant(){
            //        Advance = 50000,
            //        FlatNumber = "First Floor 1 BHK",
            //        MobileNumber = "1230456789",
            //        PermanentAddress= "",
            //        RentedDate = DateTime.Now,
            //        SiteNumber = "62",
            //        TenantName="Test"
            //    },
            //    new Tenant(){
            //        Advance = 50000,
            //        FlatNumber = "First Floor 1 BHK",
            //        MobileNumber = "1230456789",
            //        PermanentAddress= "",
            //        RentedDate = DateTime.Now,
            //        SiteNumber = "62",
            //        TenantName="Test"
            //    },
            //};
        }

        [ObservableProperty]
        Tenant tenant;

        [ObservableProperty]
        ObservableCollection<Tenant> tenants;

        [ObservableProperty]
        bool showAddTenant;

        [ObservableProperty]
        bool showAllTenants;

        [ObservableProperty]
        string addTenantLabel;

        #region commented
        //[ObservableProperty]
        //string tenantName;

        //[ObservableProperty]
        //string mobileNumber;

        //[ObservableProperty]
        //DateTime rentedDate;

        //[ObservableProperty]
        //DateTime minDate;

        //[ObservableProperty]
        //decimal advance;

        //[ObservableProperty]
        //string permanentAddress;

        #endregion

        [RelayCommand]
        public async Task TakePhoto()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
        }

        [RelayCommand]
        async Task AddTenant()
        {
            if (this.AddTenantLabel == "Add Tenants")
            {
                this.AddTenantLabel = "Show All Tenants";
                this.ShowAllTenants = false;
                this.ShowAddTenant = true;
            }
            else
            {
                this.AddTenantLabel = "Add Tenants";
                this.ShowAllTenants = true;
                this.ShowAddTenant = false;
            }
        }

        [RelayCommand]
        async Task SaveTenantDetails()
        {
            try
            {

                dataContext.TenantSet.Add(new Tenant()
                {
                    Advance = this.Tenant.Advance,
                    FlatNumber = this.Tenant.FlatNumber,
                    MobileNumber = this.Tenant.MobileNumber,
                    PermanentAddress = this.Tenant.PermanentAddress,
                    Rent = this.Tenant.Rent,
                    RentedDate = this.Tenant.RentedDate,
                    SiteNumber = this.Tenant.SiteNumber,
                    TenantName = this.Tenant.TenantName,
                    VacatedDate = this.Tenant.VacatedDate

                });
                dataContext.SaveChanges();

                this.Tenant = new Tenant();
                this.Tenants.Clear();
                foreach (var item in dataContext.TenantSet)
                {
                    this.Tenants.Add(new Tenant()
                    {
                        Advance = item.Advance,
                        FlatNumber = item.FlatNumber,
                        MobileNumber = item.MobileNumber,
                        PermanentAddress = item.PermanentAddress,
                        Rent = item.Rent,
                        RentedDate = item.RentedDate,
                        SiteNumber = item.SiteNumber,
                        TenantName = item.TenantName,
                        VacatedDate = item.VacatedDate,
                        //MinDate = new DateTime(DateTime.Now.Year, 1, 1)
                    });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

}
